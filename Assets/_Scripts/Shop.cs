using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class Shop : MonoBehaviour {

    public Main MainScript;
    public Quest QuestScript;
    [Space]
    public GameObject RotateingCube, ShopObjects;
    public Button BuySetButton;
    public Text BuySetText, 
                NeedCompleteQuests;
    public GameObject PlayerCube;
    public Renderer[] PlayerCubeRenderers;
    private int BeginType;

    public void StartShop ()
    {
        BeginType = PlayerPrefs.GetInt("NowType", 0);
        gameObject.SetActive(true);
        //Transform _go = MainScript.MainPanel.transform;
        //for (int i = 0; i < _go.transform.childCount; i++)
        //  _go.GetChild(i).gameObject.SetActive(false);
        MainScript.MainPanel.SetActive(false);
        ShopObjects.SetActive(true);
        BuySetText.text = Lang.Phrase("Set");
        Camera.main.GetComponent<Animator>().Play("CameraToShop");
        CheckShop(PlayerPrefs.GetInt("NowType", 0), Resources.Load<GameObject>(PlayerPrefs.GetInt("NowType", 0).ToString()));
        SetShopObjects();
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, 10))
            {
                CheckShop(int.Parse(_hit.transform.name), _hit.transform.gameObject);
            }
        }
    }

    public void CheckShop(int _name, GameObject game)
    {
        int _childcount = RotateingCube.transform.childCount;
        for (int i = 0; i < _childcount; i++)
            DestroyImmediate(RotateingCube.transform.GetChild(0).gameObject);
        GameObject cube = Instantiate(game);
        cube.transform.localScale = RotateingCube.transform.localScale * (_name == 7 ? 2.126f : 1);
        cube.transform.position = RotateingCube.transform.position;
        cube.transform.rotation = RotateingCube.transform.rotation;
        cube.transform.SetParent(RotateingCube.transform);
        MainScript.ClickNowType = _name;
        NeedCompleteQuests.text = "";
        if (PlayerPrefs.GetString("ShopObjects", "TFFFFFFFFFFF")[_name] == 'T')
        {
            BuySetButton.interactable = true;
            if (PlayerPrefs.GetInt("NowType", 0) != _name)
            {
                BuySetText.transform.parent.gameObject.SetActive(true);
                BuySetText.text = Lang.Phrase("Set");
            }
            else
                BuySetText.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            BuySetText.text = Lang.Phrase("Get");
            if (QuestScript.GetNeedQuest(MainScript.ClickNowType) >= Save.NowQuest)
            {
                BuySetButton.interactable = false;
                NeedCompleteQuests.text = Lang.Phrase("Need complete quests") + ": " + QuestScript.GetNeedQuest(MainScript.ClickNowType);
            }
#if UNITY_EDITOR
            else if (true)
            {
                BuySetButton.interactable = true;
            }
#elif !UNITY_EDITOR
            else if (MainScript.rewardBasedVideo.IsLoaded())
            {
                BuySetButton.interactable = true;
            }
#endif
            else
            {
                AdRequest _request = new AdRequest.Builder().Build();
                MainScript.rewardBasedVideo.LoadAd(_request, MainScript.GetMoneyVideo);
                BuySetButton.interactable = false;
            }
            BuySetText.transform.parent.gameObject.SetActive(true);
        }
    }

    public void ClickOnBuySetButtonShop()
    {
        if (PlayerPrefs.GetString("ShopObjects", "TFFFFFFFFFFF")[MainScript.ClickNowType] == 'T')
        {
            PlayerPrefs.SetInt("NowType", MainScript.ClickNowType);

            int _childcount = PlayerCube.transform.childCount;
            for (int i = 0; i < _childcount; i++)
                DestroyImmediate(PlayerCube.transform.GetChild(0).gameObject);
            
            GameObject goj = Instantiate(Resources.Load<GameObject>(PlayerPrefs.GetInt("NowType", 0).ToString()),
                                        PlayerCube.transform.position, PlayerCube.transform.rotation) as GameObject;
            goj.transform.SetParent(PlayerCube.transform);
            PlayerCubeRenderers = PlayerCube.GetComponentsInChildren<Renderer>();
            MainScript.PlayerCubeRenderers = PlayerCube.GetComponentsInChildren<Renderer>();
            DateTime dt = new DateTime(PlayerPrefs.GetInt("AlphaYear", DateTime.Now.Year), PlayerPrefs.GetInt("AlphaMonth", DateTime.Now.Month),
                                        PlayerPrefs.GetInt("AlphaDay", DateTime.Now.Day), PlayerPrefs.GetInt("AlphaHour", DateTime.Now.Hour), 
                                        PlayerPrefs.GetInt("AlphaMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("AlphaSecond", DateTime.Now.Second));
            foreach(Renderer r in PlayerCubeRenderers)
            {
                for (int i = 0; i < r.materials.Length; i++)
                {
                    Color cl11 = r.materials[i].color;
                    cl11.a = dt > DateTime.Now ? PlayerPrefs.GetFloat("AlphaSliderValue", 1f) : 1f;
                    r.materials[i].color = cl11;
                }
            }
            BuySetButton.gameObject.SetActive(false);
        }
        else
        {
#if UNITY_EDITOR
            MainScript.OnAdRewardedVideo(new object(), new EventArgs());
#endif
            MainScript.rewardBasedVideo.Show();
        }
    }

    public void ClickOnUnShop()
    {
        Vector3 _v3 = ShopObjects.transform.position;
        _v3.x = 23;
        ShopObjects.transform.position = _v3;
        //PlayerCube.GetComponent<BoxCollider>().isTrigger = false;
        if (Save.NowQuest <= 50)
                QuestScript.QuestEx.text = Lang.Phrase("Quest") + " #" + Save.NowQuest.ToString() + ": " + QuestScript.GetQuestText(Save.NowQuest);
        else 
            QuestScript.QuestEx.text = Lang.Phrase("Well, you complete all quests!");
        Camera.main.GetComponent<Animator>().Play("CameraToPlay");
        if (BeginType != PlayerPrefs.GetInt("NowType", 0))
        MainScript.SetNewColors();
        gameObject.SetActive(false);
    }

    public void SetShopObjects()
    {
        for (int i = 0; i < ShopObjects.transform.childCount; i++)
        {
            Renderer[] renderers = ShopObjects.transform.GetChild(i).GetComponentsInChildren<Renderer>();
            SetNewColorsShop(renderers);
        }
    }

    public void SetNewColorsShop(Renderer[] renderers)
    {
        List<int> _listcl = new List<int>();
        for (int i = 0; i < renderers.Length; i++)
        {
            for (int q = 0; q < renderers[i].materials.Length; q++)
            {
                int _temp = UnityEngine.Random.Range(0, 9);
                bool _thisTrue = true;
                for (int j = 0; j < _listcl.Count; j++)
                {
                    if (_temp == _listcl[j])
                    {
                        _thisTrue = false;
                        break;
                    }
                }
                if (_thisTrue)
                    _listcl.Add(_temp);
                else
                    q--;
            }
        }

        int _tempcolor = 0;
        for (int i = 0; i < renderers.Length; i++)
        {
            for (int j = 0; j < renderers[i].materials.Length; j++)
            {
                renderers[i].materials[j].color = MainScript.GetColorPlayer(_listcl[_tempcolor++]);
            }
        }
    }
}

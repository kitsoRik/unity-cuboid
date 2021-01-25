using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;


public class Main : MonoBehaviour
{
    public Quest QuestScript;
    public CubeRun CubeRunScript;
    public Shop ShopScript;
    public CreateObjects CreateObjectsScript;
    public Alpha AlphaScript;
    public GameObject EventCubes, EventButtons, Tunnel;
    public Text ScoreText;

    public bool AlphaBool;
    public Renderer[] PlayerCubeRenderers;
    public Animator[] PlayerCybeAnimator;


    [Header("Question")]
    public GameObject QuestionPanel;
    private Action QuestionAction;
    [Header("Panels")]
    public GameObject ShopPanel;
    public GameObject MainPanel;
    public GameObject LosePanel;
    public GameObject BackGround;
    public GameObject PlayerCube;
    public GameObject AlphaPanel;
    public Button AlphaButton;
    public Coroutine AlphaCoroutine;

    public bool RandomCubes;


    public bool Play;
    public int Mode; // 1 Swipe, 2 Touch, 3 Linear
    public Text NeedIntConnection;

    public AudioSource Music, Sound;
    public AudioClip MainMusic;

    [HideInInspector]
    public int ClickNowType;
    [HideInInspector]
    public RewardBasedVideoAd rewardBasedVideo, rewardBasedAlpha;
    private InterstitialAd AfterFourLoseAd;
    public BannerView BasedBanner;
    public string GetAlphaVideo = "ca-app-pub-3940256099942544/5224354917";
    public string GetMoneyVideo = "ca-app-pub-6132055699566134/9616923464";
    public string GetAfterFourLose = "ca-app-pub-6132055699566134/3929482517";
    public string GetBanner = "ca-app-pub-6132055699566134/1845949506";
    private bool AlphaVideoIsRewarded;
    public string appID = "ca-app-pub-6132055699566134~3542174556";
    public int CountLoseAd;

    void Start()
    {
        Save.NowQuest = 51;
        Lang.Starting();
        MobileAds.Initialize(appID);
        Music.volume = PlayerPrefs.GetString("Music", "Yes") == "Yes" ? 1 : 0;
        Sound.volume = PlayerPrefs.GetString("Sound", "Yes") == "Yes" ? 1 : 0;

        if (Save.NowQuest <= 50)
            QuestScript.QuestEx.text = Lang.Phrase("Quest") + " #" + Save.NowQuest.ToString() + ": " + QuestScript.GetQuestText(Save.NowQuest);
        else
        {
            QuestScript.QuestEx.text = Lang.Phrase("Well, you complete all quests!");
        }

        ClickNowType = PlayerPrefs.GetInt("NowType", 0);
        GameObject obj = Instantiate(Resources.Load<GameObject>(ClickNowType.ToString())) as GameObject;
        obj.transform.position = PlayerCube.transform.position;
        obj.transform.SetParent(PlayerCube.transform);
        PlayerCybeAnimator = PlayerCube.GetComponentsInChildren<Animator>();

        if (QuestScript.JustCheckColorQuest())
            SetNewColors();
        else
        {
            PlayerCubeRenderers = PlayerCube.GetComponentsInChildren<Renderer>();
            Color _cl = GetQuestColor(Save.NowQuest);
            for (int i = 0; i < PlayerCubeRenderers.Length; i++)
            {
                for (int j = 0; j < PlayerCubeRenderers[i].materials.Length; j++)
                {
                    PlayerCubeRenderers[i].materials[j].color = _cl;
                }
            }
        }
        /*DateTime dt = new DateTime(PlayerPrefs.GetInt("AlphaYear", DateTime.Now.Year), PlayerPrefs.GetInt("AlphaMonth", DateTime.Now.Month), PlayerPrefs.GetInt("AlphaDay", DateTime.Now.Day), PlayerPrefs.GetInt("AlphaHour", DateTime.Now.Hour), PlayerPrefs.GetInt("AlphaMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("AlphaSecond", DateTime.Now.Second));
        if (dt > DateTime.Now)
            for (int i = 0; i < PlayerCube.transform.GetChild(0).GetComponent<Renderer>().materials.Length; i++)
            {
                Color c2l = PlayerCube.transform.GetChild(0).GetComponent<Renderer>().materials[i].color;
                c2l.a = PlayerPrefs.GetFloat("AlphaSliderValue", 1f);
                PlayerCube.transform.GetChild(0).GetComponent<Renderer>().materials[i].color = c2l;
            }*/


        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        AdRequest request = new AdRequest.Builder().AddTestDevice("E9B49A8F176A1A4ED5617820E22A42E2").Build();
        this.rewardBasedVideo.OnAdRewarded += OnAdRewardedVideo;
        this.rewardBasedVideo.OnAdFailedToLoad += OnAdLoadFailedVideo;
        this.rewardBasedVideo.OnAdLoaded += OnAdLoadedVideo;
        this.rewardBasedVideo.OnAdClosed += OnAdClosedVideo;
        this.rewardBasedVideo.LoadAd(request, GetMoneyVideo);

        this.rewardBasedAlpha = RewardBasedVideoAd.Instance;
        this.rewardBasedAlpha.OnAdRewarded += OnAdRewardedAlpha;
        this.rewardBasedAlpha.OnAdFailedToLoad += OnAdFailedLoadAlpha;
        this.rewardBasedAlpha.OnAdLoaded += OnAdLoadedAlpha;
        this.rewardBasedAlpha.OnAdClosed += OnAdClosedAlpha;
        this.rewardBasedAlpha.LoadAd(request, GetAlphaVideo);

        AdRequest request1 = new AdRequest.Builder().AddTestDevice("E9B49A8F176A1A4ED5617820E22A42E2").Build();
        BasedBanner = new BannerView(GetBanner, AdSize.Banner, AdPosition.Bottom);
        this.BasedBanner.OnAdClosed += OnAdClosedBanner;
        this.BasedBanner.OnAdFailedToLoad += OnAdFailedLoadBanner;
        this.BasedBanner.OnAdLoaded += OnAdLoadBanner;
        this.BasedBanner.LoadAd(request1);

        AfterFourLoseAd = new InterstitialAd(GetAfterFourLose);
        AfterFourLoseAd.OnAdClosed += OnAdClosedAFLAd;
        AfterFourLoseAd.LoadAd(request);

        AlphaCoroutine = StartCoroutine(AlphaWait());
    }

    Color GetQuestColor(int _number)
    {
        switch (_number)
        {
            case 4: return Color.red; 
            case 7: return Color.green; 
            case 14: return Color.blue;
            case 21: return Color.green;
            case 23: return Color.cyan;
            case 26: return Color.white;
            case 28: return Color.red;
            case 31: return Color.green;
            case 33: return Color.blue;
            case 36: return Color.black;
            case 38: return Color.blue;
            case 42: return Color.red;
            case 46: return Color.blue;
        }
        
        Debug.LogError("Out of colors in quest");
        return Color.clear;
    }

    public void SetNewColors()
    {
        PlayerCubeRenderers = PlayerCube.GetComponentsInChildren<Renderer>();
        List<int> _listcl = new List<int>();
        for (int i = 0; i < PlayerCubeRenderers.Length; i++)
        {
            for (int q = 0; q < PlayerCubeRenderers[i].materials.Length; q++)
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
        for (int i = 0; i < PlayerCubeRenderers.Length; i++)
        {
            for (int j = 0; j < PlayerCubeRenderers[i].materials.Length; j++)
            {
                PlayerCubeRenderers[i].materials[j].color = GetColorPlayer(_listcl[_tempcolor++]);
            }
        }
    }

    public Color GetColorPlayer(int _random = -1)
    {
        if (_random == -1)
            _random = UnityEngine.Random.Range(0, 10);
        switch (_random)
        {
            case 0: return Color.red;
            case 1: return Color.blue;
            case 2: return Color.black;
            case 3: return Color.white;
            case 4: return Color.grey;
            case 5: return Color.green;
            case 6: return Color.yellow;
            case 7: return Color.cyan;
            case 8: return Color.magenta;
            default: return Color.clear;
        }
    }

    public void AfterLose()
    {
        AFKAd();
        if (Save.NowQuest <= 50)
                QuestScript.QuestEx.text = Lang.Phrase("Quest") + " #" + Save.NowQuest.ToString() + ": " + QuestScript.GetQuestText(Save.NowQuest);
        else
            QuestScript.QuestEx.text = Lang.Phrase("Well, you complete all quests!");
        if (ClickNowType == 0)
        {
            Color cl;
            do
                cl = GetColorPlayer();
            while (cl == PlayerCubeRenderers[1].materials[0].color);
                cl.a = PlayerCubeRenderers[1].materials[0].color.a;
                PlayerCubeRenderers[1].materials[0].color = cl;
        }
        BackGround.SetActive(false);
        MainPanel.SetActive(true);
        ScoreText.transform.parent.gameObject.SetActive(true);
        CreateObjectsScript.AfterLose();
        Tunnel.GetComponent<Animator>().enabled = true;
        Camera.main.transform.position = new Vector3(0, -2.36f, -13.46f);
        Camera.main.GetComponent<Animator>().enabled = true;
        Tunnel.SetActive(false);
        PlayerCube.SetActive(false);
        Tunnel.SetActive(true);
        PlayerCube.SetActive(true);
        CubeRunScript.Score = 0;
        if (QuestScript.JustCheckColorQuest())
            SetNewColors();
        else
        {
            PlayerCubeRenderers = PlayerCube.GetComponentsInChildren<Renderer>();
            Color _cl = GetQuestColor(Save.NowQuest);
            for (int i = 0; i < PlayerCubeRenderers.Length; i++)
            {
                for (int j = 0; j < PlayerCubeRenderers[i].materials.Length; j++)
                {
                    PlayerCubeRenderers[i].materials[j].color = _cl;
                }
            }
        }
        foreach (Animator a in PlayerCybeAnimator)
        {
            if(a != null)
            a.enabled = true;
        }
        if (AlphaCoroutine != null)
            StopCoroutine(AlphaCoroutine);
        AlphaCoroutine = StartCoroutine(AlphaWait());
    }

    void Update()
    {
        if (Mode != 0 && Input.touchCount > 0 && Play)
            if (Mode == 1 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray _ray = Camera.main.ScreenPointToRay(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 0));
                CubeRunScript.Run(_ray.GetPoint(10));
            }
            else if (Mode == 2)
            {
                Ray _ray = Camera.main.ScreenPointToRay(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 0));
                CubeRunScript.Run(_ray.GetPoint(10));
            }
    }

    public IEnumerator AlphaWait()
    {
        DateTime dt = new DateTime(PlayerPrefs.GetInt("AlphaYear", DateTime.Now.Year), PlayerPrefs.GetInt("AlphaMonth", DateTime.Now.Month), PlayerPrefs.GetInt("AlphaDay", DateTime.Now.Day), PlayerPrefs.GetInt("AlphaHour", DateTime.Now.Hour), PlayerPrefs.GetInt("AlphaMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("AlphaSecond", DateTime.Now.Second));
        //DateTime dt = DateTime.Now.AddMinutes(1);
        if (dt > DateTime.Now)
        {
            foreach (Renderer r in PlayerCubeRenderers)
            {
                for (int i = 0; i < r.materials.Length; i++)
                {
                    Color cl = r.materials[i].color;
                    cl.a = PlayerPrefs.GetFloat("AlphaSliderValue", 1f);
                    r.materials[i].color = cl;
                }
            }

            AlphaBool = true;
            AlphaButton.transform.GetChild(0).gameObject.SetActive(true);
            while (dt > DateTime.Now)
            {
                AlphaButton.transform.GetChild(0).GetComponent<Text>().text = GetBeginZero((dt - DateTime.Now).Minutes) + ":" + GetBeginZero((dt - DateTime.Now).Seconds);
                yield return new WaitForSeconds(1f);
            }
        }
        
        if(dt < DateTime.Now)
        {
            foreach (Renderer r in PlayerCubeRenderers)
            {
                for (int i = 0; i < r.materials.Length; i++)
                {
                    Color cl = r.materials[i].color;
                    cl.a = 1;
                    r.materials[i].color = cl;
                }
            }

            AlphaBool = false;
            AlphaButton.transform.GetChild(0).GetComponent<Text>().gameObject.SetActive(false);
        }
    }

    public void ClickToPlay()
    {
        
        if (PlayerPrefs.GetInt("NowType", 0) == 8)
            RandomCubes = true;
        else
            RandomCubes = false;
        Mode = PlayerPrefs.GetInt("Mode", 0);
        if(AlphaCoroutine != null)
        StopCoroutine(AlphaCoroutine);
        Camera.main.GetComponent<Animator>().Play("CameraWhenStart");
        MainPanel.SetActive(false);
    }

    public void AfterClickToPlay()
    {
        Play = true;
        PlayerCube.GetComponent<Animator>().enabled = false;
        Tunnel.GetComponent<Animator>().enabled = false;
        Camera.main.GetComponent<Animator>().enabled = false;
        CubeRunScript.Speed = 8;
        CubeRunScript.RunBool = true;
        CubeRunScript.ScoreText.text = Lang.Phrase("Score") + ": 0";
        BackGround.SetActive(true);
        if (Mode == 0)
            EventCubes.SetActive(true);
        StartCoroutine(CreateObjectsScript.StartCreate());
    }

    string GetBeginZero(int INT)
    {
        if (INT < 10)
            return 0 + INT.ToString();
        else
            return INT.ToString();
    }

    bool ProverkaNaRandomLast(string _string)
    {
        string str = string.Empty;
        for (int i = 0; i < 10; i++)
        {
            str += _string[i];
        }
        return false;
    }

    void QuestionSett(string _title, string _yes, string _no, Action _act)
    {
        QuestionPanel.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = _title;
        QuestionPanel.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = _yes;
        QuestionPanel.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = _no;
        QuestionAction = _act;
        QuestionPanel.SetActive(true);
    }

    public void ClickQuestionYes()
    {
        QuestionPanel.SetActive(false);
        QuestionAction();
    }

    public void ClickQuestionNo()
    {
        QuestionPanel.SetActive(false);
    }

    #region VideoAd

    void OnAdLoadedVideo(object sender, System.EventArgs args)
    {
        ShopScript.BuySetButton.interactable = true;
    }

    void OnAdLoadFailedVideo(object sender, System.EventArgs args)
    {
        AdRequest _request = new AdRequest.Builder().AddTestDevice("E9B49A8F176A1A4ED5617820E22A42E2").Build();
        rewardBasedVideo.LoadAd(_request, GetMoneyVideo);
    }

    void OnAdClosedVideo(object sender, System.EventArgs args)
    {
        AdRequest _request = new AdRequest.Builder().AddTestDevice("E9B49A8F176A1A4ED5617820E22A42E2").Build();
        rewardBasedVideo.LoadAd(_request, GetMoneyVideo);
    }

    public void OnAdRewardedVideo(object sender, System.EventArgs args)
    {
        string _s = PlayerPrefs.GetString("ShopObjects", "TFFFFFFFFFFF");
        _s = _s.Remove(ClickNowType, 1);
        _s = _s.Insert(ClickNowType, "T");
        PlayerPrefs.SetString("ShopObjects", _s);
        ShopScript.BuySetText.text = Lang.Phrase("Set");
    }

    #endregion

    #region AlphaAd

    void OnAdFailedLoadAlpha(object sender, System.EventArgs args)
    {
        AdRequest _request = new AdRequest.Builder().AddTestDevice("E9B49A8F176A1A4ED5617820E22A42E2").Build();
        rewardBasedAlpha.LoadAd(_request, GetAlphaVideo);
    }

    void OnAdLoadedAlpha(object sender, System.EventArgs args)
    {

    }

    void OnAdClosedAlpha(object sender, System.EventArgs args)
    {
        AdRequest _request = new AdRequest.Builder().AddTestDevice("E9B49A8F176A1A4ED5617820E22A42E2").Build();
        rewardBasedAlpha.LoadAd(_request, GetAlphaVideo);
        if (AlphaVideoIsRewarded)
        {
            AlphaPanel.SetActive(false);
            MainPanel.SetActive(true);
        }
        AlphaVideoIsRewarded = false;
        StartCoroutine(AlphaScript.CheckLoadAd());
    }

    public void OnAdRewardedAlpha(object sender, System.EventArgs args)
    {
        if(AlphaCoroutine != null)
        StopCoroutine(AlphaCoroutine);
        DateTime _dt = DateTime.Now.AddMinutes(30);
        PlayerPrefs.SetInt("AlphaYear", _dt.Year);
        PlayerPrefs.SetInt("AlphaMonth", _dt.Month);
        PlayerPrefs.SetInt("AlphaDay", _dt.Day);
        PlayerPrefs.SetInt("AlphaHour", _dt.Hour);
        PlayerPrefs.SetInt("AlphaMinute", _dt.Minute);
        PlayerPrefs.SetInt("AlphaSecond", _dt.Second);
        AlphaVideoIsRewarded = true;
        AlphaCoroutine = StartCoroutine(AlphaWait());
    }

    #endregion

    #region BannerAd

    void OnAdFailedLoadBanner(object sender, System.EventArgs args)
    {
        Debug.Log("FAILED");
        QuestScript.QuestEx.text = args.ToString();
        AdRequest _request = new AdRequest.Builder().AddTestDevice("E9B49A8F176A1A4ED5617820E22A42E2").Build();
        BasedBanner.LoadAd(_request);
    }

    void OnAdLoadBanner(object sender, System.EventArgs args)
    {
        //BasedBanner.Show();
    }

    void OnAdClosedBanner(object sender, System.EventArgs args)
    {
        AdRequest _request = new AdRequest.Builder().AddTestDevice("E9B49A8F176A1A4ED5617820E22A42E2").Build();
        BasedBanner.LoadAd(_request);
    }

    #endregion

    #region AfterFourLoseAd

    void OnAdClosedAFLAd(object sender, System.EventArgs args)
    {
        AdRequest _request = new AdRequest.Builder().Build();
        AfterFourLoseAd.LoadAd(_request);
    }

    public void AFKAd()
    {
        if (CountLoseAd >= 4)
        {
            if (AfterFourLoseAd.IsLoaded())
            {
                CountLoseAd = 0;
                AfterFourLoseAd.Show();
            }
            else
            {
                AdRequest request = new AdRequest.Builder().Build();
                AfterFourLoseAd.LoadAd(request);
            }
        }
        else
        {
            CountLoseAd++;
        }
    }

    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha : MonoBehaviour {

    public Main MainScript;
    [Space]
    public Slider AlphaSlider;
    public Text AplhaSliderValueText;
    public Button SaveButton;
    private float BeginValue;

    public void StartAlpha()
    {
        gameObject.SetActive(true);
        MainScript.MainPanel.SetActive(false);
        Renderer[] rr = MainScript.PlayerCubeRenderers;
        BeginValue = rr[0].material.color.a;
        AlphaSlider.value = PlayerPrefs.GetFloat("AlphaSliderValue", 1f);
        AplhaSliderValueText.text = ((int)(AlphaSlider.value * 100)).ToString() + "%";
        StartCoroutine(CheckLoadAd());
    }

    public IEnumerator CheckLoadAd()
    {
        SaveButton.interactable = false;
        while (!MainScript.rewardBasedAlpha.IsLoaded())
        {
            yield return new WaitForFixedUpdate();
        }
        SaveButton.interactable = true;
    }

    public void ClickOnSave()
    {
        /*GameObject PlayerCube = MainScript.PlayerCube;
        MainScript.MainPanel.SetActive(true);
        if (PlayerCube.transform.childCount > 0)
            for (int i = 0; i < PlayerCube.transform.GetChild(0).GetComponent<Renderer>().materials.Length; i++)
            {
                Color cl = PlayerCube.transform.GetChild(0).GetComponent<Renderer>().materials[i].color;
                cl.a = AlphaSlider.value;
                PlayerCube.transform.GetChild(0).GetComponent<Renderer>().materials[i].color = cl;
            }
        else
        {
            Color cl = PlayerCube.transform.GetComponent<Renderer>().material.color;
            cl.a = AlphaSlider.value;
            PlayerCube.transform.GetComponent<Renderer>().material.color = cl;
        }*/
        PlayerPrefs.SetFloat("AlphaSliderValue", AlphaSlider.value);
#if UNITY_EDITOR
        MainScript.OnAdRewardedAlpha(new object(), new EventArgs());
#endif
        MainScript.rewardBasedAlpha.Show();
        //MainScript.OnAdRewardedAlpha(new object(), new System.EventArgs());
    }

    public void ChangeAlphaSlider()
    {
        DateTime dt = new DateTime(PlayerPrefs.GetInt("AlphaYear", DateTime.Now.Year), PlayerPrefs.GetInt("AlphaMonth", DateTime.Now.Month),
                                       PlayerPrefs.GetInt("AlphaDay", DateTime.Now.Day), PlayerPrefs.GetInt("AlphaHour", DateTime.Now.Hour),
                                       PlayerPrefs.GetInt("AlphaMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("AlphaSecond", DateTime.Now.Second));
        Debug.Log(MainScript.PlayerCubeRenderers.Length);
        foreach (Renderer r in MainScript.PlayerCubeRenderers)
        {
            for (int i = 0; i < r.materials.Length; i++)
            {
                Color cl = r.materials[i].color;
                cl.a = AlphaSlider.value;
                r.materials[i].color = cl;
            }
        }
        AplhaSliderValueText.text = ((int)(AlphaSlider.value * 100)).ToString() + "%";
    }

    public void ExitFromAlphaPanel()
    {
        /*Renderer rr = MainScript.PlayerCubeRenderer;
        DateTime dt = new DateTime(PlayerPrefs.GetInt("AlphaYear", DateTime.Now.Year), PlayerPrefs.GetInt("AlphaMonth", DateTime.Now.Month),
                                       PlayerPrefs.GetInt("AlphaDay", DateTime.Now.Day), PlayerPrefs.GetInt("AlphaHour", DateTime.Now.Hour),
                                       PlayerPrefs.GetInt("AlphaMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("AlphaSecond", DateTime.Now.Second));
        for (int i = 0; i < rr.materials.Length; i++)
        {
            Color cl = rr.materials[i].color;
            cl.a = dt > DateTime.Now ? BeginValue : 1f;
            rr.materials[i].color = cl;
        }*/
        
        DateTime dt = new DateTime(PlayerPrefs.GetInt("AlphaYear", DateTime.Now.Year), PlayerPrefs.GetInt("AlphaMonth", DateTime.Now.Month),
                                       PlayerPrefs.GetInt("AlphaDay", DateTime.Now.Day), PlayerPrefs.GetInt("AlphaHour", DateTime.Now.Hour),
                                       PlayerPrefs.GetInt("AlphaMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("AlphaSecond", DateTime.Now.Second));
        foreach (Renderer r in MainScript.PlayerCubeRenderers)
        {
            for (int i = 0; i < r.materials.Length; i++)
            {
                Color cl = r.materials[i].color;
                cl.a = dt > DateTime.Now ? BeginValue : 1f;
                r.materials[i].color = cl;
            }
        }
        GetComponent<Animator>().Play("CloseAlpha");
        MainScript.MainPanel.SetActive(true);
    }

    public void AfterAnimExit()
    {
        gameObject.SetActive(false);
    }
}

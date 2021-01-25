using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustCamera : MonoBehaviour {

    public Main MainScript;

    public void AfterAnim()
    {
        MainScript.AfterClickToPlay();
    }

    public void AfterAnimUnShop()
    {
        Camera.main.transform.position = new Vector3(0, -2.36f, -13.46f);
        Camera.main.transform.rotation = new Quaternion(0, 0, 0f, 100f);
        MainScript.MainPanel.SetActive(true);
        //Transform _go = MainScript.MainPanel.transform;
        //for (int i = 0; i < _go.transform.childCount; i++)
          // _go.GetChild(i).gameObject.SetActive(true);
       // MainScript.PlayerCube.SetActive(true);
        //MainScript.Tunnel.SetActive(true);
    }

    public void AfterAnimShop()
    {
        //Camera.main.transform.position = new Vector3 (7.28f, 1.65f, 0.8f);
       // Camera.main.transform.rotation = new Quaternion (0, 158.8148f, 0f, 100f);
        MainScript.ShopPanel.SetActive(true);
      //  MainScript.PlayerCube.SetActive(false);
      //  MainScript.Tunnel.SetActive(false);
    }
}

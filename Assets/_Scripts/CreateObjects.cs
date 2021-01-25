using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateObjects : MonoBehaviour {
	
	public List<Vector2> Vector2List = new List<Vector2>();
	private float distance;
	private Color cl;
	private Vector2 LastV2;
	public GameObject Cubes, FULL, JUSTTURNFULL;
	private int NowRandom;

	public CubeRun CubeRunScript;
	private int CountCreated;

	void Start () 
	{
		SetVector2List ();
		LastV2 = new Vector2 (0, 0);
		distance = 25;
	}

    public void AfterLose()
    {
        Start();
        CountCreated = 0;
        GameObject[] _gos = GameObject.FindGameObjectsWithTag("HamperHelper");

        foreach (GameObject _go in _gos)
        {
            if (_go.transform.childCount > 0)
                Destroy(_go);
        }
    }

    public IEnumerator StartCreate()
    {
        for (int i = 0; i < 5; i++)
        {
            CreateObjectsR();
            yield return new WaitForSeconds(0.1f);
        }
    }
	
	public void CreateObjectsR()
	{
		NowRandom = GetTypeToCreate ();
		CountCreated++;
		switch (NowRandom) 
		{
		case 0: CreateObjects0(); break;
		case 1: CreateObjects1(); break;
		case 2: CreateObjects2(); break;
		case 3: CreateObjects3(); break;
		default: CountCreated--; Debug.LogError("Count created >= 1500000"); break;
		}
	}

	int GetTypeToCreate()
	{
		if (CountCreated < 5)
			return 0;
		else if (CountCreated < 25) 
			return UnityEngine.Random.Range (0, 2);
		else if (CountCreated < 40)
			return UnityEngine.Random.Range (0, 3);
			return UnityEngine.Random.Range (0, 4);
	}


	#region NotTouch

	void SetVector2List()
	{
		Vector2List.Clear ();
		for (int i = -1; i < 2; i++) 
			for(int j = -1; j < 2; j++)
				Vector2List.Add(new Vector2(i, j));
	}

	int FindObjInChild(GameObject obj, Vector3 v3)
	{
		for (int i = 0; i < obj.transform.childCount; i++) 
		{
			if(obj.transform.GetChild(i).transform.position == v3)
				return i;
		}
		return 1;
	}

	void CreateObjects0()
	{
		cl = new Color(Random.Range(0.0f,1f),Random.Range(0.0f,1f),Random.Range(0.0f,1f));
		GameObject _FULL = Instantiate (FULL);
		_FULL.name = "FULL";
		_FULL.transform.position = new Vector3 (_FULL.transform.position.x, _FULL.transform.position.y, distance);
		{
			GameObject obj = Instantiate (Cubes);
			obj.transform.position = new Vector3 (LastV2.x, LastV2.y, distance);
			Vector2List.Remove (LastV2);
			obj.GetComponent<MeshRenderer> ().material.color = cl;
			obj.transform.SetParent (_FULL.transform);
		}
		
		for (int i = 0; i < 7; i++) {
			GameObject obj = Instantiate (Cubes);
			int rand = UnityEngine.Random.Range (0, Vector2List.Count);
			obj.transform.position = new Vector3 (Vector2List [rand].x, Vector2List [rand].y, distance);
			Vector2List.RemoveAt (rand);
			obj.GetComponent<MeshRenderer> ().material.color = cl;
			obj.transform.SetParent (_FULL.transform);
			obj.name = i.ToString () + NowRandom.ToString ();
		}
		LastV2 = Vector2List [0];
		distance += CubeRunScript.Speed != 0 ? CubeRunScript.Speed * 2 : 20;
		LastV2 = Vector2List [0];
		Vector2List.RemoveAt (0);
		SetVector2List ();
	}

	void CreateObjects1()
	{
		cl = new Color(Random.Range(0.0f,1f),Random.Range(0.0f,1f),Random.Range(0.0f,1f));
		GameObject _FULL = Instantiate (FULL);
		_FULL.name = "FULL";
		_FULL.transform.position = new Vector3 (_FULL.transform.position.x, _FULL.transform.position.y, distance);
		{
			GameObject obj = Instantiate (Cubes);
			obj.transform.position = new Vector3 (LastV2.x, LastV2.y, distance);
			Vector2List.Remove (LastV2);
			obj.GetComponent<MeshRenderer> ().material.color = cl;
			obj.transform.SetParent (_FULL.transform);
		}
		
		for (int i = 0; i < 7; i++) {
			GameObject obj = Instantiate (Cubes);
			int rand = UnityEngine.Random.Range (0, Vector2List.Count);
			obj.transform.position = new Vector3 (Vector2List [rand].x, Vector2List [rand].y, distance);
			Vector2List.RemoveAt (rand);
			obj.GetComponent<MeshRenderer> ().material.color = cl;
			obj.transform.SetParent (_FULL.transform);
			obj.name = i.ToString () + NowRandom.ToString ();
		}
		LastV2 = Vector2List [0];

		GameObject _JUSTTURNFULL = Instantiate (JUSTTURNFULL);
		_JUSTTURNFULL.transform.position = new Vector3 (_JUSTTURNFULL.transform.position.x, _JUSTTURNFULL.transform.position.y, distance - CubeRunScript.Speed / 1.5f);
		_JUSTTURNFULL.name = "C";
		_JUSTTURNFULL.GetComponent<EventCubesInNine> ().ToThisVector = LastV2;
		_JUSTTURNFULL.GetComponent<EventCubesInNine> ().NowRandom = 1;
		_FULL.transform.SetParent (_JUSTTURNFULL.transform);
		
		distance += CubeRunScript.Speed != 0 ? CubeRunScript.Speed * 2 : 20;
		LastV2 = Vector2List [0];
		Vector2List.RemoveAt (0);
		SetVector2List ();
	}

	void CreateObjects2()
	{
		cl = new Color(Random.Range(0.0f,1f),Random.Range(0.0f,1f),Random.Range(0.0f,1f));
		GameObject _FULL = Instantiate (FULL);
		_FULL.name = "FULL";
		_FULL.transform.position = new Vector3 (_FULL.transform.position.x, _FULL.transform.position.y, distance);
		
		for (int i = 0; i < 9; i++) {
			GameObject obj = Instantiate (Cubes);
			int rand = UnityEngine.Random.Range (0, Vector2List.Count);
			obj.transform.position = new Vector3 (Vector2List [rand].x, Vector2List [rand].y, distance);
			Vector2List.RemoveAt (rand);
			obj.GetComponent<MeshRenderer> ().material.color = cl;
			obj.transform.SetParent (_FULL.transform);
			obj.name = i.ToString () + NowRandom.ToString ();
		}
		
		GameObject _JUSTTURNFULL = Instantiate (JUSTTURNFULL);
		_JUSTTURNFULL.transform.position = new Vector3 (_JUSTTURNFULL.transform.position.x, _JUSTTURNFULL.transform.position.y, distance - CubeRunScript.Speed / 1.5f);
		_JUSTTURNFULL.name = "C";
		_JUSTTURNFULL.GetComponent<EventCubesInNine> ().NowRandom = 2;
		_FULL.transform.SetParent (_JUSTTURNFULL.transform);
		
		distance += CubeRunScript.Speed * 2;
		SetVector2List ();
	}

	void CreateObjects3()
	{
		cl = new Color(Random.Range(0.0f,1f),Random.Range(0.0f,1f),Random.Range(0.0f,1f));
		GameObject _FULL = Instantiate (FULL);
		_FULL.name = "FULL";
		_FULL.transform.position = new Vector3 (_FULL.transform.position.x, _FULL.transform.position.y, distance);
		
		for (int i = 0; i < 8; i++) {
			GameObject obj = Instantiate (Cubes);
			int rand = UnityEngine.Random.Range (0, Vector2List.Count);
			obj.transform.position = new Vector3 (Vector2List [rand].x, Vector2List [rand].y, distance);
			Vector2List.RemoveAt (rand);
			obj.GetComponent<MeshRenderer> ().material.color = cl;
			obj.transform.SetParent (_FULL.transform);
			obj.name = i.ToString () + NowRandom.ToString ();
		}
		_FULL.transform.GetChild (UnityEngine.Random.Range (0, _FULL.transform.childCount)).GetComponent<Renderer> ().material.color = new Color (cl.r, cl.g, cl.b, 0.0f);
		
		GameObject _JUSTTURNFULL = Instantiate (JUSTTURNFULL);
		_JUSTTURNFULL.transform.position = new Vector3 (_JUSTTURNFULL.transform.position.x, _JUSTTURNFULL.transform.position.y, distance - 3 - (CubeRunScript.Speed != 0 ? CubeRunScript.Speed / 2 : 5));
		_JUSTTURNFULL.name = "C";
		_JUSTTURNFULL.GetComponent<EventCubesInNine> ().NowRandom = 3;
		_FULL.transform.SetParent (_JUSTTURNFULL.transform);
		
		distance += CubeRunScript.Speed != 0 ? CubeRunScript.Speed * 2 : 20;
		SetVector2List ();
	}

	#endregion 



}

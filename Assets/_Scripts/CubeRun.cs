using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CubeRun : MonoBehaviour {

	[Header("Stats")]
	public float Speed = 8;
	public bool RunBool;

	[Header("BackGrounds")]
	public Text ScoreText;

	[Header("Other")]
	public Camera MainCameraR;
	public CreateObjects CreateObjectsScript;

	private Rigidbody rg;
	[SerializeField]
	public int Score;
	private bool ToC;
	private int LastCube;

	public Main MainScript;
	public GameObject Floor;
	public GameObject LoseObj;
	public Renderer PlayerCubeRenderer;
	void Start () {
		ScoreText.text = Lang.Phrase("Score") + ": " + Score.ToString ();
		LastCube = PlayerPrefs.GetInt ("NowType", 0);
		rg = GetComponent<Rigidbody> ();

	}

	void Update () {
		if (RunBool)
			Speed += 0.001f;
		else
			Speed = 0;
		if (transform.position.z > 10) 
		{
			Vector3 _v3 = Floor.transform.position;
			_v3.z = transform.position.z;
			Floor.transform.position = _v3;
		}
		if(MainScript.Play)
		MainCameraR.transform.position = new Vector3 (0, MainCameraR.transform.position.y, transform.position.z - 7.0f);
		rg.velocity = new Vector3 (0, 0, Speed);
	}

	void ChangeCubes()
    {
        if (MainScript.RandomCubes) {
			int rand;
			do
				rand = UnityEngine.Random.Range (1, 8); while(rand == LastCube);
			LastCube = rand;
			Destroy (transform.GetChild (0).gameObject);
			GameObject gm = Instantiate (Resources.Load<GameObject> (LastCube.ToString ()), transform.position, transform.rotation) as GameObject;
			gm.transform.SetParent (transform);
			if(MainScript.AlphaBool)
			{
                Renderer[] renderers = gm.GetComponentsInChildren<Renderer>();
                SetNewColorsRandom(renderers);
			}
		}
	}

    public void SetNewColorsRandom(Renderer[] renderers)
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
        float _value = PlayerPrefs.GetFloat("AlphaSliderValue");
        for (int i = 0; i < renderers.Length; i++)
        {
            for (int j = 0; j < renderers[i].materials.Length; j++)
            {
                Color _cl = MainScript.GetColorPlayer(_listcl[_tempcolor++]);
                _cl.a = MainScript.AlphaBool ? _value : 1;
                renderers[i].materials[j].color = _cl;
            }
        }
    }

    public void Run(float x, float y)
	{
		Vector3 _v3forRandom = transform.position;
		if ((Mathf.Abs (x)) > (Mathf.Abs (y)) && (Mathf.Abs (y)) < (PlayerPrefs.GetInt("EdgeArrow", 0) == 1 ? 3 : 100)) {
			if (x > 0)
				transform.position = new Vector3 (Mathf.Clamp(transform.position.x + 1,-1,1), Mathf.Clamp(transform.position.y,-1,1), transform.position.z);
			else if (x < 0)
				transform.position = new Vector3 (Mathf.Clamp(transform.position.x - 1,-1,1), Mathf.Clamp(transform.position.y,-1,1), transform.position.z);
					
		} else if ((Mathf.Abs (x)) < (Mathf.Abs (y)) && (Mathf.Abs (x)) < (PlayerPrefs.GetInt("EdgeArrow", 0) == 1 ? 3 : 100)) {
			if (y > 0)
				transform.position = new Vector3 (Mathf.Clamp(transform.position.x,-1,1), Mathf.Clamp(transform.position.y + 1,-1,1), transform.position.z);
			else
				transform.position = new Vector3 (Mathf.Clamp(transform.position.x,-1,1), Mathf.Clamp(transform.position.y - 1,-1,1), transform.position.z);
		} else
		{
			float deltaX, deltaY;
			if(y > 0)
				deltaY = 1;
			else deltaY = -1;

			if(x > 0)
				deltaX = 1;
			else deltaX = -1;

            transform.position = new Vector3 (Mathf.Clamp(transform.position.x + deltaX,-1,1), Mathf.Clamp(transform.position.y + deltaY,-1,1), transform.position.z);
		}
        if (transform.position != _v3forRandom)
        {
            ChangeCubes();
        }
    }

    public void Run(Vector3 v3)
    {
        Vector3 _v3 = transform.position;
		Vector2 v2 = v3 - _v3;
		Debug.Log (v2);
		switch((int)_v3.x+1)
		{
		case 0:
		if (v2.x < -0.5)
			v2.x = -1;
		else if (v2.x > 0.8)
			v2.x = 1;
		else
			v2.x = 0;
			break;
		case 1:
			if (v2.x < -0.5)
				v2.x = -1;
			else if (v2.x > 0.5)
				v2.x = 1;
			else
				v2.x = 0;
			break;
		case 2:
			if (v2.x < -0.8)
				v2.x = -1;
			else if (v2.x > 0.5)
				v2.x = 1;
			else
				v2.x = 0;
			break;
		
		}

		if (v2.y < -0.5)
			v2.y = -1;
		else if (v2.y > 0.5)
			v2.y = 1;
		else
			v2.y = 0;
		Vector3 newv  = new Vector3 (Mathf.Clamp(transform.position.x + v2.x,-1,1), Mathf.Clamp(transform.position.y + v2.y,-1,1), transform.position.z);
		if(newv != transform.position)
			ChangeCubes();
		transform.position = newv;
    }

	public void Run(GameObject Where)
	{
		Vector2 v2 = Vector2.zero;

		switch (Where.name [0])
		{
		case 'L': v2.x = -1; break;
		case 'M': v2.x = 0; break;
		case 'R': v2.x = 1; break;
		}

		switch (Where.name [1])
		{
		case 'D': v2.y = -1; break;
		case 'C': v2.y = 0; break;
		case 'U': v2.y = 1; break;
		}

		transform.position = new Vector3 (Mathf.Clamp(transform.position.x + v2.x,-1,1), Mathf.Clamp(transform.position.y + v2.y,-1,1), transform.position.z);
    }

	IEnumerator ToCenter()
	{
		int tmptimer = 0;
		while (tmptimer < 20 && !ToC) {
			tmptimer++;
			yield return new WaitForSeconds(0.1f);
		}
		ToC = false;
		transform.position = new Vector3 (0, 0, transform.position.z);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "FULL") {
			StartCoroutine (JustTransparent (other.gameObject));
			Score++;
			CreateObjectsScript.CreateObjectsR ();
			ScoreText.text = Lang.Phrase("Score") + ": " + Score.ToString ();
		} else if (other.tag == "Bonus") 
		{
			Destroy(other.gameObject);
			Save.PlusToHasCubes++;
		}
	}

    private void OnTriggerStay(Collider other)
    {
        
    }

    void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Hamper") 
		{
			LoseObj = other.gameObject;
            MainScript.LosePanel.GetComponent<Lose>().StartLose();
			RunBool = false;
		}
	}

//	void OnTriggerStay(Collider other)
//	{
//		if (other.name == "FULL") 
//		{
//			StartCoroutine(JustTransparent(other));
//		}
//	}

	IEnumerator JustTransparent(GameObject obj)
	{
		Color cl = obj.GetComponentInChildren<Renderer> ().material.color;
        obj.GetComponent<BoxCollider>().isTrigger = true;
        for(int i = 0; i < obj.transform.childCount; i++)
        obj.transform.GetChild(i).GetComponent<BoxCollider>().isTrigger = true;
        while (obj.GetComponentInChildren<Renderer>().material.color.a > 0.1)
        {
            cl.a -= 0.1f;
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                obj.transform.GetChild(i).GetComponent<Renderer>().material.color = cl;
            }
			yield return new WaitForSeconds(0.05f);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.name == "FULL") 
		{

				Destroy(other.gameObject.transform.root.gameObject, 2f);
		}
	}

}

using UnityEngine;
using System.Collections;

public class EventCubesInNine : MonoBehaviour {


	public CreateObjects CreateObjectsScript;
	public Vector2 ToThisVector;
	public int NowRandom;
	void Start () {
	
	}
	#region Turn to empty
	public void TurnCube()
	{
		Vector2 v2 = Vector2.zero;
		do
			v2 = UnityEngine.Random.Range(0,2) == 0 ? new Vector2 (ToThisVector.x, Mathf.Clamp (UnityEngine.Random.Range ((int)ToThisVector.y - 1, (int)ToThisVector.y + 2), -1, 1)) : 
				new Vector2 (Mathf.Clamp (UnityEngine.Random.Range ((int)ToThisVector.x - 1, (int)ToThisVector.x + 2), -1, 1), ToThisVector.y); 
		while(v2 == ToThisVector);
		for(int i = 0; i < transform.GetChild(0).childCount; i++)
		{
			Vector3 v3 = transform.GetChild(0).GetChild(i).transform.position;
			if(v3.x == v2.x && v3.y == v2.y)
			{
				StartCoroutine(TurnIE(transform.GetChild(0).GetChild(i).gameObject));
				break;
			}
		}
		               
	}

	Vector2 NotIdentifyVector(Vector2 v2)
	{
		if (v2.x == -1)
			v2.x = UnityEngine.Random.Range (0, 2);
		return v2;
	}

	IEnumerator TurnIE(GameObject obj)
	{
		Vector3 v3 = new Vector3 (ToThisVector.x, ToThisVector.y, obj.transform.position.z);

		while (obj.transform.position != v3) 
		{
			obj.transform.position = Vector3.MoveTowards(obj.transform.position, v3, 10 * Time.deltaTime);
			yield return new WaitForSeconds(0.02f);
		}
	}
	#endregion

	#region ToTransparent
	void JustPlayTransparent()
	{
		int tmp = UnityEngine.Random.Range (0, transform.GetChild (0).childCount);
		for (int i = 0; i < transform.GetChild(0).childCount; i++) 
		{
			if(tmp == i)//transform.GetChild(0).GetChild(i).name == "ThisGoTransparent")
			{
				StartCoroutine(JustTransparent(transform.GetChild(0).GetChild(i).gameObject));
				break;
			}
		}
	}

	IEnumerator JustTransparent(GameObject obj)
	{
		while (obj.GetComponent<Renderer>().material.color.a > 0.01f) 
		{
			obj.GetComponent<Renderer>().material.color = new Color(obj.GetComponent<Renderer>().material.color.r, obj.GetComponent<Renderer>().material.color.g, obj.GetComponent<Renderer>().material.color.b, obj.GetComponent<Renderer>().material.color.a - 0.1f);
			yield return new WaitForSeconds(0.01f);
		}
		obj.GetComponent<BoxCollider> ().isTrigger = true;
	}

	#endregion

	void CheckOnZeroAlpha()
	{
		for (int i = 0; i < transform.GetChild(0).childCount; i++) 
		{
			if(transform.GetChild(0).GetChild(i).GetComponent<Renderer>().material.color.a < 0.01)
			{
				StartCoroutine(SetFullAplha(transform.GetChild(0).GetChild(i).gameObject));
				break;
			}
		}
	}

	IEnumerator SetFullAplha(GameObject obj)
	{
		Color cl = obj.GetComponent<Renderer> ().material.color;
		while (obj.GetComponent<Renderer>().material.color.a < 0.9) 
		{
			obj.GetComponent<Renderer>().material.color = new Color(cl.r, cl.g, cl.b, obj.GetComponent<Renderer>().material.color.a + 0.1f);
			yield return new WaitForSeconds(0.1f);
		}	
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.name == "CubeP"	) {
			switch(NowRandom)
			{
				case 1: TurnCube (); break;
				case 2: JustPlayTransparent (); break;
				case 3: CheckOnZeroAlpha (); break;
			}
		}
		
	}
}

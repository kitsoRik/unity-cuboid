using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRoll : MonoBehaviour {

    bool Roll = false;
    Vector3 MouseClick;
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.transform.tag == "ShopObject")
                {
                    float _x = (transform.position - Camera.main.transform.position).x;
                    Roll = true;
                    MouseClick = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(_x);
                    MouseClick.z = 0;
                    MouseClick.y = 0;
                }
            }
        }
        else if (Input.GetMouseButton(0) && Roll)
        {
            float _x = (transform.position - Camera.main.transform.position).x;
            Vector3 _v3 = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(_x);
            _v3.z = 0;
            _v3.y = 0;
            Vector3 v3 = transform.position;
            v3 += _v3 - MouseClick;
            v3.x = Mathf.Clamp(v3.x, 16, 23);
            transform.position = v3;
            MouseClick = _v3;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Roll = false;
        }
	}
}

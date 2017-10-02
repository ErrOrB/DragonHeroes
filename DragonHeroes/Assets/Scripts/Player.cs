using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float tMoveSpeed = 5.0f;

	void Start () {
		
	}
	
	void Update () {

        float tInputX = (Input.GetAxis("Horizontal"));
        float tInputY = (Input.GetAxis("Vertical"));

        float tMoveX = tInputX * tMoveSpeed * Time.deltaTime;
        float tMoveY = tInputY * tMoveSpeed * Time.deltaTime;

        transform.Translate(tMoveX, tMoveY, 0);

	}
}

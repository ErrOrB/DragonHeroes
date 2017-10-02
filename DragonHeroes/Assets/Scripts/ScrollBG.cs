using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour {

    private float tSpeed;
    private float startPos;
    private float endPos;

    void Start()
    {
        tSpeed = 1.0f;
        startPos = 19.75f;
        endPos = -13.0f;
    }

    void Update () {

        this.transform.Translate(0, -1 * tSpeed * Time.deltaTime, 0);

        if (this.transform.position.y <= endPos)
            ScrollEnd();

	}

    private void ScrollEnd()
    {
        this.transform.Translate(0, startPos - endPos, 0, 0);
        //Debug.Log("ScroolEnd");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableIncident : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
}

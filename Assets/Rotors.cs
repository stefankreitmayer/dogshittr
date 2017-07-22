using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotors : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.forward, Random.Range(20.0f, 40.0f));
		
	}
}

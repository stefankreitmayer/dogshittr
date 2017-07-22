using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropper : MonoBehaviour {

    public float minimumTime = 2.0f;
    public float maximimTime = 5.0f;
    public GameObject item;

    private float timer;

	// Use this for initialization
	void Start ()
    {
        timer = Random.Range(minimumTime, maximimTime);
    }

    // Update is called once per frame
    void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = Random.Range(minimumTime, maximimTime);

            /*var drop =*/ GameObject.Instantiate(item, transform.position, Quaternion.identity);        
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fetcher : MonoBehaviour
{
    private Animator anim;

    private float phase = 0;
    public float speed = 0.2f;

    private GameObject target;

    private Vector2 home;

    public enum State
    {
        READY,
        APPROACH,
        PICKUP,
        RETURN,
        DONE
    }

    private State state = State.READY;
	
    // Use this for initialization
	void Start ()
    {
        home = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (phase >= 1)
        {
            phase = 0;
            if (state != State.DONE)
            {
                state++;
            }
        }

        switch (state)
        {
            case State.APPROACH:
                {
                    if (phase == 0) anim.Play("Hover");

                    phase += speed * Time.deltaTime;
                    float curvedPhase = Mathf.Cos(phase * Mathf.PI) / -2f + .5f;
                    transform.position = Vector2.Lerp(home, target.transform.position, curvedPhase);
                    break;
                }

            case State.PICKUP:
                {
                    if (phase == 0) anim.Play("pickup");
                    phase += Time.deltaTime;
                    target.transform.SetParent(transform);
                    break;  
                }

            case State.RETURN:
                {
                    if (phase == 0) anim.Play("hover");
                    phase += speed * Time.deltaTime;
                    float curvedPhase = Mathf.Cos(phase * Mathf.PI) / -2f + .5f;
                    transform.position = Vector2.Lerp(home, target.transform.position, curvedPhase);
                    break;
                }
    }
}

    public void Fetch(GameObject target)
    {
        this.target = target;
        state = State.APPROACH;
        phase = 0;
    }
}

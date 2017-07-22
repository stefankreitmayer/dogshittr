using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fetcher : MonoBehaviour
{
    private Animator anim;
    private Transform hull;

    private float phase = 0;
    public float speed = 0.2f;

    private GameObject target;

    private Vector2 home;
    private Vector2 touchdown;

    public enum State
    {
        APPROACH,
        LAND,
        PICKUP,
        RETURN,
        READY
    }

    public State state = State.READY;
	
    // Use this for initialization
	void Start ()
    {
        home = transform.position;
        anim = GetComponent<Animator>();
        hull = transform.GetChild(0);
    }

    void DepositPoop()
    {
        GameObject.Destroy(target);
        target = null;

        //TODO: Sound and Score
    }


    // Update is called once per frame
    void Update ()
    {
        if (phase >= 1)
        {
            if (state == State.RETURN)
            {
                DepositPoop();
            }

            phase = 0;
            if (state != State.READY)
            {
                state++;
            }
        }

        switch (state)
        {
            case State.APPROACH:
                {
                    if (phase == 0) anim.SetTrigger("hover");

                    phase += speed * Time.deltaTime;
                    float curvedPhase = Mathf.Cos(phase * Mathf.PI) / -2f + .5f;
                    transform.position = Vector2.Lerp(home, touchdown, curvedPhase);
                    break;
                }

            case State.LAND:
                {
                    if (phase == 0) anim.SetTrigger("land");
                    phase += Time.deltaTime;
                    break;
                }

            case State.PICKUP:
                {
                    if (phase == 0) anim.SetTrigger("launch");
                    phase += Time.deltaTime / 2.0f;
                    target.transform.SetParent(hull);
                    break;
                }

            case State.RETURN:
                {
                    if (phase == 0) anim.SetTrigger("hover");
                    phase += speed * Time.deltaTime;
                    float curvedPhase = Mathf.Cos(phase * Mathf.PI) / -2f + .5f;
                    transform.position = Vector2.Lerp(touchdown, home, curvedPhase);
                    break;
                }
    }
}

    public void Fetch(GameObject target)
    {
        this.target = target;
        touchdown = target.transform.position;
        state = State.APPROACH;
        phase = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Newspaper : MonoBehaviour {

    public Sprite[] pages;

    private Queue<Sprite> pageQueue;
	// Use this for initialization
	void Start ()
    {
        pageQueue = new Queue<Sprite>(pages);
	}
	
	// Update is called once per frame
	public void FlipPage ()
    {
        if (pageQueue.Count > 0)
        {
            //TODO: SOUND
            GetComponent<Image>().sprite = pageQueue.Dequeue();
            GetComponent<Animator>().SetTrigger("News Again");
        }
        else
        {
            //TODO: Next Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }   
    }
}

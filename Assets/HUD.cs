﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public GameObject m_scoreInstance;
	public GameObject[] m_collectorStateInstance;

	// Use this for initialization
	void Start () {
		//SetScore(66);
		//SetFetcherState(0, Fetcher.State.APPROACH);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetScore(int score)
	{
		m_scoreInstance.GetComponent<Text>().text = "LV: " + score.ToString();
	}

	public void SetFetcherState(int index, Fetcher.State state)
	{
		var renderer = m_collectorStateInstance[index].GetComponent<Image>();
		
		switch (state)
		{

		case Fetcher.State.READY:
			renderer.color = Color.white;
			break;

		case Fetcher.State.APPROACH:
		case Fetcher.State.PICKUP:
		case Fetcher.State.LAND:
			renderer.color = Color.yellow;
			break;

		case Fetcher.State.RETURN:
			renderer.color = Color.green;
			break;

		default:
			renderer.color = Color.white;
			break;

		}
	}
}
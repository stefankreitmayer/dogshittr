using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollector : MonoBehaviour {

	public GameObject m_dronePrefab;
	public Fetcher instance;
	public GameObject m_state;
	public GameObject m_buy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		m_buy.SetActive(instance == null);
		m_state.SetActive(instance != null);

		if (instance != null)
		{
			var renderer = GetComponent<Image>();

			switch (instance.state)
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

	public void SpawnDrone()
	{
		var hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
		hud.AddScore(-100);

		var radians = Random.Range(0.0f, 2 * Mathf.PI);
		var drone = GameObject.Instantiate(m_dronePrefab, new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * Camera.main.orthographicSize * 2.0f, Quaternion.identity);
		instance = drone.GetComponent<Fetcher>();
        instance.collectorUI = this;
	}
}

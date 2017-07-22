using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableIncident : MonoBehaviour {

	public GameObject m_screen;
	private GameObject m_screenInstance;

	// Use this for initialization
	void Start()
	{
	}

	void Destroy()
	{
		if (m_screenInstance != null)
		{
			var ui = m_screenInstance.GetComponent<ShittrUI>();
			ui.OnAccepted -= OnUIAccepted;
			ui.OnRejected -= OnUIRejected;
		}
	}

	void OnMouseDown()
	{
		m_screenInstance = GameObject.Instantiate(m_screen);
		var ui = m_screenInstance.GetComponent<ShittrUI>();
		ui.OnAccepted += OnUIAccepted;
		ui.OnRejected += OnUIRejected;
	}

	// Update is called once per frame
	void Update()
	{
	}

	private void OnUIAccepted(object sender, System.EventArgs e)
	{
		Debug.Log("Accepted!");

		Destroy(m_screenInstance);
	}

	private void OnUIRejected(object sender, System.EventArgs e)
	{
		Debug.Log("Accepted!");

		Destroy(m_screenInstance);
	}
}

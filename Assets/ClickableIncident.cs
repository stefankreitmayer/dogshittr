﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableIncident : MonoBehaviour {

	public GameObject m_screen;
	public Sprite m_spritePoop;
	public Sprite m_spriteNotPoop;

	public static bool s_IsScreenOpen = false;

	private GameObject m_screenInstance;
	private SpriteRenderer m_renderer;
	private ShittrUI m_ui;
	private bool m_decided = false;
	private bool m_isCorrect = false;

	// Use this for initialization
	void Start()
	{
		m_renderer = GetComponent<SpriteRenderer>();
	}

	void Destroy()
	{
		CloseScreen();
	}

	void OnMouseDown()
	{
		if (!m_decided &&
			!s_IsScreenOpen)
		{
			m_screenInstance = GameObject.Instantiate(m_screen);
			m_ui = m_screenInstance.GetComponent<ShittrUI>();
			m_ui.OnAccepted += OnUIAccepted;
			m_ui.OnRejected += OnUIRejected;

			m_decided = true;
			s_IsScreenOpen = true;
		}
	}

	// Update is called once per frame
	void Update()
	{
	}

	private void OnUIAccepted(object sender, System.EventArgs e)
	{
		Debug.Log("Accepted!");

		m_renderer.sprite = m_spritePoop;
		m_isCorrect = m_ui.m_isPoop;

		CloseScreen();
	}

	private void OnUIRejected(object sender, System.EventArgs e)
	{
		Debug.Log("Rejected!");

		m_renderer.sprite = m_spriteNotPoop;
		m_isCorrect = !m_ui.m_isPoop;

		CloseScreen();
	}

	private void CloseScreen()
	{
		if (m_screenInstance == null)
		{
			return;
		}

		m_ui.OnAccepted -= OnUIAccepted;
		m_ui.OnRejected -= OnUIRejected;
		m_ui = null;

		Destroy(m_screenInstance);
		m_screenInstance = null;

		s_IsScreenOpen = false;
	}
}

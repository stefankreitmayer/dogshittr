using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShittrUI : MonoBehaviour {

	public Sprite[] m_poopSprites;
	public Sprite[] m_notPoopsprites;
	public GameObject m_poopImage;
	public bool m_isPoop;

	public delegate void ResultHandler(object sender, System.EventArgs e);
	public event ResultHandler OnAccepted;
	public event ResultHandler OnRejected;

	void Start()
	{
		PickPoop();
	}

	void Update()
	{

	}

	public void PickPoop()
	{
		m_isPoop = Random.Range(0.0f, 100.0f) >= 50.0f;
		if (m_isPoop)
		{
			int index = Random.Range(0, m_poopSprites.Length);
			m_poopImage.GetComponent<Image>().sprite = m_poopSprites[index];
		}
		else
		{
			int index = Random.Range(0, m_notPoopsprites.Length);
			m_poopImage.GetComponent<Image>().sprite = m_notPoopsprites[index];
		}
	}

	public void onAcceptClicked()
	{
		// PickPoop();

		if (OnAccepted != null)
		{
			OnAccepted(null, null);
		}
	}

	public void onRejectClicked()
	{
		if (OnRejected != null)
		{
			OnRejected(null, null);
		}
	}

}

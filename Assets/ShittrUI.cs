using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShittrUI : MonoBehaviour {

	public Sprite[] m_poopSprites;
	public Sprite[] m_notPoopsprites;
	public GameObject m_poopImage;

	private bool m_isPoop;

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
		Debug.Log("poop " + m_isPoop);

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
		Debug.Log("Accepted!");

		PickPoop();
	}

	public void onRejectClicked()
	{
		Debug.Log("Rejected!");
	}

}
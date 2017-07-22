using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShittrUI : MonoBehaviour {

	public Sprite[] m_sprites;
	public GameObject m_poopImage;

	void Start()
	{
		PickPoop();
	}

	void Update()
	{
	}

	public void PickPoop()
	{
		int index = Random.Range(0, m_sprites.Length);
		m_poopImage.GetComponent<Image>().sprite = m_sprites[index];
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
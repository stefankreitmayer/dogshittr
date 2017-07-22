using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveller : MonoBehaviour {	
	public float speed = 0.2f;
	public PathNode currentNode;

	private PathNode nextNode;
	private float phase = 0;

	void Start () {
		nextNode = currentNode.PickBranch(currentNode);
	}
	
	void Update () {
		phase += speed * Time.deltaTime;
		if (phase >= 1) {
			PathNode previousNode = currentNode;
			currentNode = nextNode;
			nextNode = currentNode.PickBranch(previousNode);
			phase = 0;
		} else {
			float curvedPhase = Mathf.Cos(phase * Mathf.PI) / -2f + .5f;
			transform.position = Vector2.Lerp(currentNode.transform.position, nextNode.transform.position, curvedPhase);
		}
	}
}

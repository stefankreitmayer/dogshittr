using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PathNode : MonoBehaviour {
	public PathNode[] branches;

	void OnDrawGizmos() {
		foreach (var branch in branches) {
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position, branch.transform.position);
		}
	}

	public PathNode PickBranch(){
		return branches[Random.Range(0, branches.Length-1)];
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PathNode : MonoBehaviour {
	public List<PathNode> branchList;

	void OnDrawGizmos() {
		foreach (var branch in branchList) {
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position, branch.transform.position);
		}
	}

	public PathNode PickBranch(PathNode previous){
		PathNode result;
		int trials = 10;// Avoid 180 degree turns if possible
		do {
			result = branchList [Random.Range (0, branchList.Count)];
			trials--;
		} while(result == previous && trials > 0);
		return result;
	}

	public void AddBacklinksRecursively(PathNode origin){
		if(!branchList.Contains(origin)){
			branchList.Add(origin);
			List<PathNode> copy = new List<PathNode>(branchList);
			foreach (var branch in copy) {
				branch.AddBacklinksRecursively (this);
			}
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathNode : MonoBehaviour
{
    public List<PathNode> branchList;

    private void Start()
    {
        foreach (var node in branchList)
        {
            if (!node.branchList.Contains(this))
            {
                node.branchList.Add(this);
            }
        }
    }



    public PathNode PickBranch(PathNode previous)
    {
        PathNode result;
        int trials = 10;// Avoid 180 degree turns if possible
        do
        {
            result = branchList[Random.Range(0, branchList.Count)];
            trials--;
        } while (result == previous && trials > 0);
        return result;
    }
}
using UnityEngine;
using System.Collections;

public class Edge
{
	public Node startNode;
	public Node endNode;
    public float edgeCost;
	
	public Edge(Node from, Node to, float cost)
	{
		startNode = from;
		endNode = to;
        edgeCost = cost;
	}
}

using UnityEngine;
using System.Collections;

public class Edge
{
	public Node startNode;
	public Node endNode;
    public float utilityValue;
	
	public Edge(Node from, Node to, float uv)
	{
		startNode = from;
		endNode = to;
        utilityValue = uv;                            //cost is to account for slower roads (and not just base routing on distance)
	}
}

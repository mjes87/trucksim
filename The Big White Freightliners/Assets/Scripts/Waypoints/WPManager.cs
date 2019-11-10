using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction { UNI, Bi };
    public GameObject node1;
    public GameObject node2;
    public direction dir;
    public float cost;
}

public class WPManager : MonoBehaviour
{
    //    public GameObject[] waypoints;
    [HideInInspector] public List<GameObject> waypoints;
    [HideInInspector] public List<Link> links;
    public Graph graph = new Graph();

    // Start is called before the first frame update
    void Start()
    {
        waypoints.AddRange(GameObject.FindGameObjectsWithTag("City"));          //simplify level design by autobuilding our waypoint and links list
        waypoints.AddRange(GameObject.FindGameObjectsWithTag("Junction"));

        GameObject[] hwys = GameObject.FindGameObjectsWithTag("Highway");

        foreach (GameObject hw in hwys)
        {
            Link tlnk;
            tlnk.dir = Link.direction.Bi;
            tlnk.node1 = hw.GetComponent<HighwayDetails>().startPoint;
            tlnk.node2 = hw.GetComponent<HighwayDetails>().endPoint;
            tlnk.cost = hw.GetComponent<HighwayDetails>().travelTime;

            links.Add(tlnk);
        }

        if (waypoints.Count > 0)
        {
            foreach(GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }
            foreach(Link l in links)
            {
                graph.AddEdge(l.node1, l.node2, l.cost);
                if(l.dir == Link.direction.Bi)
                {
                    graph.AddEdge(l.node2, l.node1, l.cost);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        graph.debugDraw();
        
    }
}

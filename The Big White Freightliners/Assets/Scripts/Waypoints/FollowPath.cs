using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public GameObject startupNode;
    public GameObject wpManager;

    public void SetSpeed(float spd) { speed = spd; }
    public float GetSpeed() { return speed; }

    Transform goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotSpeed = 20.0f;

    List<GameObject> wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = startupNode;        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (g == null)
        {
            return;
        }
        else if (g.getPathLength() == 0 || currentWP == g.getPathLength())
        {
            return;
        }

        currentNode = g.getPathPoint(currentWP);

        if (Vector3.Distance(g.getPathPoint(currentWP).transform.position,this.transform.position) < accuracy)
        {
            currentWP++;
        }

        if (currentWP < g.getPathLength())
        {
            goal = g.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void SetDestination (GameObject city)
    {
        if (city.CompareTag("City"))
        {
            g.AStar(currentNode, city);
            currentWP = 0;
            Debug.Log(city.name + " is now the destination (" + g.getPathLength() + ")");
            //g.printPath();
        }
    }

}

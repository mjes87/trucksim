using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayDetails : MonoBehaviour
{
    public string highwayName;
    public Transform startPoint;
    public Transform endPoint;

    // Start is called before the first frame update
    void Start()
    {
        //all of this is to have the highways align with their starting and endpoints (cities),
        //and scale them so they properly reach
        this.transform.position = startPoint.position;                                                                     //Set to the start position to get the proper facing direction to the end point
        this.transform.position = new Vector3(startPoint.position.x, startPoint.position.y - 0.2f, startPoint.position.z); //slightly drop the Y to not cover the city markers
        this.transform.LookAt(endPoint, Vector3.up);

        Vector3 cityScale = endPoint.position - startPoint.position;
        cityScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, cityScale.magnitude);
        this.transform.localScale = cityScale;

        this.transform.position = new Vector3((endPoint.position.x - startPoint.position.x) / 2 + startPoint.position.x,
                                               this.transform.position.y,
                                              (endPoint.position.z - startPoint.position.z) / 2 + startPoint.position.z);

        TextMesh nameMesh = this.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
        nameMesh.text = highwayName;
        nameMesh.transform.localScale = new Vector3(nameMesh.transform.localScale.x, nameMesh.transform.localScale.y, nameMesh.transform.localScale.z / cityScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

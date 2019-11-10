using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayDetails : MonoBehaviour
{
    public string highwayName = "???";
    public GameObject startPoint;
    public GameObject endPoint;
    public float travelTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //all of this is to have the highways align with their starting and endpoints (cities),
        //and scale them so they properly reach
        Transform stP = endPoint.transform; // startPoint.transform;                                    //for some reason my road names are being flipped upside down
        Transform enP = startPoint.transform;                                                           //so for now I'm reversing the start and end points to flip them back

        this.transform.position = stP.position;                                                         //Set to the start position to get the proper facing direction to the end point
        this.transform.LookAt(enP, Vector3.up);
        this.transform.position = new Vector3(stP.position.x, stP.position.y - 0.2f, stP.position.z);   //slightly drop the Y to not cover the city markers

        Vector3 cityScale = enP.position - stP.position;
        cityScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, cityScale.magnitude);
        this.transform.localScale = cityScale;

        this.transform.position = new Vector3((enP.position.x - stP.position.x) / 2 + stP.position.x,
                                               this.transform.position.y,
                                              (enP.position.z - stP.position.z) / 2 + stP.position.z);

        TextMesh nameMesh = this.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
        nameMesh.text = highwayName;
        nameMesh.transform.localScale = new Vector3(nameMesh.transform.localScale.x, nameMesh.transform.localScale.y, nameMesh.transform.localScale.z / cityScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

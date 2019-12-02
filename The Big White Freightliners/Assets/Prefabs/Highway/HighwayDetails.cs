using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayDetails : MonoBehaviour
{
    public string highwayName = "???";
    public GameObject startPoint;
    public GameObject endPoint;
    public float travelTime = 1.0f;

    private int lastHour;
    private int accidentRate = 48;
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

        Vector3 cityScale = enP.position - stP.position;                                                //find the (facing) distance between the two point and stretch the highway to reach them
        cityScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, cityScale.magnitude);
        this.transform.localScale = cityScale;

        this.transform.position = new Vector3((enP.position.x - stP.position.x) / 2 + stP.position.x,   //set the highway center point to between the two cities
                                               this.transform.position.y,
                                              (enP.position.z - stP.position.z) / 2 + stP.position.z);

        TextMesh nameMesh = this.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
        nameMesh.text = highwayName;                                                                    //try to make the highway name to not be stretched out by "descaling" it
        nameMesh.transform.localScale = new Vector3(nameMesh.transform.localScale.x, nameMesh.transform.localScale.y, nameMesh.transform.localScale.z / cityScale.z);

        lastHour = FindObjectOfType<GameTime>().GetHour();
    }

    // Update is called once per frame
    void Update()
    {
        int hr = FindObjectOfType<GameTime>().GetHour();
        if (lastHour != hr)                                                             //every hour check for an accident
        {
            lastHour = hr;

            if (Random.Range(0, accidentRate) == 0)
            {
                GameObject acdnt = Instantiate(GameObject.Find("Accident").gameObject) as GameObject;
                acdnt.transform.parent = this.gameObject.transform;
                acdnt.transform.position = this.transform.position;
                acdnt.transform.position = new Vector3(this.transform.position.x,           //place the accident anywhere along the length of the highway
                                                       this.transform.position.y + 0.2f,
                                                       this.transform.position.z + Random.Range(-(this.transform.localScale.z / 2.0f), (this.transform.localScale.z / 2.0f)));

                acdnt.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}

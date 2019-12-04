using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckControl : MonoBehaviour
{

    private bool inTown = false;
    private bool onTheRoad = false;

    GameObject lastSpeedSetter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /************************************************************************************
        OnTriggerEnter

        In this event we determine if the truck is in contact with a road or a city for calculting
        a Truck's speed. City traffic calculations take priority over high traffic issues.

        if in a city, the speed is caclulated for what is required to cross it's diameter
        in the cities specified "travel time" (game time in hours)

        if on the highway, the same calculation is made using the highways z scale;
        which is effectively the length of the highway.

        TODO: add detection for accident and construction markers, with corresponding 
        delay calculation

    ************************************************************************************/        
    private void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.CompareTag("CityLimits")) && (!inTown))
        {
            Debug.Log("We are here!");
            inTown = true;
            float tT = col.gameObject.GetComponentInParent<CityDetails>().travelTime;
            //float cZ = col.gameObject.GetComponent<CapsuleCollider>().radius * 2.0f;
            float cZ = col.gameObject.transform.localScale.z; // * 2.0f;
            float spd = cZ / tT;
            float nspd = FindObjectOfType<GameTime>().FindMySpeed(spd);
            this.gameObject.GetComponent<FollowPath>().SetSpeed(nspd);
            lastSpeedSetter = col.gameObject;

            Debug.Log(tT + " " + cZ + " " + spd + " becomes " + nspd);
        }
    }

    private void OnTriggerStay(Collider col)
    {

        if (col.gameObject.CompareTag("Highway") && (!inTown) && (col.gameObject != lastSpeedSetter))
        {
            Debug.Log("On the Highway " + col.gameObject.name);
            onTheRoad = true;
            float tT = col.gameObject.GetComponentInParent<HighwayDetails>().travelTime;
            float cZ = col.gameObject.transform.localScale.z;
            float spd = cZ / tT;
            float nspd = FindObjectOfType<GameTime>().FindMySpeed(spd);
            this.gameObject.GetComponent<FollowPath>().SetSpeed(nspd);
            lastSpeedSetter = col.gameObject;

            Debug.Log(tT + " " + cZ + " " + spd + " becomes " + nspd);
        }
    }
    private void OnTriggerExit(Collider col)
    {

        if (col.gameObject.CompareTag("CityLimits"))
        {
            inTown = false;

        }
        else if (col.gameObject.CompareTag("Highway"))
        {
            onTheRoad = false;
        }
        Debug.Log("Exiting " + col.gameObject.name);

    }
}

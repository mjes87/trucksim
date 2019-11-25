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

    private void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.CompareTag("CityLimits")) && (!inTown))
        {
            Debug.Log("We are here!");
            inTown = true;
            float tT = col.gameObject.GetComponentInParent<CityDetails>().travelTime;
            float cZ = col.gameObject.GetComponent<CapsuleCollider>().radius * 2.0f;
            float spd = cZ / tT;
            float nspd = FindObjectOfType<GameTime>().FindMySpeed(spd);
            this.gameObject.GetComponent<FollowPath>().SetSpeed(nspd);
            lastSpeedSetter = col.gameObject;

            Debug.Log(tT + " " + cZ + " " + spd + " becomes " + nspd);
        }
/*        else if ((col.gameObject.CompareTag("Highway")) && (!onTheRoad) && (!inTown))
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
  */     
    }

    private void OnTriggerStay(Collider col)
    {
        if ((!inTown) && (col.gameObject != lastSpeedSetter))
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

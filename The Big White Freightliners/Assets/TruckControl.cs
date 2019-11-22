using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckControl : MonoBehaviour
{

    private bool inTown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("City"))
        {
            inTown = true;
        }
        
    }
    private void OnCollisionExit(Collision col)
    {
        Debug.Log("We are here!");
        if (col.gameObject.CompareTag("City"))
        {
            inTown = false;
            float spd = col.gameObject.transform.localScale.z / col.gameObject.GetComponent<CityDetails>().travelTime;
            float nspd = FindObjectOfType<GameTime>().FindMySpeed(spd);
            this.gameObject.GetComponent<FollowPath>().SetSpeed(nspd);

            Debug.Log(spd + " becomes " + nspd);

        }

    }
}

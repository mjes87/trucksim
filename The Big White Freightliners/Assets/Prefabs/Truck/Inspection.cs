using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspection : MonoBehaviour
{

    private int hourlyRate = 96;
    private float HourlyDuration = 0.5f;
    private int lastHour;
    private float waitTime;
    private bool beingInspected;

    const int NORMISNPECTION = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!beingInspected)
        {
            int hr = FindObjectOfType<GameTime>().GetHour();
            if (lastHour != hr)                                                             //every hour check for an accident
            {
                lastHour = hr;

                if (Random.Range(0, hourlyRate) == 0)
                {
                    GameObject inspect = Instantiate(GameObject.Find("Inspector").gameObject) as GameObject;
                    inspect.transform.position = this.gameObject.transform.position;
                    inspect.GetComponent<MeshRenderer>().enabled = true;
                }

            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspection : MonoBehaviour
{

    public AudioClip inspect;
    public AudioClip truckLeaves;

    private int hourlyRate =5; //96;
    private float hourlyDuration = 0.5f;
    private int lastHour;
    private float waitTime;
    private bool beingInspected = false;
    private bool onTheRoad = false;
    private float lastSpeed;
    private GameObject inspector;
    private AudioSource audioSource;

    private IEnumerator coroutine;

    const int NORMINSPECTION = 7;
    const int LOGCHECKINSPECTION = 9;
    const int FULLINSPECTION = 10;

    // Start is called before the first frame update
    void Start()
    {
        lastHour = FindObjectOfType<GameTime>().GetHour() - 1;
        audioSource = this.GetComponent<AudioSource>();
        //audioSource = FindObjectOfType<SoundManager>().GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //onTheRoad = this.GetComponent<TruckControl>().onTheRoad;
        if ((!beingInspected)) // && (onTheRoad))
        {
            int hr = FindObjectOfType<GameTime>().GetHour();
            if (lastHour != hr)                                                             //every hour check for an accident
            {
                lastHour = hr;

                if (Random.Range(0, hourlyRate) == 0)
                {
                    beingInspected = true;
                    inspector = Instantiate(GameObject.Find("Inspector").gameObject) as GameObject;
                    inspector.transform.position = this.gameObject.transform.position;
                    inspector.GetComponent<MeshRenderer>().enabled = true;

                    int inspecttype = Random.Range(0, FULLINSPECTION);
                    if (inspecttype < NORMINSPECTION)
                    {
                        waitTime = FindObjectOfType<GameTime>().gmHoursToRealSeconds(hourlyDuration);
                    }
                    else if (inspecttype < LOGCHECKINSPECTION)
                    {
                        waitTime = FindObjectOfType<GameTime>().gmHoursToRealSeconds(hourlyDuration * 2.0f);
                    }
                    else
                    {
                        waitTime = FindObjectOfType<GameTime>().gmHoursToRealSeconds(hourlyDuration * 4.0f);
                    }
                    Debug.Log("Inspection Time: " + waitTime);
                    //SoundManager.instance.PlayOneShot(SoundManager.instance.scaleStation);
                    audioSource.PlayOneShot(inspect);

                    lastSpeed = this.gameObject.GetComponent<FollowPath>().GetSpeed();
                    this.gameObject.GetComponent<FollowPath>().SetSpeed(0.0f);
                    coroutine = InspectionWait(waitTime, lastSpeed);
                    StartCoroutine(coroutine);
                }
            }
        }
    }

    private IEnumerator InspectionWait(float wt, float spd)
    {
        yield return new WaitForSeconds(wt);
        this.gameObject.GetComponent<FollowPath>().SetSpeed(spd);
        Destroy(inspector);
        //SoundManager.instance.PlayOneShot(SoundManager.instance.truckLeaves);
        audioSource.PlayOneShot(truckLeaves);
        beingInspected = false;
    }
}

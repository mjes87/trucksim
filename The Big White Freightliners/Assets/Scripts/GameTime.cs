using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public static GameTime instance = null;

    public Text timeText;

    [HideInInspector] static public DateTime gmTime;

    private static float gmTimeScale = 1.0f;             //base time scale is 1 minute Real Time = 1 hour Game Time (A good playerPref candidate)

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gmTime = System.DateTime.Now;                      //initialize with real time for now, but this should have a check for a save and restore to that

        if (PlayerPrefs.HasKey("TimeScale"))
        {
            gmTimeScale = PlayerPrefs.GetFloat("TimeScale");
        }
        else
        {
            PlayerPrefs.SetFloat("TimeScale", gmTimeScale);
            PlayerPrefs.Save();
        }
        InvokeRepeating("TimeTick", 1.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = gmTime.ToShortDateString() + "  " + gmTime.ToShortTimeString();
    }

    /************************************************************
        TimeTick

        This method is designed to repeat every second and 
        increment out Game "Minutes of the day". 

        By adding gmTimeScale, our orignal time ratio of 1hr/1m
        is automatically scaled

    *************************************************************/
    void TimeTick()
    {
        gmTime = gmTime.AddMinutes(1.0f);                           //yes this is how it works

    }

    /***********************************************************
        UpdateTimeScale

        method for game and user changing of the time scale
        also takes care of saving the scale when flagged that
        it is a user saveable time change
        (in case their are game states that can change this)

    ************************************************************/
    void UpdateTimeScale(float newscale, bool svit)
    {
        if ((newscale >= 0.1f) && (newscale <= 10.0f))
        {
            gmTimeScale = newscale;
            if (svit)
            {
                PlayerPrefs.SetFloat("TimeScale", gmTimeScale);
                PlayerPrefs.Save();
            }
        }
    }

    /*************************************************************
        FindMySpeed

        This method takes in a speed of Unity units per hour
        (basically a road/city's Z-scale divided by its travelTime)

        It then converts it to minutes
        then to real seconds with gmScaleTime
        This gives us the real time seconds to cross the city
        when we invert that we now a Unity units per real Time
        which is the normal speed value we use when in our normal
        ...Translate( , , speed*Time.deltaTime) 

    ***************************************************************/
    public float FindMySpeed (float untph)
    {
        return (1.0f / (untph * 60 / gmTimeScale));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CityDetails : MonoBehaviour
{
    public enum CitySizes
    {
        SMALL = 1,
        MEDIUM,
        LARGE,
        METROPOLIS
    }

    //public string cityName = "City ?";
    public CitySizes citySize = CitySizes.LARGE;
    public int timeZone = 0;
    public Color[] trafficColors = { Color.green, Color.yellow, Color.red + Color.green / 3 };

    [HideInInspector] public float travelTime;          //time to cross the city in hours (will be scaled by road, traffic, and weather conditions)

    private FollowPath pathMaker;
    private Renderer cityAreaRenderer;
    private int lastHour = -1;

    // Start is called before the first frame update
    void Awake()
    {
        TextMesh nameMesh = this.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
        nameMesh.text = this.name;

        this.transform.localScale = new Vector3(((int)citySize) / 2.0f, ((int)citySize) / 2.0f, ((int)citySize) / 2.0f);

        GameObject go = GameObject.FindWithTag("Truck");
        pathMaker = (FollowPath)go.GetComponent(typeof(FollowPath));

        GameObject cityArea = this.gameObject.transform.Find("CityArea").gameObject;
        cityAreaRenderer = cityArea.GetComponent<Renderer>();
        cityAreaRenderer.material.color = trafficColors[(int)CityTrafficLevels.LIGHT];
        travelTime = (int)citySize * 10.0f / 60.0f;                                     //set the time to cross a city starting at 10 minutes per city size (adjusted for traffic level)
    }

    // Update is called once per frame
    void Update()
    {
        int hr = FindObjectOfType<GameTime>().GetHour() - timeZone;

        if (hr != lastHour)                                                 //I hate the idea of doing this 60x a second when it only rarely changes
        {
            lastHour = hr;
            CityTrafficLevels tl = CityTrafficLevels.LIGHT;

            if (((hr >= 7) && (hr <= 9)) || ((hr >= 16) && (hr <= 18)))            //set up time bands for rush hour
            {
                if ((hr == 8) || (hr == 17))
                {
                    tl = CityTrafficLevels.HEAVY;
                }
                else
                {
                    tl = CityTrafficLevels.MODERATE;
                }
            }

            float tmod = FindObjectOfType<GameTime>().GetTrafficDelay((int)tl);
            travelTime = (int)citySize * 10.0f / 60.0f * tmod;                       //set the time to cross a city starting at 10 minutes per city size (adjusted for traffic level)
            cityAreaRenderer.material.color = trafficColors[(int)tl];
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log(this.name + " was left clicked");
        pathMaker.SetDestination(this.gameObject);
    }
}

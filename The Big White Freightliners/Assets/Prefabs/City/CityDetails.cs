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
    public float timezone = 0.0f;

    [HideInInspector] public float travelTime;          //time to cross the city in hours (will be scaled by road, traffic, and weather conditions)

    private FollowPath pathMaker;

    // Start is called before the first frame update
    void Awake()
    {
        TextMesh nameMesh = this.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
        nameMesh.text = this.name;

        this.transform.localScale = new Vector3(((int)citySize) / 2.0f, ((int)citySize) / 2.0f, ((int)citySize) / 2.0f);
        travelTime = (int)citySize * 10.0f / 60.0f;                                                                         //set the time to cross a city starting at 10 minutes per city size

        GameObject go = GameObject.FindWithTag("Truck");
        pathMaker = (FollowPath)go.GetComponent(typeof(FollowPath));

    }

    // Update is called once per frame
    void Update()
    {
        int hr = FindObjectOfType<GameTime>().GetHour();
        float tmod = FindObjectOfType<GameTime>().GetHour();

        if ((hr >= 7) || (hr <= 9) || (hr >= 4) || (hr <=6))
        {
            if ((hr == 8) || (hr == 5))
            {

            }
            else
            {

            }
        }
        else
        {

        }
        

    }

    private void OnMouseDown()
    {
        //Debug.Log(this.name + " was left clicked");
        pathMaker.SetDestination(this.gameObject);
    }
}

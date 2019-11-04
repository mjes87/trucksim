using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CityDetails : MonoBehaviour
{
    public enum CitySizes
    {
        SMALL,
        MEDIUM,
        LARGE,
        METROPOLIS
    }

    public string cityName = "City ?";
    public CitySizes citySize = CitySizes.LARGE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

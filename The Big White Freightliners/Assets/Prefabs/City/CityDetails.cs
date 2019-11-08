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

    // Start is called before the first frame update
    void Start()
    {
        TextMesh nameMesh = this.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
        nameMesh.text = this.name;

        this.transform.localScale = new Vector3(((int)citySize) / 2.0f, ((int)citySize) / 2.0f, ((int)citySize) / 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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

    private FollowPath pathMaker;

    // Start is called before the first frame update
    void Start()
    {
        TextMesh nameMesh = this.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
        nameMesh.text = this.name;

        this.transform.localScale = new Vector3(((int)citySize) / 2.0f, ((int)citySize) / 2.0f, ((int)citySize) / 2.0f);

        GameObject go = GameObject.FindWithTag("Truck");
        pathMaker = (FollowPath)go.GetComponent(typeof(FollowPath));
    }

    // Update is called once per frame
    void Update()
    {
/*
        if (Input.GetMouseButtonDown(0))
        {


            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("I hit something");
                if (hit.transform.name == this.name)
                {
                    Debug.Log(this.name + " was left clicked");
                    pathMaker.SetDestination(this.gameObject);
                }
            }
        }
   */         
    }

    private void OnMouseDown()
    {
        Debug.Log(this.name + " was left clicked");
        pathMaker.SetDestination(this.gameObject);
    }
}

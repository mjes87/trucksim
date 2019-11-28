using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentDetails : MonoBehaviour
{

    [HideInInspector] public float duration;

    private int hourlyRate = 48;
    private float hourlyDuration = 0.5F;
    private int wammyRate = 15;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, hourlyRate) == 0)
        {
            duration = hourlyDuration;
            while (Random.Range(0, wammyRate) == 0)          //here check for a big accident in a loop
            {                                               //so there is a remote chance of there being a very big accident
                duration *= 3.0f;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

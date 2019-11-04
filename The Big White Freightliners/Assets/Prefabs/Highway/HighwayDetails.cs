using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayDetails : MonoBehaviour
{
    public string highwayName;
    public Transform startPoint;
    public Transform endPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = startPoint.position;

        Quaternion rotit = new Quaternion();
        float rotAngle = Mathf.Atan((startPoint.position.z - endPoint.position.z) / (startPoint.position.x - endPoint.position.x)) * 180 / Mathf.PI;
        if (rotAngle > 180)
        {
            rotAngle -= 180;
        }
        rotit.Set(this.transform.rotation.x, rotAngle,this.transform.rotation.z, 1);
        this.transform.rotation = rotit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

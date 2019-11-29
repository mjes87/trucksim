using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loads : MonoBehaviour
{
    public GameObject SidePanel;
    int counter;

    public void togglePanel()
    {
        counter++;
        if (counter % 2 == 1)
        {
            SidePanel.gameObject.SetActive(true);
        }
        else
        {
            SidePanel.gameObject.SetActive(false);
        }
    }
}

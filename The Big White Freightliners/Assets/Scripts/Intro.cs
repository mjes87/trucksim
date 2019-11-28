using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    GameManager GM;
    
    void Awake ()
    {
        GM = GameManager.Instance;
        Invoke("LoadLevel", 3f);
    }
    
    void Start()
    {
        
    }

    public void LoadLevel()
    {
        Application.LoadLevel("Menu");
    }
}

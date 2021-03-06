﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameManager GM;
    private AudioSource audioSource;

    void Awake()
    {
        GM = GameManager.Instance;
    }

    public void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 800));
        GUI.Box(new Rect(0, 0, 100, 200), "Menu");
        if (GUI.Button (new Rect (10, 40, 80, 30), "Start"))
        {
            StartGame();
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(SoundManager.instance.buttonClicks);
        }
        if (GUI.Button (new Rect (10, 160, 80, 30), "Quit"))
        {
            Quit();
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(SoundManager.instance.buttonClicks);
        }
        GUI.EndGroup();
    }

    public void StartGame()
    {
        Application.LoadLevel("City and Road Works");
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(SoundManager.instance.mainMusic);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

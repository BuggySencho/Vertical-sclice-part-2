using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    private bool btnOn = true;
    public void Pause()
    {
        Time.timeScale = 0f;
        Debug.Log("Paused");
    }

    public void TimesTwo()
    {
        if (btnOn)
        {
            Time.timeScale *= 2;
            Debug.Log("Gotta go fast");
            btnOn = false;
        }

        if (!btnOn)
        {
            Time.timeScale = 1f;
            btnOn = true;
        }
    }

    public void Auto()
    {
        Debug.Log("Auto mode activated");
    }
}

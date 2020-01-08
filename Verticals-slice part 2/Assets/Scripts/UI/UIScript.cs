using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0f;
        Debug.Log("Paused");
    }

    public void TimesTwo()
    {
        Time.timeScale = 2f;
        Debug.Log("Gotta go fast");
    }

    public void Auto()
    {
        Debug.Log("Auto mode activated");
    }
}

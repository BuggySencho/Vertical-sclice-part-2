using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    private bool btnOn = true;

    // sets the time scale to 0, thus pausing the game
    public void Pause()
    {
        Time.timeScale = 0f;
        Debug.Log("Paused");
    }

    // doubles the speed of the game
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

    // lets the AI take over and play the game without the player itself
    public void Auto()
    {
        Debug.Log("Auto mode activated");
    }
}

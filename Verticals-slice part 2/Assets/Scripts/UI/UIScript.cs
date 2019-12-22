using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public void TimesTwo()
    {
        Time.timeScale = 2f;
        Debug.Log("Gotta go fast");
    }
}

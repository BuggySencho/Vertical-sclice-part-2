using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    private int bossDamage;
    [SerializeField]
    private GameObject scriptManager;

    private void Start()
    {
        scriptManager = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scriptManager.GetComponent<PlayerHealth>().CurHealth -= bossDamage;
        }
    }
}

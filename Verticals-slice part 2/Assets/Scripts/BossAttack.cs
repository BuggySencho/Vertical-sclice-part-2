using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    private int bossDamage;
    [SerializeField]
    private GameObject scriptManager;
    public static bool playerTakingDamage = false;

    private void Start()
    {
        scriptManager = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && scriptManager.GetComponent<CombatSystem>().BossTurn <= 0)
        {
            playerTakingDamage = true;
            scriptManager.GetComponent<PlayerHealth>().CurHealth -= bossDamage;

        }

      /*  if (scriptManager.GetComponent<CombatSystem>().BossTurn <= 0)
        {
            playerTakingDamage = true;
        }
         */
    }

 /*   private void OnTriggerExit(Collider other)
    {
        
    } */

}

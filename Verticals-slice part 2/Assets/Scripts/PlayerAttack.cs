using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject scriptManager;
    [SerializeField]
    private int playerDamage;

    // Start is called before the first frame update
    void Start()
    {
        scriptManager = GameObject.FindGameObjectWithTag("GameController");
        playerDamage = CombatSystem.instance.Characters[0].GetComponent<UnitScript>().Strength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            scriptManager.GetComponent<BossHealth>().BossCurHealth -= playerDamage;
        }
    }
}

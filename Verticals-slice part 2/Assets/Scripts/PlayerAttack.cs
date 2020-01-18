using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject scriptManager;
    [SerializeField]
    private int playerDamage;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject inRangePref;
    [SerializeField]
    private Image bossHealthBar;

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
            Instantiate(inRangePref, spawnPoint.position, spawnPoint.rotation);
            scriptManager.GetComponent<BossHealth>().BossCurHealth -= playerDamage;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      //  Destroy(inRangePref);
    }
}

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

    public bool BossInRange { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        scriptManager = GameObject.FindGameObjectWithTag("GameController");
        playerDamage = CombatSystem.instance.Characters[CombatSystem.instance.TurnOrder].GetComponent<UnitScript>().Strength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            BossInRange = true;
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void DamageBoss()
    {
        scriptManager.GetComponent<BossHealth>().BossCurHealth -= playerDamage;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            BossInRange = false;
            collision.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

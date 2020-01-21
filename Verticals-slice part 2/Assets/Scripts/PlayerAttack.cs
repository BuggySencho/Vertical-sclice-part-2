using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject scriptManager;
    public int PlayerDamage { get; set; } = 0;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject inRangePref;
    [SerializeField]
    private Image bossHealthBar;

    public bool BossInRange { get; set; } = false;
    public static bool TakingDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        scriptManager = GameObject.FindGameObjectWithTag("GameController");
        PlayerDamage = transform.parent.GetComponent<UnitScript>().Strength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            TakingDamage = true;
            BossInRange = true;
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void DamageBoss()
    {
        scriptManager.GetComponent<BossHealth>().BossCurHealth -= PlayerDamage;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            TakingDamage = false;
            BossInRange = false;
            collision.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

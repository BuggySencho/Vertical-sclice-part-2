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
            BossInRange = true;
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void DamageBoss()
    {
      //  TakingDamage = true;
     //   StartCoroutine(BossHealth.BossLosingHealth());
        scriptManager.GetComponent<BossHealth>().BossCurHealth -= PlayerDamage;
        new WaitForSeconds(3f);
        BossHealth.bossDamageBar.fillAmount = BossHealth.bossCurHealth / BossHealth.health;
      //  TakingDamage = false;
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

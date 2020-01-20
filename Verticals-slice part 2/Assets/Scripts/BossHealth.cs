using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 20000f;
    [SerializeField]
    private float bossCurHealth;
    [SerializeField]
    private Image bossHealthBar;
    public Image BossHealthBar { get { return bossHealthBar; } set { bossHealthBar = value; } }
    [SerializeField]
    private GameObject bossHealthUI;
    public float BossCurHealth { get { return bossCurHealth; } set { bossCurHealth = value; } }
    // Start is called before the first frame update
    void Start()
    {
        bossHealthBar = bossHealthUI.GetComponent<Image>();
        bossCurHealth = health;
     //   bossCurHealth -= CombatSystem.instance.Characters[0].GetComponent<UnitScript>().Strength;
    }

    private void Update()
    {
        bossHealthBar.fillAmount = bossCurHealth / health;
        if (bossCurHealth <= 0)
        {
            Debug.Log("VICTORY SCREECH!!!");
        }
    }
}

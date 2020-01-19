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
    private Image healthBar;
    public Image HealthBar { get { return healthBar; } set { healthBar = value; } }
    [SerializeField]
    private GameObject healthUI;
    public float BossCurHealth { get { return bossCurHealth; } set { bossCurHealth = value; } }
    // Start is called before the first frame update
    void Start()
    {
        healthBar = healthUI.GetComponent<Image>();
        bossCurHealth = health;
     //   bossCurHealth -= CombatSystem.instance.Characters[0].GetComponent<UnitScript>().Strength;
    }

    private void Update()
    {
        healthBar.fillAmount = health / bossCurHealth;  
    }
}

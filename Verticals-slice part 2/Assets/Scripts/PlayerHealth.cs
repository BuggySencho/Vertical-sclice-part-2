using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float curHealth;
    public float CurHealth { get { return curHealth; } set { curHealth = value; } }
    [SerializeField]
    private GameObject healthText;
    [SerializeField]
    private GameObject playerHealthUI;
    [SerializeField]
    private Image playerHealthBar;
    [SerializeField]
    private GameObject playerDamageUI;
    [SerializeField]
    private Image playerDamageBar;
    public Image PlayerDamageBar { get { return playerDamageBar; } set { playerDamageBar = value; } }
    [SerializeField]
    private GameObject defeat;

    // Start is called before the first frame update
    void Start()
    {
        playerDamageBar = playerDamageUI.GetComponent<Image>();
        playerHealthBar = playerHealthUI.GetComponent<Image>();
        health = CombatSystem.instance.Characters[0].GetComponent<UnitScript>().Hp + CombatSystem.instance.Characters[1].GetComponent<UnitScript>().Hp + CombatSystem.instance.Characters[2].GetComponent<UnitScript>().Hp;
        curHealth = health;
        healthText.GetComponent<Text>().color = Color.yellow;
    }

    private void Update()
    {
        if (BossAttack.playerTakingDamage)
        {
            StartCoroutine(PlayerLosingHealth());
        }

        playerHealthBar.fillAmount = curHealth / health;
        healthText.GetComponent<Text>().text = curHealth.ToString();

        if (curHealth <= 0)
        {
            defeat.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("YOU'VE SUFFERED DEFEAT!!!");
        }
    }

    private IEnumerator PlayerLosingHealth()
    {
        Debug.Log("Taking critical damage!");
        yield return new WaitForSeconds(1f);
        playerDamageBar.fillAmount = curHealth / health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int curHealth;
    public int CurHealth { get { return curHealth; } set { curHealth = value; } }
    [SerializeField]
    private GameObject healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = CombatSystem.instance.Characters[0].GetComponent<UnitScript>().Hp + CombatSystem.instance.Characters[1].GetComponent<UnitScript>().Hp + CombatSystem.instance.Characters[2].GetComponent<UnitScript>().Hp;
        curHealth = health;
        healthText.GetComponent<Text>().color = Color.yellow;
    }

    private void Update()
    {
        healthText.GetComponent<Text>().text = curHealth.ToString();
    }
}

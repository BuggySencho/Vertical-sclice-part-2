using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = CombatSystem.instance.Characters[0].GetComponent<UnitScript>().Hp + CombatSystem.instance.Characters[1].GetComponent<UnitScript>().Hp + CombatSystem.instance.Characters[2].GetComponent<UnitScript>().Hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

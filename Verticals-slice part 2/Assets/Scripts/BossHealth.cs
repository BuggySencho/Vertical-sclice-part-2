using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 20000;
    [SerializeField]
    private int bossCurHealth;
    public int BossCurHealth { get { return bossCurHealth; } set { bossCurHealth = value; } }
    // Start is called before the first frame update
    void Start()
    {
        bossCurHealth = health; 
    }
}

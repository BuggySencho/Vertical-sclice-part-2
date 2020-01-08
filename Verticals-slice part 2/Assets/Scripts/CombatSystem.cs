using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatState
{ PlayerTurn, EnemyTurn, Victory, Defeat }

public class CombatSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    private int characterIndex;
    protected CombatState state;
    protected bool dragable;


    // Start is called before the first frame update
    void Start()
    {
        characterIndex = 0;
        state = CombatState.PlayerTurn;
        PlayerTurn();
    }

    void PlayerTurn()
    {
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    // list of all the characters
    [SerializeField]
    private List<GameObject> characters = new List<GameObject>();
    public List<GameObject> Characters { get { return characters; } }
    // shows the turn order wich is used to determine wich character is next
    private int turnOrder = 0;
    public int TurnOrder { get { return turnOrder; } }
    // value to show when the boss can attack
    [SerializeField]
    private int bossTurn = 2;
    public int BossTurn { get { return bossTurn; } set { bossTurn = value; } }
    // the animator is defined here
    [SerializeField]
    private Animator anim;

    public static CombatSystem instance;

    private void Awake()
    {
       // bossTurn = Random.Range(2, 4);
       // rangeRing.transform.gameObject.SetActive(true);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // sets every characters movement false and enables the movement of the first character
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].transform.GetChild(0).gameObject.SetActive(false);
            characters[i].GetComponent<CharacterMovement>().enabled = false;
        }
        characters[0].transform.GetChild(0).gameObject.SetActive(true);
        characters[0].GetComponent<CharacterMovement>().enabled = true;
    }

    public void NextTurn()
    {
        // disables the movement for the current character
        characters[turnOrder].transform.GetChild(0).gameObject.SetActive(false);
        characters[turnOrder].GetComponent<CharacterMovement>().enabled = false;

        // adds 1 to the turn order
        if (turnOrder < characters.Count - 1)
        {
            turnOrder++;
        }
        else
        {
            turnOrder = 0;
        }

        // enables the movement for the next character
        if (bossTurn > 0)
        {
            characters[turnOrder].transform.GetChild(0).gameObject.SetActive(true);
            characters[turnOrder].GetComponent<CharacterMovement>().enabled = true;
            bossTurn--;
        }

        // the boss attacks if his turn is 0 or below that
        else if(bossTurn <= 0)
        {
            BossAttack();
        }
    }

    // enables 
    void BossAttack()
    {
        anim.SetBool("Attacking", true);
        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
         yield return new WaitForSeconds(2f);
        anim.SetBool("Attacking", false);
        bossTurn = 4; //Random.Range(2, 4) + 1;
        NextTurn();
    }
}

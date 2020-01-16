using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> characters = new List<GameObject>();
    public List<GameObject> Characters { get { return characters; } }
    private int turnOrder = 0;
    [SerializeField]
    private int bossTurn = 3;
    [SerializeField]
    private GameObject bossAttacks;

    public static CombatSystem instance;

    private void Awake()
    { 

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
        bossTurn = Random.Range(2, 4);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].GetComponent<CharacterMovement>().enabled = false;
        }

        characters[0].GetComponent<CharacterMovement>().enabled = true;
    }

    public void NextTurn()
    {
        characters[turnOrder].GetComponent<CharacterMovement>().enabled = false;

        if (turnOrder < characters.Count - 1)
        {
            turnOrder++;
        }
        else
        {
            turnOrder = 0;
        }

        if (bossTurn > 0)
        {
            characters[turnOrder].GetComponent<CharacterMovement>().enabled = true;
            bossTurn--;
        }
        else
        {
            BossAttack();
            bossTurn = Random.Range(2, 4);

        }
    }

    void BossAttack()
    {
        Instantiate(bossAttacks, transform.position, transform.rotation);
        Debug.Log("Attacking");
        WaitTime();
      //  NextTurn(); in corutine
    }

    IEnumerator WaitTime()
    {
        new WaitForSeconds(2f);
        Destroy(bossAttacks);
        NextTurn();
        yield return new WaitForSeconds(2f);
    }
}

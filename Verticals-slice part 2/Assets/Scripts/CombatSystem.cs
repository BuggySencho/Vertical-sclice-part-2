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
    public int BossTurn { get { return bossTurn; } set { bossTurn = value; } }
    [SerializeField]
    private Animator anim;

    public static CombatSystem instance;

    private void Awake()
    {
        bossTurn = Random.Range(2, 4);
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
        characters[turnOrder].transform.GetChild(0).gameObject.SetActive(false);
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
            characters[turnOrder].transform.GetChild(0).gameObject.SetActive(true);
            characters[turnOrder].GetComponent<CharacterMovement>().enabled = true;
            bossTurn--;
        }
        else if(bossTurn <= 0)
        {
            BossAttack();
        }
    }

    void BossAttack()
    {
        anim.SetBool("Attacking", true);
        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
         yield return new WaitForSeconds(2f);
        anim.SetBool("Attacking", false);
        bossTurn = Random.Range(2, 4) + 1;
        NextTurn();
    }
}

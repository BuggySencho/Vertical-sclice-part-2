using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] secretTechniques;

    // Update is called once per frame
    void Update()
    {
        if (CombatSystem.instance.BossTurn > 0 && CombatSystem.instance.BossTurn < 4)
        {
            GetComponent<SpriteRenderer>().sprite = secretTechniques[CombatSystem.instance.BossTurn - 1];
        }        
    }
}

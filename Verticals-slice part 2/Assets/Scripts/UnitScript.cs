using UnityEngine;

public class UnitScript : MonoBehaviour
{
    // gives hp to the character
    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } set { hp = value; } }
    // gives strength to the character so he can attack
    [SerializeField]
    protected int strength;
    public int Strength { get { return strength; } set { strength = value; } }
    // shows the current amount of chakra a character has
    [SerializeField]
    protected int currentChakraAmount;
    // shows the maximum amount of chakra a character can have
    [SerializeField]
    protected int maxChakraAmount;
    // shows the range of a unit
    [SerializeField]
    protected string range;
    // shows what in what kind of clans the unit belongs
    [SerializeField]
    protected string affiliation;
    // value for displaying the amount of luck of a character
    [SerializeField]
    protected int luck;
    // value for displaying te cost of a character
    [SerializeField]
    protected int cost;
    // shows the character of a character
    [SerializeField]
    protected string element;

 /*   private void Start()
    {
        int b= 2342;
        string s =b.ToString();
        int a = (int)s[0];

    } */
}

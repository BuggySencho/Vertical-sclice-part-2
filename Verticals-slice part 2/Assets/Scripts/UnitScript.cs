using UnityEngine;

public class UnitScript : MonoBehaviour
{
    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } set { hp = value; } }
    [SerializeField]
    protected int strength;
    public int Strength { get { return strength; } set { strength = value; } }
    [SerializeField]
    protected int currentChakraAmount;
    [SerializeField]
    protected int maxChakraAmount;
    [SerializeField]
    protected string range;
    [SerializeField]
    protected string affiliation;
    [SerializeField]
    protected int luck;
    [SerializeField]
    protected int cost;
    [SerializeField]
    protected string element;

    private void Start()
    {
        int b= 2342;
        string s =b.ToString();
        int a = (int)s[0];

    }
}

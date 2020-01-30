using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 touchPos;
    private Rigidbody2D rb;
    private Vector3 dir;
    private float movementSpeed = 10f;
    private Vector3 curPos;
    /* [SerializeField]
       private Transform startPos;
       [SerializeField]
       private GameObject narutoGhost; */
    private PlayerAttack playerAttack;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // searches the objaect it's attached to for a rigibody2D
        rb = GetComponent<Rigidbody2D>();
        playerAttack = transform.GetChild(0).GetComponent<PlayerAttack>();
     //   Instantiate(narutoGhost, startPos.position, startPos.rotation);
    }

    void Update()
    {
        TouchMovement();
    }

    private void TouchMovement()
    {
        // checks if the screen is beeing touched
        if (Input.touchCount > 0)
        {
            // sets the touch to a variable
            Touch touch = Input.GetTouch(0);
            // makes variable the position where the finger touched in worldspace
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            // makes the z axis of the touch possition 0
            touchPos.z = 0;
            // follows the position of the finger and changes its possition
            dir = (touchPos - transform.position);
            anim.SetBool("Running", true);

            // checks is the touch possition is between valid values
            if (touchPos.x > -2.3f && touchPos.x < 1.4f && touchPos.y > -2.1f && touchPos.y < 1.9f)
            {
               // Mathf.Clamp(transform.position.x, -2.6f, 1.4f);
               // Mathf.Clamp(transform.position.y, -2.8f, 1.7f);
                // gives the velocity to the direction of the touch, thus making the object follow your finger
                rb.velocity = new Vector2(dir.x, dir.y) * movementSpeed;
            }

            // stops the character if the touch possition isn't valid
            else
            {
                rb.velocity = Vector2.zero;
            }

            // checks if you stopped touching the screen
            if (touch.phase == TouchPhase.Ended)
            {
                anim.SetBool("Running", false);
                curPos = rb.position;
                rb.velocity = Vector2.zero;

                if (playerAttack.BossInRange)
                {
                    anim.SetTrigger("Attacking");
                    Debug.Log("Yess");
                    playerAttack.DamageBoss();
                    anim.SetBool("Running", false);
                }

                 CombatSystem.instance.NextTurn();
              //  Destroy(narutoGhost);
                // sets the velocity of the object zero
                
                
            }
        }
    }
}

using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 touchPos;
    private Rigidbody2D rb;
    private Vector3 dir;
    private float movementSpeed = 10f;
    private Vector3 curPos;

    // Start is called before the first frame update
    void Start()
    {
        // searches the objaect it's attached to for a rigibody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TouchMovement();
    }

    // checks if the toutchpos is within the box collider
    /*  private void OnTriggerStay2D(Collider2D collision)
      {
          if (collision.gameObject.tag == "MoveArea")
          {
              Debug.Log("touching");
              TouchMovement();
          }      
      } */

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
            Debug.Log(touchPos);

            if (touchPos.x > -2.3f && touchPos.x < 1.4f && touchPos.y > -2.1f && touchPos.y < 1.9f)
            {
               // Mathf.Clamp(transform.position.x, -2.6f, 1.4f);
               // Mathf.Clamp(transform.position.y, -2.8f, 1.7f);
                // gives the velocity to the direction of the touch, thus making the object follow your finger
                rb.velocity = new Vector2(dir.x, dir.y) * movementSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            // checks if you stopped touching the screen
            if (touch.phase == TouchPhase.Ended)
            {
                // sets the velocity of the object zero
                curPos = rb.position;
                rb.velocity = Vector2.zero;                
            }
        }
    }
}

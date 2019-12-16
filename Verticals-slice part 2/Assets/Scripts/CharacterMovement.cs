using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float width;
    private float height;
    private Vector2 possition;

    void Awake()
    {
        width = (float)Screen.width / 2f;
        height = (float)Screen.height / 2f;

        possition = new Vector2(0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchMovement();
    }

    void TouchMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                possition = new Vector2(-pos.x, pos.y);
                transform.position = possition;
            }
        }
    }
}

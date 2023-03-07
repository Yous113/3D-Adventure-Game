using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour
{
    public float Speed;

    float MovementX;
    float MovementY;

    Rigidbody2D Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        MovementX = 0;
        MovementY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Rb.velocity = new Vecotr2 (MovementX * Speed * Time.deltaTime, MovementY * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            MovementY = 1;
        }
        
        If (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovementY = -1;
        }

        If (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovementX = -1;
        }

        If (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovementX = 1;
        }
    }
}

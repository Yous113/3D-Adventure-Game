using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;

    float MovementX;
    float MovementY;

    Rigidbody2D Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementX = Input.GetAxisRaw("Horizontal");
        MovementY = Input.GetAxisRaw("Vertical");

        Rb.velocity = new Vector2(MovementX * Speed * Time.deltaTime, MovementY * Speed * Time.deltaTime);
    }
}

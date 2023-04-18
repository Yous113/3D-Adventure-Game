using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionIgnore : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    Collider collider1;
    Collider collider2;
    
    // Start is called before the first frame update
    void Start()
    {
        collider1 = player1.GetComponent<Collider>();
        collider2 = player2.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(collider1, collider2, true);
    }
}

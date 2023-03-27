using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    //Variables
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponant<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Makes enemy move towards player
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }
}

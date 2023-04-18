using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [Header("Patrol")]
    public Transform point1;
    public Transform point2;
    private Transform player;
    private Transform currentPoint;
    private bool isChasing;
    private Vector3 originalPosition;

    [Header("AttackVariable")]
    public float speed;
    public float detectionRange;
    public float returnRange;
    public string playerTag = "Player";
    public int damage = 1;

    

    void Start()
    {
        isChasing = false;
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        currentPoint = point1;
        originalPosition = transform.position;
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            if (IsPlayerBetweenPoints())
            {
                isChasing = true;
            }
        }

        if (isChasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, originalPosition) > returnRange)
            {
                isChasing = false;
            }
        }
        else
        {
            Transform targetPoint = null;
            if (currentPoint == point1)
            {
                targetPoint = point2; 
            }
            else if (currentPoint == point2)
            {
                targetPoint = point1;
            }

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                currentPoint = targetPoint;
                transform.Rotate(0, 180, 0);
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        }
        
    }

    bool IsPlayerBetweenPoints()
    {
        return (player.position.x > point1.position.x && player.position.x < point2.position.x)
            || (player.position.x < point1.position.x && player.position.x > point2.position.x);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Playerhealth health = collision.gameObject.GetComponent<Playerhealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}

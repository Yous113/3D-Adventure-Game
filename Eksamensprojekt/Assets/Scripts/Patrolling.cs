using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed;
    public float detectionRange;
    public float returnRange;
    public string playerTag = "Player";
    public int damage = 1;

    private bool isChasing;
    private Transform player;
    private Transform currentPoint;
    private Vector3 originalPosition;

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

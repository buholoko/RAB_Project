
using UnityEngine;

public class EnemyFollowConstant : MonoBehaviour
{
    public Transform player;      
    public float moveSpeed = 5f;   
    public float stopDistance = 1f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        
        Vector3 direction = (player.position - transform.position).normalized;

        
        float distance = Vector3.Distance(transform.position, player.position);

        
        if (distance > stopDistance)
        {
            rb.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
        }

        
        transform.LookAt(player);
    }
}



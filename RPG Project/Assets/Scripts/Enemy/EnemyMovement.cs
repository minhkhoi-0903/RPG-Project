using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float visionRange = 5f;
    public LayerMask obstacleMask;
    public float waitTime = 2f;
    public Vector2 areaMin = new Vector2(-5, -5);
    public Vector2 areaMax = new Vector2(5, 5);

    private Vector2 wanderTarget;
    private float waitCounter;
    private bool isWandering = false;

    void Start()
    {
        ChooseNewWanderPosition();
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            // Đuổi theo player
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            // Di chuyển ngẫu nhiên
            Wander();
        }
    }

    bool CanSeePlayer()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        Debug.DrawRay(transform.position, directionToPlayer * visionRange, Color.red); // Ray debug

        if (distanceToPlayer <= visionRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, visionRange, obstacleMask);

            if (hit.collider != null)
            {
                Debug.Log("Ray hit: " + hit.collider.name); // Debug tên vật bị hit

                if (hit.collider.gameObject == player.gameObject)
                {
                    return true;
                }
            }
        }

        return false;
    }

    void Wander()
    {
        if (isWandering)
        {
            transform.position = Vector2.MoveTowards(transform.position, wanderTarget, moveSpeed * Time.deltaTime);

            Vector2 direction = wanderTarget - (Vector2)transform.position;
            if (direction.sqrMagnitude > 0.01f)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }

            if (Vector2.Distance(transform.position, wanderTarget) < 0.1f)
            {
                isWandering = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0f)
            {
                ChooseNewWanderPosition();
            }
        }
    }

    void ChooseNewWanderPosition()
    {
        int maxTries = 10;
        for (int i = 0; i < maxTries; i++)
        {
            float x = Random.Range(areaMin.x, areaMax.x);
            float y = Random.Range(areaMin.y, areaMax.y);
            Vector2 newTarget = new Vector2(x, y);

            // Kiểm tra vị trí không nằm trong vật cản
            Collider2D hit = Physics2D.OverlapCircle(newTarget, 0.2f, obstacleMask);
            if (hit == null)
            {
                wanderTarget = newTarget;
                isWandering = true;
                return;
            }
        }

        // Nếu sau nhiều lần vẫn không tìm được, giữ nguyên chỗ
        wanderTarget = transform.position;
        isWandering = false;
    }
}

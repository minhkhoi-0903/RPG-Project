using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public float chaseRange;
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
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction;

        if (distance < chaseRange)
        {
            // Đuổi theo player
            direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            // Di chuyển ngẫu nhiên
            Wander();
        }
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
        float x = Random.Range(areaMin.x, areaMax.x);
        float y = Random.Range(areaMin.y, areaMax.y);
        wanderTarget = new Vector2(x, y);
        isWandering = true;
    }
}

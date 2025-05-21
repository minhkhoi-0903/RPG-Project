using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 moveDirection;
    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10;
    [SerializeField] float dashDuration = 1;
    [SerializeField] float dashCooldown = 1;
    bool isDashing;
    bool canDash = true;
    private void Start()
    {
        canDash = true;
    }
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        ProcessInputs();
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        Move();
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY);
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}

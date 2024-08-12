using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Knockback knockback;
    private Animator enemyAnimator;
    private SpriteRenderer enemySpriteRender;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knockback = GetComponent<Knockback>();
        enemyAnimator = GetComponent<Animator>();
        enemySpriteRender = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (knockback.GettingKnockedBack) { return; }

        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
        AdjustEnemyFacingDirection();
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;

        enemyAnimator.SetFloat("moveX", moveDir.x);
        enemyAnimator.SetFloat("moveY", moveDir.y);
    }

    public void StopMoving()
    {
        moveDir = Vector2.zero;
    }

    private void AdjustEnemyFacingDirection()
    {
        if (moveDir.x < 0)
        {
            enemySpriteRender.flipX = true;
        }
        else if (moveDir.y < 0)
        {
            enemySpriteRender.flipX = false;
        }
    }
}

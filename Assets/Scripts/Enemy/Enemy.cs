using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyMovementSpeed;

    public GameObject enemyPrefab;

    private Rigidbody2D rb2D;
    private Health health;
    private Animator animator;
    private WaitForSeconds waitForEndHitAnim;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;

    private bool isWalking;
    private bool beAttacked;

    [SerializeField] private int itemCode;

    private void Awake()
    {
        health = GetComponent<Health>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();

        waitForEndHitAnim = new WaitForSeconds(Settings.waitForEndHitAnim);
        enemyMovementSpeed = Settings.enemyNormalSpeed;
    }
    private void Start()
    {
        isWalking = true;
    }

    private void Update()
    {
       
        UpdateAnimation();
      

        if(CanMoveToward())
        {
            enemyMovementSpeed = Settings.enemyNormalSpeed;
        }
        else
        {
            enemyMovementSpeed = 0f;
        }
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag(Tags.Enemy))
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            if(damageDealer != null)
            {
                beAttacked = true;
                health.DealDamage(damageDealer);
                if(damageDealer.destroyAfterDeal)
                {
                    collision.gameObject.SetActive(false);
                }
                if(health.HP <= 0)
                {
                    EnemyDie();
                }
            }
        }
        else
        {
            enemyMovementSpeed = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(Tags.Enemy))
        {
            enemyMovementSpeed = Settings.enemyNormalSpeed;
        }
    }

    private void EnemyDie()
    {
        ItemMapManager.Instance.CreateItemMap(transform.position, itemCode);

        gameObject.SetActive(false);
        EventHandler.CallAfterKillEnemy(this);
    }

    private void EnemyMovement()
    {
        Vector2 velocity = (Player.Instance.transform.position - transform.position).normalized * enemyMovementSpeed;
        rb2D.velocity = velocity;
        //Vector2 playerPosition = Player.Instance.transform.position;
        //Vector2 newPosition = Vector2.MoveTowards(transform.position, playerPosition, enemyMovementSpeed * Time.fixedDeltaTime);
        //rb2D.MovePosition(newPosition);
        //rigidbody2D.AddForce((Player.Instance.transform.position - transform.position).normalized * enemyMovementSpeed * Time.deltaTime);
    }

    private IEnumerator ResetMovementRoutine()
    {
        yield return waitForEndHitAnim;
        ResetMovement();
    }

    private void ResetMovement()
    {
        isWalking = true;
        beAttacked = false;
    }

    private void UpdateAnimation()
    {
        if (isWalking)
        {
            if (Mathf.Sign(Player.Instance.transform.position.x - transform.position.x) == 1)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        animator.SetBool(Settings.beAttacked, beAttacked);
    }

    private bool CanMoveToward()
    {
        Vector2 direction = (Player.Instance.transform.position - transform.position).normalized;
        return !Physics2D.OverlapCircle((direction * (circleCollider2D.radius + 0.2f) + (Vector2)transform.position), 0.19f, LayerMask.GetMask(Tags.Enemy));
    }

    public float DistanceToPlayer()
    {
        return Vector2.Distance(transform.position, Player.Instance.transform.position);
    }
}

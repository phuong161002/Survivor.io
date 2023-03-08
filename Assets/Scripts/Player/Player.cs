using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonobehavior<Player>
{
    [HideInInspector]
    public Rigidbody2D rb2D;
    [HideInInspector] public Score score;
    [HideInInspector]

    [SerializeField] public float movementSpeed = 3f;

    private float xInput;
    private float yInput;


    protected override void Awake()
    {
        base.Awake();

        score = new Score();
    }

    private void OnEnable()
    {
        EventHandler.AfterKillEnemy += AfterKillEnemy;
    }


    private void OnDisable()
    {
        EventHandler.AfterKillEnemy -= AfterKillEnemy;
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    private void Update() {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        rb2D.velocity = GetPlayerMovement() * movementSpeed;
    }

    private void ProcessPlayerInput()
    {
        
    }

    private void AfterKillEnemy(Enemy enemy)
    {
        score.killedEnemyNumber++;
        GameManager.Instance.UpdateScore(score);
    }

    public Vector2 GetPlayerMovement()
    {
        return new Vector2(xInput, yInput).normalized;
    }
}

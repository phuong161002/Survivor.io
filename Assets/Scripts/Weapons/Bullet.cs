using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    private float lifeTime = 1f;
    private Rigidbody2D rb2D;
    private float moveSpeed;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    private void Update()
    {
        rb2D.velocity = direction * moveSpeed;
        if(lifeTime > 0f)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            DisableBullet();
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void DisableBullet()
    {
        gameObject.SetActive(false);
    }

}

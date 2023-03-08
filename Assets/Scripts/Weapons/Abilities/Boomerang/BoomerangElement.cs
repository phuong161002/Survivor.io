using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangElement : MonoBehaviour
{
    [HideInInspector] public float flySpeed;
    [HideInInspector] public float lifeTime;
    [HideInInspector] public float spinSpeed;
    private float decreaseVelocitySpeed;

    private Vector2 direction;
    private BoomerangController controller;


    private void Start()
    {
        Enemy enemy = EnemySpawner.Instance.FindEnemy();
        if (enemy != null)
        {
            direction = (enemy.transform.position - Player.Instance.transform.position).normalized;
            if (direction == Vector2.zero)
            {
                RemoveBoomerang();
            }
        }
        else
        {
            RemoveBoomerang();
        }
        decreaseVelocitySpeed = flySpeed * 1.5f;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0f)
        {
            RemoveBoomerang();
        }
    }

    private void FixedUpdate()
    {
        flySpeed -= Time.fixedDeltaTime * decreaseVelocitySpeed;
        transform.Rotate(new Vector3(0, 0, spinSpeed * Time.fixedDeltaTime));
        Vector2 moveRange = direction * flySpeed * Time.fixedDeltaTime;
        transform.position += new Vector3(moveRange.x, moveRange.y, 0);
    }

    public void SetController(BoomerangController controller)
    {
        this.controller = controller;
    }

    public void RemoveBoomerang()
    {
        controller.RemoveBoomerang(this);
    }
}

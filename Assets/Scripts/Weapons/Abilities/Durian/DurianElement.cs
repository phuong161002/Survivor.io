using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurianElement : MonoBehaviour
{
    private Vector2 direction;
    private Durian durian;
    private DurianController controller;

    private float spriteRadius = 2f;

    private void Start()
    {
        direction = new Vector2(1, 1).normalized;
    }

    public void SetAbility(Durian durian)
    {
        this.durian = durian;
    }
    
    public void SetController(DurianController controller)
    {
        this.controller = controller;
    }

    private void Update()
    {
        float scale = durian.radius / spriteRadius;
        transform.localScale = new Vector3(scale, scale, transform.localScale.z);
        //if (direction != Vector2.zero)
        //{
        //    rb2D.velocity = direction * durian.moveSpeed;
        //}
    }
    private void FixedUpdate()
    {
        Movement();
        //Debug.DrawLine(transform.position, transform.position + (Vector3)direction);
        //var hit = Physics2D.Raycast(transform.position, direction, float.MaxValue, LayerMask.GetMask("Wall"));
        //Vector2 newPosition = Vector2.MoveTowards(transform.position, hit.point - direction, durian.moveSpeed * Time.fixedDeltaTime);
        //rb2D.MovePosition(newPosition);
        //if (Vector2.Distance(hit.point, transform.position) < 1f)
        //{
        //    Debug.Log(direction.ToString() + " " + hit.normal.ToString() + hit.point.ToString());
        //    direction = Vector2.Reflect(direction, hit.normal);
        //    Debug.Log(direction.ToString());
        //}
    }

    private void Movement()
    {
        // Move follow direction
        transform.position += (Vector3)direction * durian.moveSpeed * Time.fixedDeltaTime;

        // Rotation
        transform.Rotate(new Vector3(0, 0, durian.spinSpeed * Time.fixedDeltaTime));

        // Check Collide Border  and change direction
        if(!controller.checkBox(transform.position))
        {
            Vector2 normal = controller.GetNormalOfWall(transform.position);

            if(Vector2.Angle(normal, direction) > 90)
            {
                direction = Vector2.Reflect(direction, normal);
            }
        }
    }
}

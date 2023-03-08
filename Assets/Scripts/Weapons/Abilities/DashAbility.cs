using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DashAbility", menuName = "Scriptable Objects/Ability/DashAbility")]
public class DashAbility : Ability
{
    public float dashVelocity;

    private float lastMovementSpeed;


    public override void Activate(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        if(player != null)
        {
            lastMovementSpeed = player.movementSpeed;
            player.movementSpeed = dashVelocity;
        }
    }


    public override void BeginCooldown(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        if (player != null)
        {
            player.movementSpeed = lastMovementSpeed;
        }
    }
}

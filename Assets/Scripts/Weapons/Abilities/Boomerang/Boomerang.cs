using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boomerang", menuName = "Scriptable Objects/Ability/Boomerang")]
public class Boomerang : Ability
{
    public float flySpeed;
    public float spinSpeed;
    public int quantity;
    public float lifeTime;
    public float deltaTimeSpawn;

    private GameObject controller;

    public override void Activate(GameObject parent)
    {
        controller = Instantiate(GameAssets.Instance.boomerangControllerPrefab, parent.transform.position, Quaternion.identity, parent.transform);
        BoomerangController boomerangController = controller.GetComponent<BoomerangController>();
        boomerangController.flySpeed = flySpeed;
        boomerangController.quantity = quantity;
        boomerangController.lifeTime = lifeTime;
        boomerangController.spinSpeed = spinSpeed;
        boomerangController.deltaTimeSpawn = deltaTimeSpawn;
    }

    public override void BeginCooldown(GameObject parent)
    {
        Destroy(controller);
    }
}

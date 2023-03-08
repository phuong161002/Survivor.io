using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guardian", menuName = "Scriptable Objects/Ability/Guardian")]
public class Guardian : Ability
{
    public float spinSpeed;
    public float radius;
    public int damageDealer;
    public int quantity;
    private GameObject gameObject;

    public override void Activate(GameObject parent)
    {
        gameObject = PoolManager.Instance.ReuseObject(GameAssets.Instance.guardianControllerPerfab, parent.transform.position, Quaternion.identity);
        gameObject.transform.SetParent(parent.transform);
        gameObject.SetActive(true); 

        GuardianController controller = gameObject.GetComponent<GuardianController>();
        controller.spinSpeed = spinSpeed;
        controller.radius = radius;
        controller.quantity = quantity;
    }

    public override void BeginCooldown(GameObject parent)
    {
        gameObject.SetActive(false);
    }
}

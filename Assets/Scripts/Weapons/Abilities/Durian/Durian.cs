using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Durian", menuName = "Scriptable Objects/Ability/Durian")]
public class Durian : Ability
{
    public float moveSpeed;
    public float spinSpeed;
    public float radius;

    public override void Activate(GameObject parent)
    {
        GameObject gO = Instantiate(GameAssets.Instance.durianControllerPrefab, parent.transform);

        DurianController durianController = gO.GetComponent<DurianController>();
        durianController.SetAbility(this);
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHP = 10;

    [HideInInspector] public int HP;

    private void OnEnable()
    {
        HP = maxHP;
    }

    public void DealDamage(DamageDealer dealer)
    {
        bool isCriticalHit = dealer.canDealCriticalHit && Random.Range(0, 100) < Settings.criticalHitRate;
        int damageAmount = dealer.damageDeal;
        if(isCriticalHit)
        {
            damageAmount = (int)(dealer.damageDeal * Settings.criticalDamageScale);
        }

        HP -= damageAmount;
        DamagePopup.Create(transform.position, damageAmount, isCriticalHit);
    }

    
}

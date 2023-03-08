using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    private float cooldownTime;
    private float activeTime;

    private AbilityState state;

    public KeyCode key;

    private void Update()
    {
        switch (state)
        {
            case AbilityState.Ready:
                if (key == KeyCode.None || Input.GetKeyDown(key))
                {
                    ability.Activate(gameObject);
                    state = AbilityState.Active;
                    activeTime = ability.activeTime;
                }
                break;
            case AbilityState.Active:
                if(ability.cooldownTime > 0f)
                {
                    if (activeTime > 0f)
                    {
                        activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.BeginCooldown(gameObject);
                        state = AbilityState.Cooldown;
                        cooldownTime = ability.cooldownTime;
                    }
                }
                break;
            case AbilityState.Cooldown:
                if(cooldownTime > 0f)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.Ready;
                }
                break;

        }
        
    }
}

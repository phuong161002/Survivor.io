using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : SingletonMonobehavior<GameAssets>
{
    // Damage Popup
    public GameObject damagePopupPrefab;

    public GameObject itemPrefab;

    // Item Map
    public GameObject itemMapPrefab;

    // Guardian Ability
    public GameObject guardianControllerPerfab;
    public GameObject guardianElementPrefab;

    // Boomerang Ability
    public GameObject boomerangControllerPrefab;
    public GameObject boomerangElementPrefab;

    // Durian Ability
    public GameObject durianControllerPrefab;
    public GameObject durianElementPrefab;

}

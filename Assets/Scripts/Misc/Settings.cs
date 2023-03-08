
using UnityEngine;

public static class Settings {

    // Animation
    public static int isWalking;
    public static int beAttacked;
    public static float waitForEndHitAnim = 0.5f;


    // Enemy
    public static float enemyNormalSpeed = 3f;

    // Damage Popup
    public static float damagePopupMoveYSpeed = 3f;
    public static float damagePopupDisappearSpeed = 10f;
    public static float damagePopupDisappearTimer_Max = 0.5f;
    public static Color damagePopupNormalHitColor = new Color(255, 197, 0);
    public static Color damagePopupCriticalHitColor = new Color(255, 0, 0);

    // Player
    public static float criticalHitRate = 30f; // percent
    public static float criticalDamageScale = 1.8f;

    static Settings()
    {
        isWalking = Animator.StringToHash("isWalking");
        beAttacked = Animator.StringToHash("beAttacked");
    }

}
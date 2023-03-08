using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;

    private float disappearTimer;

    public static DamagePopup Create(Vector2 position, int damageAmount, bool isCriticalHit)
    {
        GameObject gO = PoolManager.Instance.ReuseObject(GameAssets.Instance.damagePopupPrefab, position, Quaternion.identity);
        DamagePopup damagePopup = gO.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCriticalHit);
        gO.SetActive(true);

        return damagePopup;
    }

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    private void Setup(int damageAmount, bool isCriticalHit)
    {
        disappearTimer = Settings.damagePopupDisappearTimer_Max;
        textMesh.SetText(damageAmount.ToString());
        if (isCriticalHit)
        {
            // Critical Hit
            textColor = Settings.damagePopupCriticalHitColor;
            textMesh.fontSize = 9;
        }
        else
        {
            // Normal Hit
            textColor = Settings.damagePopupNormalHitColor;
            textMesh.fontSize = 7;
        }
        textMesh.color = textColor;
    }

    private void Update()
    {
        float moveYSpeed = Settings.damagePopupMoveYSpeed;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            textColor.a -= Settings.damagePopupDisappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a <= 0)
            {
                DisablePopup();
            }
        }

    }

    private void DisablePopup()
    {
        gameObject.SetActive(false);
    }
}


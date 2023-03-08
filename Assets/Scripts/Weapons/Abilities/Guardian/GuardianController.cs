using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : MonoBehaviour
{
    [HideInInspector] public int quantity;
    [HideInInspector] public float radius;
    [HideInInspector] public float spinSpeed;

    private List<GameObject> guardianElementList;

    private void Start()
    {
        guardianElementList = new List<GameObject>();
        InitGuardian();
    }

    private void InitGuardian()
    {
        float deltaAngle = 2 * Mathf.PI / quantity;
        float angle = 0f;
        for(int i = 0; i < quantity; i++)
        {
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 position = direction * radius + (Vector2)transform.position;
            GameObject element = Instantiate(GameAssets.Instance.guardianElementPrefab, position, Quaternion.identity, transform);
            guardianElementList.Add(element);
            angle += deltaAngle;
        }
    }


    private void FixedUpdate()
    {
        Spin();
    }

    private void Spin()
    {
        transform.Rotate(new Vector3(0, 0, -spinSpeed * Time.fixedDeltaTime));
        guardianElementList.ForEach(gO =>
        {
            gO.transform.Rotate(new Vector3(0, 0, -spinSpeed * 2f * Time.fixedDeltaTime));
        });
    }
}

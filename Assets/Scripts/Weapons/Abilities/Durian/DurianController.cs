using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurianController : MonoBehaviour
{
    private Durian durian;

    private Vector2 halfExtend;
    private DurianElement durianElement;
    private BoxCollider2D[] boxCollider2DArray;

    private void Start()
    {
        halfExtend = Camera.main.sensorSize / 2;
        //InitWall();
        GameObject gO = Instantiate(GameAssets.Instance.durianElementPrefab, transform.position, Quaternion.identity);
        durianElement = gO.GetComponent<DurianElement>();
        durianElement.SetAbility(durian);
        durianElement.SetController(this);
    }

    private void InitWall()
    {
        Debug.Log(Camera.main.sensorSize.ToString());
        boxCollider2DArray = GetComponentsInChildren<BoxCollider2D>();
        if (boxCollider2DArray.Length < 4)
        {
            return;
        }
        // Right Side Wall
        boxCollider2DArray[0].offset = new Vector2(halfExtend.x + 0.5f, 0);
        boxCollider2DArray[0].size = new Vector2(1f, halfExtend.y * 2.1f);

        // Left Side Wall
        boxCollider2DArray[1].offset = new Vector2(-halfExtend.x - 0.5f, 0);
        boxCollider2DArray[1].size = new Vector2(1f, halfExtend.y * 2.1f);

        // Up Side Wall
        boxCollider2DArray[2].offset = new Vector2(0, halfExtend.y + 0.5f);
        boxCollider2DArray[2].size = new Vector2(halfExtend.x * 2.1f, 1f);

        // Down Side Wall
        boxCollider2DArray[3].offset = new Vector2(0, -halfExtend.y - 0.5f);
        boxCollider2DArray[3].size = new Vector2(halfExtend.x * 2.1f, 1f);
    }

    public void SetAbility(Durian durian)
    {
        this.durian = durian;
    }

    public Vector2 GetNormalOfWall(Vector2 position)
    {
        float y = position.y - transform.position.y;
        float x = position.x - transform.position.x;
        float a = halfExtend.y / halfExtend.x;
        if (y > 0 && y >= a * x && y > -a * x)
        {
            return new Vector2(0, -1);
        }
        if (y <= 0 && y < a * x && y <= -a * x)
        {
            return new Vector2(0, 1);
        }
        if(x > 0 && y < a * x && y > -a * x)
        {
            return new Vector2(-1, 0);
        }
        if(x <= 0 && y >= a * x && y <= -a * x)
        {
            return new Vector2(1, 0);
        }
        return new Vector2(0, 0);
    }

    public bool checkBox(Vector2 position)
    {
        Vector2 origin = transform.position;
        return Mathf.Abs(position.x - origin.x) < halfExtend.x && Mathf.Abs(position.y - origin.y) < halfExtend.y; 
    }
}

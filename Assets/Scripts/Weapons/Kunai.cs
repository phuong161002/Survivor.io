using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Kunai", menuName = "Scriptable Objects/Weapon/Kunai")]
public class Kunai : Ability
{
    public float speed;
    private Vector2 direction;
    public GameObject kunaiPrefab;
    public float lifeTime;

    public override void Activate(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        if (player != null)
        {
            Enemy enemy = EnemySpawner.Instance.FindEnemy();
            if(enemy != null)
            {
                direction = (enemy.transform.position - player.transform.position).normalized;
                GameObject gameObject = PoolManager.Instance.ReuseObject(kunaiPrefab, player.transform.position,
                    Quaternion.FromToRotation(new Vector3(0, 1, 0), new Vector3(direction.x, direction.y, 0)));
                gameObject.SetActive(true);
                Bullet bullet = gameObject.GetComponent<Bullet>();
                bullet.SetDirection(direction);
                bullet.SetMoveSpeed(speed);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : MonoBehaviour
{
    [HideInInspector] public float flySpeed;
    [HideInInspector] public float lifeTime;
    [HideInInspector] public int quantity;
    [HideInInspector] public float spinSpeed;
    [HideInInspector] public float deltaTimeSpawn = 0.5f;
    private float spawnTimer;

    private List<BoomerangElement> boomerangElementList;

    private void Start()
    {
        boomerangElementList = new List<BoomerangElement>();
        spawnTimer = deltaTimeSpawn;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0f && boomerangElementList.Count < quantity)
        {
            spawnTimer = deltaTimeSpawn;
            InitBoomerangElement();
        }
    }

    private void InitBoomerangElement()
    {
        GameObject gO = Instantiate(GameAssets.Instance.boomerangElementPrefab, transform.position, Quaternion.identity);
        BoomerangElement boomerangElement = gO.GetComponent<BoomerangElement>();
        boomerangElement.flySpeed = flySpeed;
        boomerangElement.lifeTime = lifeTime;
        boomerangElement.spinSpeed = spinSpeed;
        boomerangElement.SetController(this);

        boomerangElementList.Add(boomerangElement);
    }

    public void RemoveBoomerang(BoomerangElement boomerangElement)
    {
        Destroy(boomerangElement.gameObject);
        boomerangElementList.Remove(boomerangElement);
    }

}

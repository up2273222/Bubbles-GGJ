using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform minX;
    public Transform maxX;
    public Transform spawnY;
    public float spawnTimerValue;
    private float spawnTimer;




    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Vector2 spawnPos = new Vector2(Random.Range(minX.position.x, maxX.position.x),spawnY.position.y);
            Instantiate(bubblePrefab, spawnPos, Quaternion.identity);
            spawnTimer = spawnTimerValue;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemySpawn; // enemy to be selected to be spawned
    public bool stopSpawning = false;
    public bool randomSpawning; // a bool to be enabled in the editor if randomspawning for a spawn point is needed
    public bool infiniteEnemies;// only check if infinite enemies are needed
    public float spawnTime;
    public float spawnDelay;
    public float range; // how close the enemy has to be to spawn
    private int enemyCount = 0;
    public int maxEnemies;// Max Enemies desired
    public Transform target;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    private void Update()
    {
        target = GameObject.Find("Yumi").transform; // Finds Yumi as the target
        distance = Vector3.Distance(this.transform.position, target.position);
        if (range <= distance)
        {
            stopSpawning = true;
        }
        else
        {
            stopSpawning = false;
        }
    }

    public void SpawnObject()
    {
        if (stopSpawning == false && enemyCount < maxEnemies) { 
            if (randomSpawning == true)
            {
                    Random random = new Random();
                    int randomNumber = Random.Range(0, 10);
                    if (infiniteEnemies == false)
                    {
                        enemyCount++;
                    }
                    StartCoroutine(RandomTime(randomNumber));
            }
            else
            { 
                Instantiate(enemySpawn, transform.position, transform.rotation);
                if (infiniteEnemies == false)
                {
                    enemyCount++;
                }
            }
        }
    }

    public void EnemyKilled()
    {
        enemyCount--;
        Debug.Log("Enemy count is now " + enemyCount);
    }

    IEnumerator RandomTime(float num)
    {

        yield return new WaitForSeconds(num);
        Instantiate(enemySpawn, transform.position, transform.rotation);
    }
    
}

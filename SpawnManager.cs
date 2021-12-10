using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bonus;
    public GameObject wall;
    private PlayerController player;

    private float spawnRange = 3f;
    private float spawnZ = 15f;
    private float spawnRangeWall = 6f;

    private float invokeTimeMax = 3f;
    private float bonusSpawnTimeMax = 20f;
    private float bonusSpawnTimeMin = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("SpawnBonus", Random.Range(bonusSpawnTimeMin, bonusSpawnTimeMax));
        Invoke("SpawnWall", Random.Range(0, invokeTimeMax));
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnBonus()
    {
        if (!player.gameOver)
        {
            float bonusPosX = Random.Range(-spawnRange, spawnRange);
            Vector3 bonusPos = new Vector3(bonusPosX, 1, spawnZ);
            int bonusNumber = Random.Range(0, bonus.Length);
            Instantiate(bonus[bonusNumber], bonusPos, bonus[bonusNumber].transform.rotation);
            float invokeTimeBonus = Random.Range(bonusSpawnTimeMin, bonusSpawnTimeMax);
            Invoke("SpawnBonus", invokeTimeBonus);
        }

    }
    void SpawnWall()
    {

        if (!player.gameOver)
        {
            float wallPosX = Random.Range(0, spawnRangeWall);
            Vector3 wallPos = new Vector3(wallPosX, 0, spawnZ);
            Instantiate(wall, wallPos, wall.transform.rotation);
            float invokeTimeWall = Random.Range(0, invokeTimeMax);
            Invoke("SpawnWall", invokeTimeWall);
        }

    }
}

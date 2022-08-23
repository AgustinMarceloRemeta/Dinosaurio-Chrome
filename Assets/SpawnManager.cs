using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] Spawns;
    [SerializeField] GameObject enemy;
    [SerializeField] float SpeedSpawn;
    public float SpeedEnemy, SpeedUp;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, SpeedSpawn);
    }

    
    void Update()
    {
        SpeedEnemy += SpeedUp * Time.deltaTime;
    }
    void SpawnEnemy()
    {
        int random = Random.Range(0, 2);
        Instantiate(enemy, Spawns[random].position, Quaternion.identity);
    }
}

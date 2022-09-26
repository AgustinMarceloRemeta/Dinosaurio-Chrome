using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] Spawns;
    public GameObject enemy1,enemy2;
    public float SpeedSpawn;
    public float SpeedEnemy, SpeedUp;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, SpeedSpawn);
    }

    
    void Update()
    {
     //   SpeedEnemy += SpeedUp * Time.deltaTime;
    }
    public void SpawnEnemy()
    {
        int random = Random.Range(0, Spawns.Length);
        if(random == 0)
        Instantiate(enemy1, Spawns[random].position, Quaternion.identity);
        else
        Instantiate(enemy2, Spawns[random].position, Quaternion.identity);
    }
}

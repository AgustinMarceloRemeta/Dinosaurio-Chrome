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
        List<GameObject> Enemys = new List<GameObject>(Resources.LoadAll<GameObject>("Enemy"));
        enemy1 = Enemys[0];
        enemy2 = Enemys[1];
        InvokeRepeating("SpawnEnemy", 0, SpeedSpawn);
    }

    
    void Update()
    {
       SpeedEnemy += SpeedUp * Time.deltaTime;
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

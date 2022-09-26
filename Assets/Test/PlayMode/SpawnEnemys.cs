using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnEnemys
{
    [UnityTest]
    public IEnumerator SpawnEnemysWithEnumeratorPasses()
    {
      
        GameObject spawner = new GameObject { };
        spawner.AddComponent<SpawnManager>();
        SpawnManager spm = spawner.GetComponent<SpawnManager>();
        Transform[] transforms = new Transform[1];
        transforms[0] = spawner.transform;
        spm.Spawns = transforms;
        spm.enemy1 = new GameObject { };
        spm.enemy2 = new GameObject { };
        spm.enemy1.tag = "Enemy";
        spm.enemy2.tag = "Enemy";
        spm.SpeedSpawn = 1000;
      
        int random = Random.Range(1, 6);
        for (int i = 0; i < random; i++) spm.SpawnEnemy();
       
        yield return new WaitForSeconds(2);

        Assert.AreEqual(random, GameObject.FindGameObjectsWithTag("Enemy").Length-3);
        
    }
}

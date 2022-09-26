using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnAndDestroy
{
    [UnityTest]
    public IEnumerator SpawnAndDestroyEnemys()
    {

        GameObject spawner = new GameObject { };
        spawner.transform.position = new Vector3(3, 0, 0);
        spawner.AddComponent<SpawnManager>();
        SpawnManager spm = spawner.GetComponent<SpawnManager>();
        Transform[] transforms = new Transform[1];
        transforms[0] = spawner.transform;
        
        spm.Spawns = transforms;
        spm.SpeedSpawn = 100000;
        spm.SpeedUp = 0;
        spm.SpeedEnemy = 4;

        GameObject destroyer = new GameObject { };
        destroyer.AddComponent<BoxCollider2D>();
        BoxCollider2D collider = destroyer.GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size.Set(2, 2);
        destroyer.name = "Destroy Enemy";
        destroyer.transform.position = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(1);
        spm.SpawnEnemy();
        spm.SpawnEnemy();
        spm.SpawnEnemy();
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Assert.AreEqual(3, enemys.Length);
        foreach (var item in enemys)
        {
            item.GetComponent<Enemy>().Speed = 6;
        }
        yield return new WaitForSeconds(6);
        Assert.AreEqual(0, GameObject.FindGameObjectsWithTag("Enemy").Length);
        Assert.IsTrue(destroyer.transform.position.x <= spawner.transform.position.x - 3);
    }
}

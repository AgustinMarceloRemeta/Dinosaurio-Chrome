using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JumpTest
{
    [UnityTest]
    public IEnumerator JumpTestWithEnumeratorPasses()
    {
        GameObject ground = new GameObject { };
        ground.transform.position = new Vector3(0, -1, 0);
        ground.AddComponent<BoxCollider2D>();
        ground.GetComponent<BoxCollider2D>().size.Set(5, 1);
        ground.name = "Piso";

        GameObject player = new GameObject { };
        player.AddComponent<BoxCollider2D>();
        player.AddComponent<Player>();
        player.AddComponent<Rigidbody2D>();
        player.transform.position= new Vector3(0, 0, 0);
        Player pl = player.GetComponent<Player>();
        pl.Speed = 20;


        yield return new WaitForSeconds(2);

        float fistPostition = player.transform.position.x;
        pl.movement();


        yield return new WaitForSeconds(0.5f);

        float secondPosition = player.transform.position.x;
        Assert.IsTrue(fistPostition < secondPosition);
        Assert.IsFalse(pl.Jump);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Speed = FindObjectOfType<SpawnManager>().SpeedEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Destroy Enemy") Destroy(this.gameObject);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null) GameManager.EventDead?.Invoke();
    }
}

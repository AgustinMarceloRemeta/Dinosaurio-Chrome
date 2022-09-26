using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb;
    public bool Jump;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0.1 || Input.GetKey("space")) movement();
    }
    public void movement()
    {
        if(Jump) {
        rb.AddForce(Vector2.up * Speed,ForceMode2D.Impulse);
        Jump = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Piso") Jump = true;
    }
}

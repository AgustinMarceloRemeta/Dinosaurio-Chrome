using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed;
    Rigidbody2D rb;
     bool Jump;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Jump) movement();
    }
    void movement()
    {
        if(Input.GetAxis("Vertical") > 0.1 || Input.GetKey("space")) {
        rb.AddForce(Vector2.up * Speed,ForceMode2D.Impulse);
        Jump = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Piso") Jump = true;
    }
}

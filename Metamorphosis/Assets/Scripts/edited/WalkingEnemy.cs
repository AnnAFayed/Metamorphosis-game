using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : EnemyController
{
    void FixedUpdate()
    {
        if (this.isFacingRight == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxspeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxspeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            flip();
        }
        else if (collider.tag == "Enemy")
        {
            flip();
        }
        if (collider.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            flip();
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

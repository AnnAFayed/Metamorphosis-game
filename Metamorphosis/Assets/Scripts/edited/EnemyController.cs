using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool isFacingRight = false;
    public float maxspeed = 3f;
    public int damage = 6;
    // Use this for initialization
    public void flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


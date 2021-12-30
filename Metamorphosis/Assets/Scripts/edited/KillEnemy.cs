using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour {
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			Destroy(enemy);
        }
		if (other.tag == "Bullet")
		{
			Destroy(enemy);
			Destroy(other.gameObject);

		}
	}
}

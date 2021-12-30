using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinFlyEnemy : MonoBehaviour
{
	public float HorizontalSpeed;
	public float VerticalSpeed;
	public float amplitude;
	private Vector3 temp_position;
	public float moveSpeed;
	private PlayerController player;
	public int damage;
	// Use this for initialization
	void Start () {
		temp_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
    {
		temp_position.x += HorizontalSpeed;
		temp_position.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
		transform.position = temp_position;

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<PlayerStats>().TakeDamage(damage);
		}
	}
}

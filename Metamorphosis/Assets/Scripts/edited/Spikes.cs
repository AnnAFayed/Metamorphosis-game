using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			FindObjectOfType<GameController>().RespawnPlayer();
	}
	// Update is called once per frame
	void Update()
	{

	}
}

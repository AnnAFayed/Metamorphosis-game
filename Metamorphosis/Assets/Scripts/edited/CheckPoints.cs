using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			FindObjectOfType<GameController>().CurrentCheckpoint = this.gameObject;
	}
	// Update is called once per frame
	void Update()
	{

	}
}

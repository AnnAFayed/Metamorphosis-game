using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : EnemyController {
	private PlayerController player;
	public float speedtowardplayer;
	private bool fliped=true;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > transform.position.x && fliped==true)
        {
			flip();
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedtowardplayer * Time.deltaTime);
			fliped = false;
		}
		//else if(player.transform.position.x < transform.position.x && fliped == true){
			//transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedtowardplayer * Time.deltaTime);
		//}
		else if (player.transform.position.x < transform.position.x && fliped == false)
		{
			flip();
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedtowardplayer * Time.deltaTime);
			fliped = true;
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedtowardplayer * Time.deltaTime);
		}
		
	}

}

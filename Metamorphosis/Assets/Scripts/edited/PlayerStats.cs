using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public int health = 6;
	public int lives = 3;
	public float flickerTime = 0f;
	public float flickerDuration = 0.1f;
	private SpriteRenderer spriteRenderer;
	public bool isImmune = false;
	public float immunityduration = 1.5f;
	public float immunityTime = 0f;
	public int coinsCollected =0;
	// Use this for initialization
	void Start () {
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}
	void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
			this.flickerTime += Time.deltaTime;
		else if(this.flickerTime >= this.flickerDuration)
        {
			spriteRenderer.enabled = !(spriteRenderer.enabled);
			this.flickerTime = 0;
        }
    }
	// Update is called once per frame
	void Update () {
        if (this.isImmune == true)
        {
			SpriteFlicker();
			immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityduration)
            {
				this.isImmune = false;
				this.spriteRenderer.enabled = true;
				Debug.Log("Immunity has ended");
            }
        }
	}
	void playHitReaction()
    {
		this.isImmune = true;
		this.immunityTime = 0f;
    }
	public void TakeDamage(int damage)
    {
		if (this.isImmune == false)
        {
			this.health = this.health - damage;
            if (this.health < 0f)
				this.health = 0;
			if(this.lives>0f && this.health == 0)
            {
				FindObjectOfType<GameController>().RespawnPlayer();
				this.health = 6;
				this.lives--;
            }
			else if(this.lives == 0f && this.health == 0)
            {
				Debug.Log("GameOver"); //write game over on console
				Destroy(this.gameObject);
            }
			Debug.Log("Player Health:" + this.health.ToString());
			Debug.Log("Player lives:" + this.lives.ToString());
		}
		playHitReaction();
	}

}

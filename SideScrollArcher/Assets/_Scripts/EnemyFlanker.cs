﻿using UnityEngine;
using System.Collections;

public class EnemyFlanker : MonoBehaviour {


	private EnemyFire enableShootingScript;
	private normalTargeting enableTargetingScript;
	private LootDrop droppings;
	//	private AudioSource [] _audioSources;
	//	private AudioSource _deathSound;
	//	private AudioSource _hitSound;
	/// /////////////////////////////////////////
	//Stats/Collision
	public float speed;
	PlayerStats playerStats;
	public float maxHealth;
	public float currentHealth;
	public float rechargeHealth;

	public float armour;

	public float maxShield;
	public float currentShield;
	public float rechargeShield;

	public float currentForceOfDamage;
	public float otherDamage;
	public float damage;
	private float diffuclty;
	Collision2D other;

	int xForRand;
	// Use this for initialization
	void Start () 
	{
		//	this._audioSources = gameObject.GetComponents<AudioSource> ();
		//	this._deathSound = this._audioSources [1];
		//	this._hitSound = this._audioSources [2];
		enableTargetingScript = GetComponent<normalTargeting> ();
		enableShootingScript = GetComponent<EnemyFire> ();
		droppings = GetComponent<LootDrop> ();
		//_currentPlayerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
		this._Reset ();


		/////////////////////////////////
		/// Stats Script
		diffuclty = 0;
		speed = 5;
		//player = GameObject.Find ("player");
		//this.playerStats = player.GetComponent<PlayerStats>();
		//otherDamage = playerStats.bulletDamage;
		maxHealth = 100;
		currentHealth = maxHealth;
		armour = 0;
		maxShield = 0;
		currentShield = maxShield;
		otherDamage = 50;
		damage =  10;

	}    

	// Update is called once per frame
	void Update () 
	{
		///////////////////////////////////////////
		/// Check for kill

		/////////////////////////////////////////////
		//moving
		//_currentPlayerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x += speed;
		gameObject.GetComponent<Transform> ().position = currentPosition;

		//if the players position is less than 60 units-whatever away from the enemies current position, speed = 0
		//px is 0, and the enemies position is 100, then if 100 < 0 + 100;

		if (currentPosition.x > -130) 
		{
			this.speed = 0.1f;
			this._fight ();
		} 
		if (currentPosition.x > 200) 
		{
			this._Reset();
			this.speed = 5;
		}
		if (currentPosition.y < -100 || currentPosition.y > 100) 
		{
			this._Reset ();
		}
		// Check horizontal boundary
		//if (currentPosition.x <= -1400)
		//{
		//	this._Reset();

		//}
	}


	private void _fight()
	{
		this.enableShootingScript.enabled = true;
		this.enableTargetingScript.enabled = true;
	}

	private void _Reset() 
	{
		var numberX = Random.Range(-1500, -1500);
		var numberY = Random.Range(-65, 65);
		//this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
		Vector2 resetPosition = new Vector2 (numberX, numberY);
		this.gameObject.GetComponent<Transform> ().position = resetPosition;
		this.speed = 5;
		this.enableShootingScript.enabled = false;
		this.enableTargetingScript.enabled = false;
	}



	/// /////////////////////////////////////////////////////////////////////////////////
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") 
		{//                                                        50 < 50 + 10
			//                                                         50 > 50 + 10	                                      

			Vector3 newPosition;
			newPosition = gameObject.GetComponent<Transform>().position;
			if (this.gameObject.GetComponent<Transform>().position.x < other.gameObject.GetComponent<Transform>().position.x)
			{
				newPosition.x -= 5;
				//newPosition.y -= 5;
			}

			if (this.gameObject.GetComponent<Transform>().position.x > other.gameObject.GetComponent<Transform>().position.x)
			{
				newPosition.x += 5;
				//newPosition.y += 5;
			}

			//newPosition.y = Random.Range(-90, 90);
			gameObject.GetComponent<Transform>().position = newPosition;

		}

		//Vector3 = otherPosistion = other.transform.position;
		if(other.gameObject.tag=="Bullet Ballistic")
		{
			//_hitSound.Play ();
			//Debug.Log ("collisionMaybe");
			//Destroy (this.gameObject);
			//this.otherDamage = playerStats.bulletDamage;

			float toBeTaken;
			if (currentShield > 1)
			{
				//To make sure the shield doesnt go below 0
				//         100 - (100 - 32) = 100 - 68 = 32
				toBeTaken = otherDamage - (otherDamage - currentShield);
				this.otherDamage = otherDamage - currentShield;
				this.currentShield -= toBeTaken;

			}

			this.currentHealth -= (otherDamage - this.armour);

			//Destroy (other.gameObject);

			if (this.currentHealth < 0) 
			{
				//_deathSound.Play ();
				//playerStats.currentScore += 10;
				droppings.rollLoot(this.gameObject.GetComponent<Transform>().position);
				this.diffuclty += 1;
				this.maxHealth = 100 + (1 * diffuclty);
				this.currentHealth = this.maxHealth;
				this._Reset ();
				//(gameObject);
			}
		}


	}
}
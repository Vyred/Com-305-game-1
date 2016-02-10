using UnityEngine;
using System.Collections;


public class Stats : MonoBehaviour {
    
	public GameObject player;
	public GameObject Enemy;
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
	//public float[] statArray = {maxHealth, currentHealth, rechargeHealth, armour, maxShield, currentShield, rechargeShield};

	// Use this for initialization
	void Start () 
	{
		diffuclty = 0;
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
		if (this.currentHealth < 0) 
		{
			var numberX = Random.Range(1470, 1400);
			var numberY = Random.Range(-65, 65);
			Vector2 resetPosition = new Vector2 (numberX, numberY);
			this.gameObject.GetComponent<Transform> ().position = resetPosition;
			diffuclty += 1;
			this.maxHealth = 100 + (1 * diffuclty);
			this.currentHealth = this.maxHealth;
			//(gameObject);
		}
		//OnCollisionEnter2D (other);
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Enemy") 
		{

			Vector3 newPosition;
			newPosition = gameObject.GetComponent<Transform> ().position;
			newPosition.y -= Random.Range(-90, 90);
			gameObject.GetComponent<Transform>().position = newPosition;
		
		}


		//Vector3 = otherPosistion = other.transform.position;
		if(other.gameObject.tag=="Bullet Ballistic")
		{
			//Debug.Log ("collisionMaybe");
			//Destroy (this.gameObject);
			//this.otherDamage = playerStats.bulletDamage;

			float toBeTaken;
			if (currentShield > 1)
			{
				//To make sure the shield doesnt go below 0
				//         100 - (100 - 32) = 100 - 68 = 32
				toBeTaken = otherDamage - (otherDamage - currentShield);
				otherDamage = otherDamage - currentShield;
				currentShield -= toBeTaken;

			}

			this.currentHealth -= otherDamage - this.armour;

			//Destroy (other.gameObject);


		}

	


	}
}

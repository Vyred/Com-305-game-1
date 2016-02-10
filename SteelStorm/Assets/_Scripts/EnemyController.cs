using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	// PUBLIC INSTANCE VARIABLES
	//public GameObject playerLocation;
	//private Vector2 _currentPlayerLocation;
	private EnemyFire enableShootingScript;
	private EnemyTargeting enableTargetingScript;
	private LootDrop droppings;
	private AudioSource[] _audioSources;
	private AudioSource _enemyCollisionSound;
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
		this._audioSources = gameObject.GetComponents<AudioSource> ();
		this._enemyCollisionSound = this._audioSources [0];
	//	this._audioSources = gameObject.GetComponents<AudioSource> ();
	//	this._deathSound = this._audioSources [1];
	//	this._hitSound = this._audioSources [2];
		enableTargetingScript = GetComponent<EnemyTargeting> ();
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
		currentPosition.x -= speed;
		gameObject.GetComponent<Transform> ().position = currentPosition;

		//if the players position is less than 60 units-whatever away from the enemies current position, speed = 0
		//px is 0, and the enemies position is 100, then if 100 < 0 + 100;

		if (currentPosition.x < 140) 
		{
			this.speed = 0.1f;
			this._fight ();
		} 
		if (currentPosition.x < -150)
		{
			this.speed = 5;
		}
		if (currentPosition.x < -200)
		{
			this._Reset ();
		}
		if (currentPosition.y < -150 || currentPosition.y > 140) 
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
		var numberX = Random.Range(1470, 1400);
		var numberY = Random.Range(-120, 120);
		this.transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
		Vector2 resetPosition = new Vector2 (numberX, numberY);
		this.gameObject.GetComponent<Transform> ().position = resetPosition;
		this.speed = 5;
		this.enableShootingScript.enabled = false;
		this.enableTargetingScript.enabled = false;
	}



	/// /////////////////////////////////////////////////////////////////////////////////
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player")
		{
			this._enemyCollisionSound.Play ();
			this._Reset ();
		}

		if (other.gameObject.tag == "Enemy") 
		{//                                                        50 < 50 + 10
		//                                                         50 > 50 + 10	                                      
		
			Vector3 newPosition;
			newPosition = gameObject.GetComponent<Transform>().position;
			//newPosition.y = Random.Range(-90, 90);
			if (this.gameObject.GetComponent<Transform>().position.x < other.gameObject.GetComponent<Transform>().position.x)
			{
				newPosition.x -= 5;
				//newPosition.y -= 5;
			}

			if (this.gameObject.GetComponent<Transform>().position.x > other.gameObject.GetComponent<Transform>().position.x+7)
			{
				newPosition.x += 5;
				//newPosition.y += 5;
			}

			//newPosition.y = Random.Range(-90, 90);
			//gameObject.GetComponent<Transform>().position = newPosition;
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
				this._enemyCollisionSound.Play ();
				//_deathSound.Play ();
				this.diffuclty += 1;
				this.maxHealth = 100 + (1 * diffuclty);
				this.currentHealth = this.maxHealth;
				droppings.rollLoot(this.gameObject.GetComponent<Transform>().position);
				this._Reset ();
				//(gameObject);
			}
		}

		///////////////////////////////////////////////////////////////////////////////////


}
}


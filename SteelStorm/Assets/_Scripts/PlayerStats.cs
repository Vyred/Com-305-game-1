using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

	public GameObject player;
	Collider2D other;

	public Text HealthLabel; 
	public Text ShieldLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Button RestartButton;


	private FireShot firing;
	private Move movingChar;
	/// <summary>
	/// ////////////////////////
	/// Health stat variables
	public float maxHealth;
	public float currentHealth;
	public float regenHealthDelay;
	//private float nextHealthDelay;
	private float regenHealthInterval;
	private float nextHealthRegenInterval;

	private float lastHitTaken;

	public float armour;

	public float maxShield;
	public float currentShield;
	public float regenShieldDelay;
	//private float nextShieldDelay;
	private float regenShieldInterval;
	private float nextShieldRegenInterval;


	public float currentForceOfDamage;
	public float otherDamage;
	public float bulletDamage;

	public float currentScore;
	private float timeRunning;
	private float changeInTime;
	private bool deadOrAlive;
	// Use this for initialization
	void Start () 
	{
		
		deadOrAlive = true;
		maxHealth = 100;
		currentHealth = maxHealth;
		regenHealthDelay = 5;
		regenHealthInterval = 0.5f;
		nextHealthRegenInterval = 0;
		armour = 5;

		maxShield = 100;
		currentShield = maxShield;
		regenShieldDelay = 3;
		regenShieldInterval = 0.33f;
		//nextShieldRegenInterval = 0;

		bulletDamage = 40;
		otherDamage = 15;


		this.GameOverLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{
		/////////////////////////////////////////////////////////////////////////////
		/// 
		if (deadOrAlive == true)
		{
			timeRunning += Time.time;
		}
		this.currentScore = timeRunning/10000; 
		this.HealthLabel.text = "Health: " + this.currentHealth +"/" + this.maxHealth;
		this.ShieldLabel.text = "Shield: " + this.currentShield + "/" + this.maxShield;
		this.ScoreLabel.text = "Score: " + currentScore;
		/////////////////////////////////////////////////////////////////////////////
		/// CHECK FOR DEATH
		if (this.currentHealth < 0) 
		{
			this._endGame ();
			this.currentHealth = this.maxHealth;
			Debug.Log ("You Died");
			//(gameObject);
		}
		/////////////////////////////////////////////////////////////////
		///SHIELD REGEN	
		if (Time.time > lastHitTaken + regenShieldDelay && currentShield < maxShield)
		{
			
		if (Time.time > nextShieldRegenInterval)
	     	{
				nextShieldRegenInterval = Time.time + regenShieldInterval;
				currentShield++;
			}
		}

		/////////////////////////////////////////////////////////////////
		/// HEALTH REGEN
		if (Time.time > lastHitTaken + regenHealthDelay && currentHealth < maxHealth)
		{
			//nextHealthRegenInterval = Time.time + regenHealthDelay;

		if (Time.time > nextHealthRegenInterval)
		{
			nextHealthRegenInterval= Time.time + regenHealthInterval;
				currentHealth++;
		}
		}
		//////////////////////////////////////////////////////////////////
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") 
		{

		//	Vector3 newPosition;
		//	newPosition = gameObject.GetComponent<Transform> ().position;
		//	newPosition.y -= Random.Range(-90, 90);
		//	gameObject.GetComponent<Transform>().position = newPosition;

			float toBeTaken = 25;
			if (currentShield > 1)
			{
				//To make sure the shield doesnt go below 0
				//         100 - (100 - 32) = 100 - 68 = 32
				this.currentShield -= toBeTaken;
				toBeTaken -= this.currentShield;

				if (toBeTaken <= 0) 
				{
					toBeTaken = 0;
				}
			}

			if (toBeTaken - this.armour > 0)
			{
				this.currentHealth -= toBeTaken - this.armour;
			}

		}

		//////////////////////////////////////////////////////////////////
		//Vector3 = otherPosistion = other.transform.position;
		//DAMAGE TAKEN	
		if(other.gameObject.tag=="Enemy Ballistic")
		{
			
			currentScore -= 5;
			Destroy (other.gameObject);
			this.lastHitTaken = Time.time;
			//Debug.Log ("health:" + currentHealth);
			//Debug.Log ("shield:" + currentShield);

			//Destroy (this.gameObject);
			//this.otherDamage = playerStats.bulletDamage;

			float toBeTaken = otherDamage;
			if (currentShield > 1)
			{
				//To make sure the shield doesnt go below 0
				//         100 - (100 - 32) = 100 - 68 = 32
				this.currentShield -= toBeTaken;
				toBeTaken -= this.currentShield;

				if (toBeTaken <= 0) 
				{
					toBeTaken = 0;
				}
			}

			if (toBeTaken - this.armour > 0)
			{
				this.currentHealth -= toBeTaken - this.armour;
			}
			Destroy (other.gameObject);
		}
			/////////////////////////////////////////////////////////////////
			if (other.gameObject.tag == "FireRateDrop") 
			{
			this.gameObject.GetComponent<FireShot> ().fireRate -= 0.01f; 
			DestroyObject (other.gameObject);
				//Destroy(other.gameObject);
			    //Debug.Log ("pickedUpDrop");
			}

			if (other.gameObject.tag == "HealthUp") 
			{
			this.maxHealth += 10;
			DestroyObject (other.gameObject);
			//Debug.Log ("pickedUpDrop");
				//Destroy(other.gameObject);
			}

			if (other.gameObject.tag == "ShieldUp") 
			{
			this.maxShield += 10;
			DestroyObject (other.gameObject);
				//Destroy(other.gameObject);
			//Debug.Log ("pickedUpDrop");
			}

			if (other.gameObject.tag == "VelocityDrop") 
			{
			//this.gameObject.GetComponent<ShotMove>().speed += 0.25f;
			DestroyObject (other.gameObject);
			//does nothing atm
			//Destroy(other.gameObject);
			//Debug.Log ("pickedUpDrop");
			}

			if (other.gameObject.tag == "ArmourUp") 
			{
			this.armour += 0.1f;
			DestroyObject (other.gameObject);
				
				//Destroy(other.gameObject);
			//Debug.Log ("pickedUpDrop");

			}
        

	}

	public void restartGameEvent ()
	{
		
		SceneManager.LoadScene(SceneManager.GetActiveScene ().name);
		Time.timeScale = 1.0f;
		deadOrAlive = true;
	}


	private void _endGame()
	{
		Time.timeScale = 0.0f;
		deadOrAlive	= false;
		this.HealthLabel.gameObject.SetActive (false);
		this.ShieldLabel.gameObject.SetActive (false);

		this.GameOverLabel.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive (true);

	}

}




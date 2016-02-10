using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	//
	public GameObject enemy;
	public GameObject enemyFlanker;

	//[SerializeField]
	private AudioSource[] _audioSources;
	private AudioSource backgroundSound;


	public int enemyNumber; 


	//private GameObject [] enemyArray = new GameObject [50];
	//public EnemyController enemy; 
	//public EnemyController [] enemyArray = {enemy, enemy, enemy, enemy, enemy, enemy};
	//enemy [] enemyG; 
	//public Stats enemy;
	private float _scoreValue;
	private float _healthValue;
	private float _shieldValue;


	public float scoreValue
	{
		get 
		{
			return this._scoreValue;
		}

		set 
		{
			this._scoreValue = value;
		}
	}

	public float healthValue
	{
		get { return this._healthValue; }
		set { this._healthValue = value;}
	}

	public float ShieldValue
	{
		get {return this._shieldValue; }
		set {this._shieldValue = value;}
	}




    // Use this for initialization
    void Start()
    {


		this._audioSources = gameObject.GetComponents<AudioSource> ();
		this.backgroundSound = this._audioSources [0];
		backgroundSound.loop = true;
		enemyNumber = 5;
        _initialize();


    }

    // Update is called once per frame
    void Update()
    {
		
    }

    private void _initialize()
    {
		

        for (int enemyCount = 0; enemyCount < enemyNumber; enemyCount++)
        {
		//    enemyArray [enemyCount] = enemy;
		//	Instantiate (enemyArray [enemyCount]);
			Instantiate (enemy);
        }
		Instantiate (enemyFlanker);
		this._scoreValue = 0;

    }



}

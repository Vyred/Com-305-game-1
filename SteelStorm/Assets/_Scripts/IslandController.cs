using UnityEngine;
using System.Collections;


public class IslandController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	//public GameObject playerLocation;
	private Vector2 _currentPlayerLocation;
	private EnemyFire enableShootingScript;
	private EnemyTargeting enableTargetingScript;

	public float speed;

    int xForRand;
	// Use this for initialization
	void Start () 
	{
		enableTargetingScript = GetComponent<EnemyTargeting> ();
		enableShootingScript = GetComponent<EnemyFire> ();
		_currentPlayerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
		this._Reset ();


	}    
	
	// Update is called once per frame
	void Update () 
	{
		
		_currentPlayerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x -= speed;
        gameObject.GetComponent<Transform> ().position = currentPosition;

		//if the players position is less than 60 units-whatever away from the enemies current position, speed = 0
		//px is 0, and the enemies position is 100, then if 100 < 0 + 100;
		if (currentPosition.x < _currentPlayerLocation.x + 200)
		{
			speed = 0.1f;
			_fight ();
		}
		// Check horizontal boundary
		if (currentPosition.x <= -1400) {
			this._Reset();
		
		}
	}


	private void _fight()
	{
		enableShootingScript.enabled = enableShootingScript.enabled;
		enableTargetingScript.enabled = enableTargetingScript.enabled;
	}

	private void _Reset() 
	{
        var numberX = Random.Range(1470, 1400);
        var numberY = Random.Range(-65, 65);
        Vector2 resetPosition = new Vector2 (numberX, numberY);
		gameObject.GetComponent<Transform> ().position = resetPosition;

		enableShootingScript.enabled = !enableShootingScript.enabled;
		enableTargetingScript.enabled = !enableTargetingScript.enabled;
	}
}

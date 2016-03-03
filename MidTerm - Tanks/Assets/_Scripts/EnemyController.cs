using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}



public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Boundary boundary;
	public Text Score;
	float currentScore;

	// PRIVATE INSTANCE VARIABLES
	private float _CurrentSpeed;
	private float _CurrentDrift;

	// Use this for initialization
	void Start () {
		this._Reset ();
		Score.text = 0.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= this._CurrentSpeed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		// Check bottom boundary
		if (currentPosition.y <= boundary.yMin) 
		{
			this._Reset();
			currentScore += 10;
			Score.text = (currentScore).ToString();
		}
	}

	void OnCollisionEnter2D(Collision2D otherCollision)
	{
		if (otherCollision.gameObject.CompareTag("Player"))
		{
			this._Reset();

		}
	}

	// resets the gameObject
	private void _Reset() 
	{
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		Vector2 resetPosition = new Vector2 (Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
		gameObject.GetComponent<Transform> ().position = resetPosition;

	}
}

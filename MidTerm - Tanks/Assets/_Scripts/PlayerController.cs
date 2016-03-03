using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class PlayerController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
	public float speed;
	public Boundary boundary;
	public Text Score;
	public Text Health;
	public Button RestartButton;
	private float healthF;
	private AudioSource[]_audioSo;
	private AudioSource _contact;
	//private bool alive;

	// get a reference to the camera to make mouse input work
	public Camera camera; 
	
	// PRIVATE INSTANCE VARIABLES
	private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
	
	// Use this for initialization
	void Start ()
	{
		this._audioSo = gameObject.GetComponents<AudioSource> ();
		this._contact = this._audioSo [0];
		this._audioSo = gameObject.GetComponents<AudioSource> ();
		healthF = 5;
		Health.text = healthF.ToString();
		//alive = true;
		this.RestartButton.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		this._CheckInput ();
	}

	private void _CheckInput() {
		this._newPosition = gameObject.GetComponent<Transform> ().position; // current position

		/* movement by keyboard
		if (Input.GetAxis ("Horizontal") > 0) {
			this._newPosition.x += this.speed; // add move value to current position
		}
	
		
		if (Input.GetAxis ("Horizontal") < 0) {
			this._newPosition.x -= this.speed; // subtract move value to current position
		}
		*/

		// movement by mouse
		Vector2 mousePosition = Input.mousePosition;
		this._newPosition.x = this.camera.ScreenToWorldPoint (mousePosition).x;

		this._BoundaryCheck ();

		gameObject.GetComponent<Transform>().position = this._newPosition;
	}

	private void _BoundaryCheck() {
		if (this._newPosition.x < this.boundary.xMin) {
			this._newPosition.x = this.boundary.xMin;
		}

		if (this._newPosition.x > this.boundary.xMax) {
			this._newPosition.x = this.boundary.xMax;
		}
	}

	void OnCollisionEnter2D(Collision2D otherCollision)
	{
		if (otherCollision.gameObject.CompareTag("Enemy"))
		{
			this.healthF--;
			Health.text = healthF.ToString ();
			if (healthF <=0)
			{
				endGame ();
			}
			_contact.Play ();

		}
	}

	private void endGame()
	{
		Time.timeScale = 0.0f;
		this.Health.gameObject.SetActive (false);
		this.Score.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (true);
	}

	public void resetGameEvent()
	{
		EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene().name);
	}
}

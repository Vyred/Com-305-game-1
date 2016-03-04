using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	Vector3 dir; 
	private Transform _transform;
	private Rigidbody2D _rigidbody2D;
	private bool _facingRight;
	private AudioSource[] _audioSource;
	private AudioSource _soundContactFloor; 

	// Use this for initialization
	void Start () 
	{
		this._audioSource = gameObject.GetComponents<AudioSource> ();
		this._soundContactFloor = this._audioSource[0];

		this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		this._transform = gameObject.GetComponent<Transform> ();
		this._facingRight = true;
	}

	void FixedUpdate()
	{
		float forceX = 0;
		//float forceY = 0;
		if (_facingRight == true)
		{
			forceX += 10;
		}
		if (_facingRight == false)
		{
			forceX -= 10;
		}

		if (onGroundCheck()==false && _facingRight == true)
		{
			_facingRight = false;
		}
		if (onGroundCheck()==false && _facingRight == false)
		{
			_facingRight = true;
		}

		flipSprite();



		//_rigidbody2D.AddForce(new Vector2(forceX, forceY) , ForceMode2D.Impulse);
		Vector2 moveTo = gameObject.GetComponent<Transform> ().position;
		moveTo.x += forceX;
		_transform.position = moveTo;

	}

	// Update is called once per frame
	void Update () 
	{

	}
		
	private void flipSprite()
	{
		if (this._facingRight == true) 
		{
			this._transform.localScale = new Vector3 (1f, 1f, 1f);
		}
		else 
		{
			this._transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}


	void OnCollisionEnter2D (Collision2D otherCollision)
	{
		if (otherCollision.gameObject.CompareTag ("Wall")) 
		{
			//Debug.Log ("ok");

			if (this._facingRight == false) {
				//Debug.Log ("ok");
				this._facingRight = true;
			} 
			else
			{
				this._facingRight = false;
			}
		}

		if (otherCollision.gameObject.CompareTag ("Player")) 
		{
			_soundContactFloor.Play ();
		}

	}
	 
	private bool onGroundCheck()
	{ 
		float Y = this._transform.position.y - 390;
		float X = this._transform.position.x;
		if (_facingRight == true)
		{
		 X = this._transform.position.x + 300;
		}

		if (_facingRight == false)
		{
	    X = this._transform.position.x - 300;
		}
		dir = new Vector3(X, Y, 0);
		float distance = 1000000;
		//Vector3 sentTo = new Vector3 (X, Y- 100, 0);
		Debug.DrawRay (dir, -Vector2.up, Color.red);//Vector2.up,
		//RayCasts (Starting location, direction, distance, layer)
		RaycastHit2D contactPointR = Physics2D.Raycast (dir,  -Vector2.up, 200);

		if (contactPointR == false)
		{
		//	Debug.Log ("return false");
			distance = Mathf.Abs (contactPointR.point.y - this._transform.position.y + 390);
			return false;
		}
		else 
		{
		//	Debug.Log ("return true");
			return true;	
		}
		//return Physics.Raycast ();
	}


}

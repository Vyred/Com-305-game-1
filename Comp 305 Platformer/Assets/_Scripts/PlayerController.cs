using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
//Player Controls and Collision
public class PlayerController : MonoBehaviour {

	Vector3 dir; 
	private Rigidbody2D _rigidbody2D;
	private Transform _transform;
	private Animator _animator;
	private int _currentAnimation;
	//1 idle, 2 run, 3 jump
	public Collider2D footCollider;
	public Collider2D characterCollider;
	private bool IFrame;

	public Transform _playerSpawn;
	public float speed;
	float currentSpeed;
	public float topSpeed;

	private float _floorAngle;
	private float _distanceToGround;
	private float _movingHorizontal;
	private float _movingVertical;
	private bool _touchingGround;
	private bool _facingRight;
	private bool _jumping;
	private float _jumpRecovery;
	private float _nextJumpTime;

	private float _possibleJumps;
	private float _wallJumpCount;
	private bool _touchingWall;

	//UI
	public float _score;
	private float _gameFinsished;
	//audio
	private AudioSource[] _audioSource;
	private AudioSource _soundContactFloor; 

	// Use this for initialization
	void Start () 
	{
		this._audioSource = gameObject.GetComponents<AudioSource> ();
		this._soundContactFloor = this._audioSource[0];
		//this._audioSource = gameObject.GetComponents<AudioSource> ();

		this._distanceToGround = GetComponent<Collider2D>().bounds.extents.y;//collider.bounds.extents.y;
		this.characterCollider = GetComponentInChildren<Collider2D>();
		this.footCollider = GetComponentInChildren<Collider2D>();
		//this._floorAngle = Quaternion.Angle (Quaternion.Euler (new Vector3 (0, 0, 0)), transform.rotation);

		this._playerSpawn = gameObject.GetComponent<Transform>();
		this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator>();
		this._touchingGround = false;
		this._facingRight = true;
		this.currentSpeed = speed;
		this._currentAnimation = 4;
		this._jumping = false;
		this._jumpRecovery = 100;
		this._nextJumpTime = 0;
		this._distanceToGround = -1000;
		this._possibleJumps = 5;
		this._wallJumpCount = _possibleJumps;
		this._touchingWall = false;
		this.IFrame = false;


	}

	void FixedUpdate()
	{
		float forceX = 0;
		float forceY = 0;

		this._movingHorizontal = Input.GetAxis ("Horizontal");
		this._movingVertical   = Input.GetAxis ("Vertical");

		//idle
		if (this._touchingGround == true && onGround() == true && this._movingHorizontal == 0)
		{
			_currentAnimation = 1;
			this._animator.SetInteger ("currentAnimation", _currentAnimation);
		}
		//changes/checks the players sprite direction and locaion

		//falling
		if (this._touchingGround == false && onGround() == false)
		{
			_currentAnimation = 4;
			this._animator.SetInteger ("currentAnimation", _currentAnimation);
		}



		if (_movingVertical != 0  && (_touchingGround == true && onGround() == true))
		{
			if (_movingVertical > 0)
			{
			this._touchingGround = false;
			forceY += 500000;
			}
		}

		if (_movingVertical != 0  && _touchingGround != true && _wallJumpCount > 0 && _touchingWall)
		{
			if (_movingVertical > 0)
			{
				this._touchingWall = false;
				this._wallJumpCount--;
				forceY += 500000;
			}
		}

		if (_movingHorizontal != 0)
		{
			//              
			if (_touchingGround == true && onGround () == true && _movingHorizontal != 0) {
				_currentAnimation = 2;
				this._animator.SetInteger ("currentAnimation", _currentAnimation);
			} 
			else 
			{
				_currentAnimation = 4;
				this._animator.SetInteger ("currentAnimation", _currentAnimation);
			}

			if (_movingHorizontal > 0)
			{
				_facingRight = true;
				forceX += 2000 * currentSpeed;
				currentSpeed++;
				//forceX += 1000 * speed; 
			}

			if (_movingHorizontal < 0)
			{
				_facingRight = false;
				forceX -= 2000 * currentSpeed;
				currentSpeed++;
			}


			if(currentSpeed >= topSpeed)
			{
				currentSpeed = topSpeed;
			}

		}

		if (_movingHorizontal == 0)
		{
			currentSpeed = speed;
		}

		_flipSprite ();
		_rigidbody2D.AddForce(new Vector2(forceX, forceY) );

	}

	//this is code i found on the unity forums and have adapted for my owns
	//Basically sends a raycast below the playerto check if they're on the ground





	private bool onGround()
	{ 
		float Y = this._transform.position.y - 390;
		float X = this._transform.position.x;
		dir = new Vector3(X, Y, 0);
		float distance = 1000000;
		//Vector3 sentTo = new Vector3 (X, Y- 100, 0);
		//Debug.DrawRay (dir, -Vector2.up, Color.green);//Vector2.up,
		RaycastHit2D contactPointR = Physics2D.Raycast (dir,  -Vector2.up, 50, 49);

		if (contactPointR != false)
		{
			distance = Mathf.Abs (contactPointR.point.y - this._transform.position.y + 390);

		}


	//	if(contactPointR != true)
	//	{
	//		Debug.Log ("return false");	
	//		Debug.Log ("distance " + distance + "Contact " + contactPointR.point.y );
	//	}
	//	if (contactPointR == true)
	//	{
	//		Debug.Log ("distance " + distance + "Contact " + contactPointR.point.y );
	//	}


		if (distance > -20 && distance < 20) 
		{
			//Debug.Log ("return true");
			return true;
		} 
		else 
		{
			//Debug.Log ("return false");
			return false;	
		}
		//return Physics.Raycast ();
	}

	// Update is called once per frame
	void Update ()
	{
		
		//Vector2 = new Vector2 ();
		//dir = new Vector3(0, -370, 0);
		//Debug.DrawRay (Vector2(X,Y),dir, Color.green, 1 );
	
	//	if (Input.GetKeyDown(KeyCode.Space) && onGround())
	//	{
	//		this._rigidbody2D.AddForce(new Vector2(0, 500000));
	//		Debug.Log ("ok");
	//	}

	//	OnControllerColliderHit (this.footCollider);

		//if (canJump == false)
		//{
		//	Debug.Log ("touching = false");
		//}

		//if (canJump == true)
		//{
		//	Debug.Log ("touching = true");
		//}
	}
		
	//bool canJump = false;


	/*void  OnControllerColliderHit(  hit)
	{
		Debug.Log ("running");

		if( hit.normal.y >= 0.6 || hit.normal.y < 0.6)
		{
			canJump = false;
		} 
		else
		{
			canJump = true;
		}
	}
*/

	/// <summary>
	/// /////////////////////////////////////////////////////////////////////////////
	/// </summary>
	/// <param name="otherCollision">Other collision.</param>
	void OnCollisionStay2D (Collision2D otherCollision)
	{
		//Debug.Log("running");
		if (otherCollision.gameObject.CompareTag ("SolidFloor") || otherCollision.gameObject.CompareTag ("") || otherCollision.gameObject.CompareTag ("SolidFloor")) 
		{
			this._floorAngle = otherCollision.gameObject.transform.eulerAngles.z;
			//Debug.Log ("floor angle = " + _floorAngle);
			if (Time.time > _nextJumpTime && footCollider.IsTouching (otherCollision.collider) && this._transform.position.y > otherCollision.rigidbody.position.y)
			if (_touchingGround == false) 
			{
				this._nextJumpTime = Time.time + _jumpRecovery;
			}
			this._wallJumpCount = _possibleJumps;

			if (this._touchingGround == false)
			{
				_soundContactFloor.Play ();
			}
			this._touchingGround = true;
		}
		else
		{
			this._touchingGround = false;
		}
		////////////////////////////////////////////////////////////////////////////
		if (otherCollision.gameObject.CompareTag ("Wall")) 
		{
			this._touchingWall = true;
		} 
		else 
		{
			this._touchingWall = false;
		}
		/////////////////////////////////////////////////////////////////////////////
		if (otherCollision.gameObject.CompareTag ("DeathBound"))
		{
			//float X = _playerSpawn.GetComponent<Transform>().position;
			//float Y = _playerSpawn.position.y;
			//Vector2 tr = new Vector2(X,Y);
			//Debug.Log(_playerSpawn.position);
			this.gameObject.GetComponent<Transform>().position = new Vector2(-23000, -3550);
			restartGameEvent ();
		}

		if (otherCollision.gameObject.CompareTag ("Enemy") && IFrame == false)
		{
			this.gameObject.GetComponent<Transform>().position = new Vector2(-23000, -3550);
			restartGameEvent ();
		}
	}
	/// <summary>
	/// ////////////////////////////////////////////////////////////////////////////////////////
	/// </summary>
	private void _flipSprite()
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

	public void restartGameEvent()
	{
		EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene().name);
	}
}




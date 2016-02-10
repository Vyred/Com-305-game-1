using UnityEngine;
using System.Collections;
//using System;

public class ShotMove : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
//	private float speedX;
//	private float speedY;
	Vector2 _position;
	Vector2 _positionStart;
//	Quaternion _rotation;
	public float TCDamageBallistic;
	//private getComponent<GameObject> gO;
	//public GameObject shot;
	float rotationZ;

	public float _speed
	{
		get{return this.speed ;}
		set{this.speed = value ;}
	}

    // Use this for initialization
    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		_positionStart = rb.position;
		rotationZ = rb.transform.eulerAngles.z;
		//_rotation = rb.transform.localRotation;
		//TCDamageBallistic = gameObject.GetComponent<>();//PlayerStats.damageBallistic;

		//Console.writeline (" ");
		//Debug.Log(rotationZ);

//		float angle = Mathf.PI * rotationZ / 180;
	//	speedX = Mathf.Sin (angle) * speed;
	//	speedY = Mathf.Cos (angle) * speed;
		this.rb.AddForce (transform.right * speed);
		//this.rb.AddForce(_rotation * speed, _rotation);

    }                                 


	void Update ()
	{
		//better way using x + y
		//this makes firing at 45 degrees fire the farthest  
		if (rb.position.y > _positionStart.y + 500 || rb.position.y < _positionStart.y - 500 )
		{
			Destroy (this.gameObject);
		}
		if (rb.position.x > _positionStart.x + 500 || rb.position.x < _positionStart.x - 500 )
		{
			Destroy (this.gameObject);
		}

	}
	/*void Update()
	{
		
		if ((rotationZ <= 90 && rotationZ > 0) || (rotationZ >= 270 && rotationZ <= 360))
		{
			this.rb.AddForce (transform.right * speed) ;
			//_position.x += speedX;
			//_position.y += speedY;
		}

		if ((rotationZ > 90 && rotationZ < 270) )
		{
			this.rb.AddForce (transform.right * speed) ;
			//_position.x -= speedX;
			//_position.y -= speedY;
		}
		//this.rb.AddForce (transform.up * speedX);

		if (rotationZ < 360 && rotationZ > 180)
		{
			//this.rb.AddForce (-transform.up * speedX);
			//_position.x += speedX;
			//_position.y += speedY;
		}

		if (rotationZ < 180 && rotationZ > 0)
		{
			//this.rb.AddForce (transform.up * speedX);
			//_position.x += speedX;
			//_position.y += speedY;
		}

		//_position.x += speedX;
		//_position.y += speedY;
		//rb.position = _position;
 	}
*/

	static double ToRadians(double val)
	{
		return (Mathf.PI / 180) * val;
	}

	static double ToDegrees(double val)
	{
		return (180 / Mathf.PI) * val;
	}
}


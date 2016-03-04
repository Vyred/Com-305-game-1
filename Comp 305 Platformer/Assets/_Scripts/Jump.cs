using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	RaycastHit2D hit;
	float dist;
	float liftForce;
	float damping;
//	private Rigidbody2D rb2D;
	Vector3 dir;
	// Use this for initialization
	void Start ()
	{
		
		//rb2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		hit = Physics2D.Raycast (transform.position, -Vector2.up);
		if (hit.collider != null)
		{
			float distance = Mathf.Abs (hit.point.y - transform.position.y);

		}
	}
	// Update is called once per frame
	void Update () 
	{
		
		//dist = 10;
		dir = new Vector3(0, -400, 0);
		Debug.DrawRay (transform.position,dir, Color.green);
		//if (Physics.Raycast(transform.position,dir,hit)) 
//		{
		//	Debug.Log("ok");
	//	}
	}
}

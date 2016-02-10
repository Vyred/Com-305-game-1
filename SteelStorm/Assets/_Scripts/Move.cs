using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    // Use this for initialization
    public Vector2 move = new Vector2(0.0f, 0.0f);
    public int boundMinX, boundMaxX, boundMinY, boundMaxY;

    private Vector2 newPosition = new Vector2(00f, 0.0f);

	private float speedAdd;
	public float _speedAdd
	{
		get { return speedAdd; }
		set { this.speedAdd = value;}
	}
	void Start ()
    {
     
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        newPosition = gameObject.GetComponent<Transform>().position;

     if (Input.GetAxis ("Horizontal") > 0 && gameObject.GetComponent<Transform>().position.x < boundMaxX)
        {
            newPosition.x += this.move.x;
            gameObject.GetComponent<Transform>().position = newPosition;
        }

        if (Input.GetAxis("Horizontal") < 0 && gameObject.GetComponent<Transform>().position.x > boundMinX)
        {
            newPosition.x -= this.move.x;
            gameObject.GetComponent<Transform>().position = newPosition;
        }
        ///////////////////////////////////////////////////////////////////////
        if (Input.GetAxis("Vertical") > 0 && gameObject.GetComponent<Transform>().position.y < boundMaxY)
        {
            newPosition.y += this.move.y;
            gameObject.GetComponent<Transform>().position = newPosition;
        }

        if (Input.GetAxis("Vertical") < 0 && gameObject.GetComponent<Transform>().position.y > boundMinY)
        {
            newPosition.y -= this.move.y;
            gameObject.GetComponent<Transform>().position = newPosition;
        }


    }
}

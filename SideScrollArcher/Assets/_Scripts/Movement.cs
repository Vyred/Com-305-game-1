using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    // Use this for initialization
    public Vector3 move = new Vector3(0.0f, 0.0f, -10.0f);

    private Vector3 newPosition = new Vector3(00f, 0.0f, -10.0f);
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        newPosition = gameObject.GetComponent<Transform>().position;

        if (Input.GetAxis("Horizontal") > 0)
        {
            newPosition.x += this.move.x;
            newPosition.z = -10.0f;
            gameObject.GetComponent<Transform>().position = newPosition;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            newPosition.x -= this.move.x;
            newPosition.z = -10.0f;
            gameObject.GetComponent<Transform>().position = newPosition;
        }
        ///////////////////////////////////////////////////////////////////////
        if (Input.GetAxis("Vertical") > 0)
        {
            newPosition.y += this.move.y;
            newPosition.z = -10.0f;
            gameObject.GetComponent<Transform>().position = newPosition;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            newPosition.y -= this.move.y;
            newPosition.z = -10.0f;
            gameObject.GetComponent<Transform>().position = newPosition;
        }
    }
    }

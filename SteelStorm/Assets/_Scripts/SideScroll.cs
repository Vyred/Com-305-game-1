using UnityEngine;
using System.Collections;

public class SideScroll : MonoBehaviour {

    public float boundX, boundY;
    public float speed;
    private Transform _transform;
    private Vector2 _currentPosition;
	// Use this for initialization
	void Start ()
    {
        this._transform = gameObject.GetComponent<Transform>();
        this.Reset();
        
	}

    public void Reset()
    {
        this._transform.position = new Vector2(1800f, 00f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        this._currentPosition = this.transform.position;
        this._currentPosition.x -= speed;
        this._transform.position = this._currentPosition;

        if(this._currentPosition.x <= -1800)
        {
         this.Reset();
        }
	}
}

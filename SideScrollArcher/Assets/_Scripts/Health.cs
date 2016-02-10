using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float _health;
	public float _shield;
	// Use this for initialization
	void Start () 
	{
		_health = 100;
		_shield = 100;

	}
	
	// Update is called once per frame

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "") 
		{
			
		}	
	}

	void Update ()
	{
		
	}
}

﻿using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Vector2 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
	    }

	}
}

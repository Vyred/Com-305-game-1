using UnityEngine;
using System.Collections;

public class FireShot : MonoBehaviour {


	public GameObject shot;
	public Transform shotSpawnA;
	public Transform shotSpawnB;
	private AudioSource[] _audioSources;
	private AudioSource _gunShot;
	//public Transform shotSpawnMiddle;
	private int WeaponRotation;
	private float _fireRate;
	private float nextFire;
	 
	public float fireRate
	{
		get {return this._fireRate ;}
		set {this._fireRate = value ;}
	}
		
	// Use this for initialization
	void Start () 
	{
		WeaponRotation = 0;
		_fireRate = 0.30f;
		this._audioSources = gameObject.GetComponents<AudioSource> ();
		this._gunShot = this._audioSources [0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (Input.GetButton("Fire1") && Time.time > nextFire && WeaponRotation == 0)
		{
			this._gunShot.Play();
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawnA.position, shotSpawnA.rotation);
			WeaponRotation++;
			//ShotMove allow = new ShotMove ();//.moveShot(targetPos);
			//allow.moveShot(targetPos, 30);

		}

		if (Input.GetButton("Fire1") && Time.time > nextFire && WeaponRotation == 1)
		{
			this._gunShot.Play();
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawnB.position, shotSpawnB.rotation);
			WeaponRotation--;
			//ShotMove allow = new ShotMove ();//.moveShot(targetPos);
			//allow.moveShot(targetPos, 30);
		
		}



	}
}

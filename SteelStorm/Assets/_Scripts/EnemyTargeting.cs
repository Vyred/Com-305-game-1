using UnityEngine;
using System.Collections;

public class EnemyTargeting : MonoBehaviour {

	Vector3 playerPos;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		//unity forms
	///	var dir = player.position - transform.position;
		//var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
	//	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		playerPos = playerPos - transform.position;
		float angle = Mathf.Atan2 (playerPos.y, playerPos.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
		//this.playerPos = Camera.main.ScreenToWorldPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
		//this.playerPos = (playerPos - transform.position);

		//this.transform.rotation.z = Quaternion.AngleAxis();
	}
}

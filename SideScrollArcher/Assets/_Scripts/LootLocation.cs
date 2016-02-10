using UnityEngine;
using System.Collections;

public class LootLocation : MonoBehaviour {

	private Vector3 position;
	// Use this for initialization
	public void rePosition(Vector3 pos)
	{
		this.gameObject.GetComponent<Transform> ().position = pos;
	}

	void Update()
	{
		if (this.gameObject.GetComponent<Transform> ().position.y < -170)
		{
			DestroyObject (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "player") 
		{
			
		}
	}
}

using UnityEngine;
using System.Collections;

public class LootDrop : MonoBehaviour {

	public LootLocation locationOfDrop;
	public GameObject lootFireRateUp;
	public GameObject lootVelocityUp;
	public GameObject lootHealthUp;
	public GameObject lootShieldUp;
	public GameObject lootArmourUp;
	private GameObject [] loots = new GameObject [5];

	public int dropRate;
	private int dropRange; 
	private int drop;
	// Use this for initialization
	void Start () 
	{
		//loots [0] = lootFireRateUp;
		loots [0] = lootFireRateUp;
		loots [1] = lootHealthUp;
	    loots [2] = lootShieldUp;
		loots [3] = lootVelocityUp;
		loots [4] = lootArmourUp;
		//{lootFireRateUp, lootVelocityUp, lootHealthUp, lootShieldUp, lootArmourUp};
		dropRate = 5;
	
		//Instantiate ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void rollLoot(Vector3 dropPos)
	{
		dropRange = Random.Range (0,100);
		if (dropRate >= dropRange)
		{
			drop = Random.Range (0, loots.Length);
			Instantiate (loots[drop]);
			dropPos.y = 150;
			loots[drop].GetComponent<Transform>().position = dropPos;
				//.gameObject<Transform>.position = dropPos;
		}
	}
}

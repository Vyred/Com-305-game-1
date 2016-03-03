using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES

	public int tankCount;
	public GameObject tank;
	
	// Use this for initialization
	void Start () {
		this._GenerateTanks ();

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}



	// generate Clouds
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}
}

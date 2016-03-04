using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour {

	public Sprite blackSky;
	public Sprite blueSky;
	public Sprite whiteSky;




	// Use this for initialization
	void Start () 
	{
		blackSky =  GetComponent<SpriteRenderer> ().sprite;
		blueSky  =  GetComponent<SpriteRenderer> ().sprite;
		whiteSky =  GetComponent<SpriteRenderer> ().sprite;
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = blueSky;

	}
	
	// Update is called once per frame
	void Update () 
	{

	}



	public Sprite skyChange(int _skyNum)
	{
		switch (_skyNum)
		{
		case 1:
			return blackSky;
			break;

		case 2:
			return blueSky;
			break;

		case 3:
			return whiteSky;
			break;

		default:
			return blueSky;
			break;
			//this.gameObject.GetComponent<SpriteRenderer> ().sprite = 
	}
  }
}
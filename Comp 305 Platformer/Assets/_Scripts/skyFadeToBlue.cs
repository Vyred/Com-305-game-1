using UnityEngine;
using System.Collections;

public class skyFadeToBlue : MonoBehaviour {

     SpriteRenderer SR;
	//gameObject.GetComponent<FadeToBlack>();

	public Sprite blackSky;
	public Sprite blueSky;
	public Sprite whiteSky;
	// Use this for initialization
	void Start () 
	{
		//lol = gameObject.GetComponent<FadeToBlack>();
		//background = gameObject.GetComponent<GameObject> ();
		//SR = GetComponent<SpriteRenderer>();
		//SR = GameObject.Find("sky").GetComponent<SpriteRenderer>();
		SR = GameObject.Find("sky").GetComponent<SpriteRenderer>();
		SR.sprite = blueSky;
		//	blackSky =  GetComponent<SpriteRenderer> ().sprite;
		//	blueSky  =  GetComponent<SpriteRenderer> ().sprite;
		//	whiteSky =  GetComponent<SpriteRenderer> ().sprite;
		//SR.sprite = blueSky;
		//this.gameObject.GetComponent<SpriteRenderer> ().sprite = blueSky;

	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter2D(Collision2D otherCollision)
	{
		Debug.Log("running");
		if (otherCollision.gameObject.CompareTag ("Player")) 
		{
			skyChange (2);
			//lol.SkyNum = 1; 
			//lf.GetComponent<SpriteRenderer>().sprite = lol.skyChange(1);

		}
	}

	public void skyChange(int _skyNum)
	{
		switch (_skyNum)
		{
		case 1:
			//background.GetComponent<SpriteRenderer> ().sprite = blackSky;
			SR.sprite = blackSky;
			break;

		case 2:
			//background.GetComponent<SpriteRenderer> ().sprite = blueSky;
			SR.sprite = blueSky;
			break;

		case 3:
			//background.GetComponent<SpriteRenderer> ().sprite = whiteSky;
			SR.sprite = whiteSky;
			break;

		default:

			break;
			//this.gameObject.GetComponent<SpriteRenderer> ().sprite = 
		}
	}
}
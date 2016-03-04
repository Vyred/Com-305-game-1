using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class EndOfLevel : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D otherCollision)
		{
			//Debug.Log("running");
		if (otherCollision.gameObject.CompareTag ("Player")) 
		{
			
			restartGameEvent ();
		}
	}


	private void _endGame()
	{
		Time.timeScale = 0.0f;

	}

	public void restartGameEvent()
	{
		EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene().name);
	}
}

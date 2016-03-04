using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.SceneManagement;

public class GameController : MonoBehaviour {
	//UI
	public Text score;
	private AudioSource backgroundSound;
	private AudioSource[] _audioSource;

	private  float _score;
	private bool  _gameFinsished;

	// Use this for initialization
	void Start () {
		this._audioSource = gameObject.GetComponents<AudioSource>();
		this.backgroundSound = this._audioSource [0];
		backgroundSound.loop = true;
		this._score = Time.timeSinceLevelLoad;
		this._gameFinsished = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this._gameFinsished == false)
		{
			this._score = Time.timeSinceLevelLoad;
			score.text = _score.ToString("#00");
		}

	}


}

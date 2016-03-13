using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	private Rigidbody lol;
	private GameObject BaseE;
	public float startingPosX;
	public float startingPosY;
	public float startingPosZ;
	public float rangeX;
	public float rangeY;
	public float rangez;
	//private offestSize;  
	// 
	private Vector3 [] takenPosition; 
	//elementArray = new GameObject [99999];
	// Use this for initialization
	void Start () 
	{
		//tree.gameObject.GetComponent<Rigidbody> ();
		startingPosX = -1000;
		startingPosY = -50;
	    startingPosZ = -1000;
		rangeX = 2000;
		rangeY = 50;
		rangeX = 2000;
		int counter = 0;

		for (float currentY = startingPosY; currentY  < rangeY + startingPosY; currentY+=0.5f)
		{
			for (float currentX = startingPosX; currentX < startingPosX + rangeX; currentX+=0.5f)
			{
				for(float currentZ = startingPosZ; currentZ < startingPosZ + rangez; currentZ+=0.5f)
				{
					takenPosition[counter] = new Vector3 (currentX,currentY,currentZ);
					Instantiate (lol, takenPosition[counter], Quaternion.Euler(0,0,0));
					counter++;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
//in order to spawn these at will first we most start by determining where to start the spawns, 0,0,0
// with this we then determine the numbers for the rangein which we spawn. we need a complete start x,y and z 
// Y will start with the base layer: layer 1
//x range will then also be given a single number
//once this has reached the max range spawn y will increase within the nested while loop this is in however 
//z range will then also be given a single number and once it has spawned cubes in the current x range will loop go to the next loop
using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	//public GameObject[] platformNodes;
	public float platformMoveSpeed;
	public GameObject platform;

	private Transform currentNode;
	public Transform[] nodes;

	//private bool goingToPlatformNode0;
	//private bool goingToPlatformNode1;

	private int nodeIndex;


	// Use this for initialization
	void Start () {

		currentNode = nodes [nodeIndex];

	}


	void FixedUpdate (){

		// Interpolate the platforms position from it's current position to destination transform at speed platformMoveSpeed.
		platform.transform.position = Vector3.MoveTowards (platform.transform.position,
		                                                  currentNode.position, platformMoveSpeed * Time.deltaTime);

		// If the platform reaches the current target transform iterate through to the next array index.
		if (platform.transform.position == currentNode.position) {

			nodeIndex++;

			// Array index is checked, if it's at the final index set current index to first.
			if(nodeIndex == nodes.Length){

				nodeIndex = 0;

			}

			// Set destination transform equal to indexed objects position.
			currentNode = nodes[nodeIndex];

		}

	}
	
	// Update is called once per frame
	void Update () {
	











		//while (transform.position != platformNodes[0].transform.position && goingToPlatformNode1 == true) {
			
			//Debug.Log("Moving to PlatformNode1");
			//transform.position = Vector3.MoveTowards (transform.position, platformNodes [0].transform.position,
			                                         // platformMoveSpeed * Time.deltaTime);
			
		//}
		
		//while (transform.position != platformNodes[1].transform.position && goingToPlatformNode0 == true) {
			
			//Debug.Log("Moving to PlatformNode0");
			//transform.position = Vector3.MoveTowards (transform.position, platformNodes [1].transform.position,
			                                         // platformMoveSpeed * Time.deltaTime);
			

	}

}

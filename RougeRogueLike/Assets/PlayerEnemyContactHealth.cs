using UnityEngine;
using System.Collections;

public class PlayerEnemyContactHealth : MonoBehaviour {

	public Transform target;//set target from inspector instead of looking in Update
	public float health = 100;
//	public bool showText = true;
	public Rect textArea = new Rect(0,0,Screen.width, Screen.height);

	void Start () {

	}

	void Update(){

		//rotate to look at the player
//		transform.LookAt(target.position);
//		transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
		GUI.Label(textArea,"Here is a block of text\nlalalala\nanother line\nI could do this all day!");

		//move towards the player
		if (Vector3.Distance (transform.position, target.position) <= 1f) {//move if distance from target is greater than 1
			health = health - 10;
		} 

	}

}
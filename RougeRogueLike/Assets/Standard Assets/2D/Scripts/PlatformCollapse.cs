using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	public class PlatformCollapse : MonoBehaviour
	{
		private const float FALLDELAY = 2.5f;

		private GameObject parent;
		private float falltime;

		// Use this for initialization
		void Start () {
			falltime = float.MaxValue;
			parent = this.gameObject.transform.parent.gameObject;
		}
		
		// Update is called once per frame
		void Update () {
			if (Time.fixedTime > falltime) {

//				if (this.gameObject.GetComponent("BoxCollider2D"))
//				{
//					Destroy(this.gameObject.GetComponent("BoxCollider2D"));
//				}

				// Make playform fall by adding rigid body to the parent object
				if (!parent.GetComponent("Rigidbody"))
				{
					Rigidbody gameObjectsRigidBody = parent.AddComponent<Rigidbody>();
					gameObjectsRigidBody.mass = 5;
				}
			}
		}

		void OnCollisionEnter2D(Collision2D col) 
		{
			// When Player collides with platform, start timer
			if (col.gameObject.tag == "Player" && falltime == float.MaxValue)
			{
				falltime = Time.fixedTime + FALLDELAY;
			}
		}
	}
}
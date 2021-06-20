using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUD: MonoBehaviour {

	public float speed;
	public bool moveUp;

	// Use this for initialization
	void Update () {
		// Use this for initialization
		if(moveUp) {
			transform.Translate(0,2* Time.deltaTime * speed,0 );
			
 		}
		else{
			transform.Translate(0,-2* Time.deltaTime * speed, 0);
			
		}
	}
	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.CompareTag("turn")){

			if (moveUp){
				moveUp = false;
			}
			else{
				moveUp = true;
			}	
		}
	}
}
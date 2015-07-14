using UnityEngine;
using System.Collections;

public class OnPlanet : MonoBehaviour {

	void OnTriggerEnter(Collider other){

		if(other.tag == "Player"){
			Debug.Log ("!");
			other.rigidbody.isKinematic = true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public Transform planet;
	public bool AlignToPlanet;
	public float gravityConstant = 9.8f;
	
	void FixedUpdate () {
		Vector3 toCenter = planet.position - transform.position;
		toCenter.Normalize();
		
		GetComponent<Rigidbody>().AddForce(toCenter * gravityConstant, ForceMode.Acceleration);
		
		if (AlignToPlanet)
		{
			Quaternion q = Quaternion.FromToRotation(transform.up, -toCenter);
			q = q * transform.rotation;
			transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
		}
	}
}
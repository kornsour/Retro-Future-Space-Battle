using UnityEngine;
using System.Collections;

public class Repeller : MonoBehaviour {

	public float repelAmt = -20.0f;
	public float explosionRad = 20.0f;
	public bool contact = false;

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<AudioPlayer>().PlayAudio (1);
			contact = true;
			Vector3 direction = (other.transform.position - transform.position).normalized;
			//other.rigidbody.AddExplosionForce(repelAmt,transform.position,explosionRad);*/
			other.rigidbody.AddForce(direction * repelAmt, ForceMode.VelocityChange);
		}
		else {

			contact = false;
				}
	}

}

using UnityEngine;
using System.Collections;

public class Destructo : MonoBehaviour {

	public int damage = -1;

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<AudioPlayer>().PlayAudio (7);
			PlayerStats ps = (PlayerStats)other.gameObject.GetComponent("PlayerStats");
			ps.DealDmg(damage);
			Destroy(this.gameObject);

		}
	}
}

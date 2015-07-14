using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	public int damage = -1;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){

			PlayerStats ps = (PlayerStats)other.gameObject.GetComponent("PlayerStats");
			ps.DealDmg(damage);
		}

	}
}

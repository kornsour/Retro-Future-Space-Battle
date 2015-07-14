using UnityEngine;
using System.Collections;

public class SpecialIconSelect : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
			PlayerStats ps = (PlayerStats)player.GetComponent("PlayerStats");
			switch(ps.type){
			case "A": transform.FindChild("attack").gameObject.SetActive(true); break;
			case "S": transform.FindChild("orbit").gameObject.SetActive(true); break;
			case "D": transform.FindChild("shield").gameObject.SetActive(true); break;
		}
	}
}

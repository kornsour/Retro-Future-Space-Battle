using UnityEngine;
using System.Collections;

public class Orbital1 : MonoBehaviour {

	public GameObject player;

	public float orbitSpeed = 10;
	// Update is called once per frame
	void Update () {
		player.transform.RotateAround(Vector3.zero, player.transform.forward, orbitSpeed );
	}
	
}

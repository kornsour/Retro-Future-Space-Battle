using UnityEngine;
using System.Collections;

public class Orbital : MonoBehaviour {

	public GameObject player;

	public float orbitSpeed = 10;

	public float orbitHeight = 2;



	// Update is called once per frame
	void Update () {
		player.transform.RotateAround(Vector3.zero, player.transform.forward, orbitSpeed );

	}
	
}

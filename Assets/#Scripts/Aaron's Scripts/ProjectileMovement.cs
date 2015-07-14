using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	public GameObject CenterOfG;

	public float distance = 100;

	public float speed = 10;

	private Vector3 originalPOS;

	public float timer = 5f;

	public float timeUp = 0.0f;

	public int dmg;

	public int playerNum;

	// Use this for initialization
	void Start () {


		CenterOfG = GameObject.Find ("Land");

		originalPOS = transform.position;

		timeUp = Time.time + timer;

	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (originalPOS, transform.position) > distance) 
		{
			Destroy (gameObject);
		}
		else if(Time.time > timeUp)
		{
			Destroy (gameObject);
		}

		transform.RotateAround(CenterOfG.transform.position, Vector3.forward, speed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player" && other.gameObject.name != "Player " + playerNum)
		{
			other.gameObject.GetComponent<AudioPlayer>().PlayAudio (3);
			other.gameObject.GetComponent<PlayerStats>().DealDmg(-dmg);
			Destroy (gameObject);
		}
		else if(other.gameObject.name != "Player " + playerNum)
		{
			Destroy (gameObject);
		}
	}



}

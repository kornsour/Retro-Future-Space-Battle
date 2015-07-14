using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BazookaMovement : MonoBehaviour {

	public int playerNum;

	public GameObject CenterOfG;
	
	private float distance = 5;

	private Vector3 originalPOS;
	
	public float speed = 10;
	
	public float timer = 5f;
	
	public float timeUp = 0.0f;
	
	public int dmg;

	public GameObject target;

	public ManaController ManaBar;

	public PlayerShooter shooter;

	private float lerpDelay = 0.01f;
	private float nextLerp = 0;

	private float offset = 0.3f;
	

	// Use this for initialization
	void Start () {
		
		originalPOS = transform.position;


		CenterOfG = GameObject.Find ("Land");

		Vector3 up = CenterOfG.transform.position - transform.position;
		up.Normalize ();
		up = up * distance;
		transform.LookAt (transform.position - up);
		//transform.Rotate(0,0,180);
		//timeUp = Time.time + timer;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(/*Input.GetButton("Player " + playerNum + " Special")*/ shooter.IsSpecial() && ManaBar.GetCurrMP() > 0)
		{
			ManaBar.regenMode = false;
			if(Vector3.Distance (transform.position, originalPOS) >= distance)
			{
				if(!CheckVector())
					transform.RotateAround(CenterOfG.transform.position, Vector3.forward, speed * Time.deltaTime);
				else
				{
					//transform.Rotate(-90,0,0);
					transform.LookAt (target.transform.position);
					transform.Translate (Vector3.forward * 20 * Time.deltaTime);
				}
				if(Time.time > nextLerp)
				{
					ManaBar.AdjustCurrMP(-1);
					nextLerp = Time.time + lerpDelay;
				}
			}
			else{

				transform.Translate (Vector3.forward *20 * Time.deltaTime);
			}
		}
		else
		{
			ManaBar.regenMode = true;
			Explode();
		}
		
	}
	
	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.tag == "Player" && other.gameObject.name != "Player " + playerNum)
		{
			other.gameObject.GetComponent<AudioPlayer>().PlayAudio (3);
			other.gameObject.GetComponent<PlayerStats>().DealDmg(-dmg);
			Destroy (gameObject);
		}
		else if(other.gameObject.name != "Player " + playerNum && Vector3.Distance (transform.position, originalPOS) >= distance)
		{
			Explode ();
		}
	}

	void Explode()
	{
		Destroy (gameObject);
	}

	bool CheckVector()
	{
		RaycastHit hit;
		int layermask = 1<<8;
		bool toReturn = false;

		Vector3 targetVector = target.transform.position - transform.position;
		targetVector.Normalize();
		float targetDistance = Vector3.Distance(target.transform.position, transform.position);
		Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red, 1);
		if(Physics.Raycast(transform.position, targetVector, out hit, targetDistance, layermask))
		{
			if(hit.transform.gameObject.tag == "Map" || hit.transform.gameObject.name == ("Player " + playerNum)|| hit.transform.gameObject.name == "Land")
			{
				//Debug.Log ("false");
				toReturn =  false;
				return toReturn;
			}
			else
			{
				//Debug.Log (hit.transform.gameObject.name + ", " + playerNum);
				toReturn = true;
			}
		}

		Vector3 rayOrigin = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
		Vector3 rayEnd = new Vector3(target.transform.position.x, target.transform.position.y + offset, target.transform.position.z);
		targetVector = rayEnd - rayOrigin;
		targetVector.Normalize ();
		Debug.DrawRay(rayOrigin, rayEnd - rayOrigin, Color.red, 1);
		if(Physics.Raycast(rayOrigin, targetVector, out hit, targetDistance, layermask))
		{
			if(hit.transform.gameObject.tag == "Map" || hit.transform.gameObject.name == ("Player " + playerNum)|| hit.transform.gameObject.name == "Land")
			{
				//Debug.Log ("false");
				toReturn =  false;
				return toReturn;
			}
			else
			{
				//Debug.Log ("true2");
				toReturn = true;
			}
		}
		rayOrigin = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
		rayEnd = new Vector3(target.transform.position.x, target.transform.position.y - offset, target.transform.position.z);
		targetVector = rayEnd - rayOrigin;
		targetVector.Normalize ();
		Debug.DrawRay(rayOrigin, rayEnd - rayOrigin, Color.red, 1);
		if(Physics.Raycast(rayOrigin, targetVector, out hit, targetDistance, layermask))
		{
			if(hit.transform.gameObject.tag == "Map" || hit.transform.gameObject.name == ("Player " + playerNum) || hit.transform.gameObject.name == "Land")
			{
				//Debug.Log ("false");
				toReturn =  false;
				return toReturn;
			}
			else
			{
				//Debug.Log ("true3");
				toReturn = true;
			}
		}


		return toReturn;
	}

}

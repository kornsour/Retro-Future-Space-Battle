using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

	public GameObject CenterOfG;

	public float speed = 10;

	public bool grounded = false;

	public float jumpForce = 5.0f;

	public int playerNum;

	public bool jumping = false;

	// Use this for initialization
	void Start () {
		CenterOfG = GameObject.Find ("Land");

		if(gameObject.name == "Player 1")
			playerNum = 1;
		else if (gameObject.name == "Player 2")
			playerNum = 2;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!grounded)
		{
			Vector3 direction = CenterOfG.transform.position - gameObject.transform.position;
			direction.Normalize();
			direction = new Vector3(direction.x, direction.y, 0);
			//transform.Translate(direction * Time.deltaTime);
			gameObject.rigidbody.AddForce(direction * 10);
		}
		else if(grounded)
		{
			if (Input.GetButtonDown("Player " + playerNum + " Jump"))
			{
				rigidbody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
				jumping = true;
			}
		}

		Debug.DrawRay(transform.position, Vector3.right, Color.green, 1);

		transform.RotateAround(CenterOfG.transform.position, Vector3.forward, speed * Time.deltaTime);
	
	}

	void OnCollisionExit(Collision other)
	{
		if(other.gameObject.tag == "Map")
		{
			grounded = false;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Map")
		{
			grounded = true;
			jumping = false;
		}
	}
}

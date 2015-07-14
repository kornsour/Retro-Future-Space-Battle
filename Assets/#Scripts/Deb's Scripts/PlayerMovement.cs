using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	
	public Transform LookTransform;

	public int playerNum;
	
	public float speed = 6.0f;
	public float maxVelocityChange = 10.0f;
	public float jumpForce = 5.0f;
	public float GroundHeight = 1.1f;
	private float xRotation;
	private float yRotation;

	public bool speeding = false;
	public bool slowing = false;
	private float start;
	private float startSlow;

	private Button buttonRight;

	private bool rDown = false;
	private bool jump = false;
	private float move;

	public bool canDoubleJump = false;

	void Start() {
		if(gameObject.name == "Player 1")
		{
			playerNum = 1;
			buttonRight = GameObject.Find ("P1Right").GetComponent<Button>();
		}
		else if (gameObject.name == "Player 2")
		{
			playerNum = 2;
		}
		int numberOfPlanets  =GameObject.FindGameObjectsWithTag("Map").Length;
		if(numberOfPlanets > 1){

			canDoubleJump = true;
		}
	}

	void Update () {
		if(speeding){


			float now = Time.time - start;
			if(now >= 3.0f){

				speed-=3;
				speeding = false;
			}

		}
		if(slowing){
			
			
			float now = Time.time - startSlow;
			if(now >= 3.0f){
				
				speed+=3;
				slowing = false;
			}
			
		}
		
		RaycastHit groundedHit;
		bool grounded = Physics.Raycast(transform.position, -transform.up, out groundedHit, GroundHeight);
		if (grounded)
		{
			// Calculate how fast we should be moving
			Vector3 forward = Vector3.Cross(transform.up, -LookTransform.right).normalized;
			Vector3 right = Vector3.Cross(transform.up, LookTransform.forward).normalized;
			//Vector3 targetVelocity = ( right * Input.GetAxis("Player " + playerNum + " Horizontal")) * speed;
			//Debug.Log ("input: " + Input.GetAxis("Player " + playerNum + " Horizontal"));
			if(rDown && move > -1)
			{
				move -= speed * Time.deltaTime * 2;

				if(move <=  -1)
					move = -1;
			}
			if(!rDown && move < 0)
			{
				move += speed * Time.deltaTime * 2;

				if(move >= 0)
					move = 0;
			}

			Vector3 targetVelocity = ( right * move) * speed;
			
			Vector3 velocity = transform.InverseTransformDirection(rigidbody.velocity);
			velocity.y = 0;
			velocity = transform.TransformDirection(velocity);
			Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			velocityChange = transform.TransformDirection(velocityChange);
			
			rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
			
			if (/*Input.GetButtonDown("Player " + playerNum + " Jump")*/jump && grounded)
			{
				rigidbody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
			}
		}
		else if(!grounded && /*Input.GetButtonDown("Player " + playerNum + " Jump")*/ jump && canDoubleJump){
				RaycastHit hit2;
			Transform lk = transform.FindChild("LookTransform");
				if (Physics.Raycast ( lk.position, lk.up, out hit2)) {
					if(hit2.transform.tag == "Map"){
					Vector3 pos = new Vector3 (hit2.transform.position.x,hit2.transform.position.y,0);
					transform.rotation = Quaternion.Euler(0,0,0);
					transform.position = pos;
					Gravity g = (Gravity)GetComponent("Gravity");
					Transform newPlanet;
					if(hit2.transform.name == "planet1"){

						newPlanet = GameObject.Find("Land").transform;
					}
					else newPlanet = GameObject.Find(hit2.transform.name).transform;
					g.planet = newPlanet;
					}
				}
			}

	}

	void OnCollisionEnter(Collision other){

		if(other.gameObject.tag == "Speed"){
			speed+=3;
			speeding = true;
			start = Time.time;
			Destroy(other.gameObject);
		}
		else if(other.gameObject.tag == "SlowDown"){
			speed-=3;
			slowing = true;
			startSlow = Time.time;
			Destroy(other.gameObject);
		}
	}

	public void StartMove()
	{
		rDown = true;

	}

	public void StopMove()
	{
		rDown = false;
	}

	public void JumpTrue()
	{
		jump = true;

		StartCoroutine ("JumpCooldown");
	}

	public void JumpFalse()
	{
		jump = false;
	}

	IEnumerator JumpCooldown()
	{
		yield return new WaitForSeconds(1);

		jump = false;
	}
}

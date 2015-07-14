using UnityEngine;
using System.Collections;

public class PlayerMovement0 : MonoBehaviour {
	
	public Transform LookTransform;

	public int playerNum;
	
	public float speed = 6.0f;
	public float maxVelocityChange = 10.0f;
	public float jumpForce = 5.0f;
	public float GroundHeight = 1.1f;
	private float xRotation;
	private float yRotation;

	public float radius = 0.6f;
	public float translateSpeed = 180.0f;
	public float rotateSpeed = 360.0f;
	public Quaternion rotation = Quaternion.identity;
	bool inAir = false;
	Vector3 direction = Vector3.one;
	public float theta = 90.0f;

	public Transform planet;
	void Start() {
		if(gameObject.name == "Player 1")
			playerNum = 1;
		else if (gameObject.name == "Player 2")
			playerNum = 2;
	}

	void Update () {
		
		RaycastHit groundedHit;
		bool grounded = Physics.Raycast(transform.position, -transform.up, out groundedHit, GroundHeight);
		if (grounded)
		{
			// Calculate how fast we should be moving
			Vector3 forward = Vector3.Cross(transform.up, -LookTransform.right).normalized;
			Vector3 right = Vector3.Cross(transform.up, LookTransform.forward).normalized;
			Vector3 targetVelocity = ( right * Input.GetAxis("Player " + playerNum + " Horizontal")) * speed;
			
			Vector3 velocity = transform.InverseTransformDirection(rigidbody.velocity);
			velocity.y = 0;
			velocity = transform.TransformDirection(velocity);
			Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			velocityChange = transform.TransformDirection(velocityChange);
			
			rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
			
			if (Input.GetButtonDown("Player " + playerNum + " Jump"))
			{
				rigidbody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
			}
		}
	}

		
//	}*/

	
	void Rotate(float amount)
	{
		theta += amount * Mathf.Deg2Rad * Time.deltaTime;
	}
	
	void Translate(float x, float y)
	{
		var perpendicular = new Vector3(-direction.y, direction.x);
		var verticalRotation = Quaternion.AngleAxis(y * Time.deltaTime, perpendicular);
		var horizontalRotation = Quaternion.AngleAxis(x * Time.deltaTime, direction);
		rotation *= horizontalRotation * verticalRotation;
	}
	
	void UpdatePositionRotation()
	{
		transform.localPosition = rotation * Vector3.forward * radius;
		//transform.rotation = rotation * Quaternion.LookRotation(direction, Vector3.forward);
	}
	
	
	/*// Update is called once per frame
	void FixedUpdate () {
		
		RaycastHit groundedHit;
		bool grounded = Physics.Raycast(transform.position, -transform.up, out groundedHit, GroundHeight);
		if (grounded)
		{
			// Calculate how fast we should be moving
			Vector3 forward = Vector3.Cross(transform.up, -LookTransform.right).normalized;
			Vector3 right = Vector3.Cross(transform.up, LookTransform.forward).normalized;
			Vector3 targetVelocity = ( right * Input.GetAxis("Player " + playerNum + " Horizontal")) * speed;
			
			Vector3 velocity = transform.InverseTransformDirection(rigidbody.velocity);
			velocity.y = 0;
			velocity = transform.TransformDirection(velocity);
			Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			velocityChange = transform.TransformDirection(velocityChange);
			
			rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
			
			if (Input.GetButtonDown("Player " + playerNum + " Jump"))
			{
				rigidbody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
			}
		}
	}
	
	void Update(){
		RaycastHit groundedHit;
		bool grounded = Physics.Raycast(transform.position, -transform.up, out groundedHit, GroundHeight);
		/*
		if(Input.GetButtonDown("Player " + playerNum + " Jump")){
			rigidbody.isKinematic = false;
			rigidbody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
		}*/
		
		// Rotate with left/right arrows
		/*if (Input.GetKey(KeyCode.LeftArrow)) Rotate( rotateSpeed);
		if (Input.GetKey(KeyCode.RightArrow)) Rotate(-rotateSpeed);
		
		// Translate forward/backward with up/down arrows
		if (Input.GetKey(KeyCode.UpArrow)) Translate(0, translateSpeed);
		if (Input.GetKey(KeyCode.DownArrow)) Translate(0, -translateSpeed);

		// Translate left/right with A/D. Bad keys but quick test.*/
		
		
		/*if (Input.GetButton("Player " + playerNum + " Horizontal")) {
			/*rigidbody.isKinematic = false;
				direction = new Vector3(Mathf.Sin(theta), Mathf.Cos(theta));
				Translate(0, Mathf.Pow(-1,playerNum)*translateSpeed);
			UpdatePositionRotation();
			rigidbody.isKinematic = true;*/
		//	transform.RotateAround(planet.position, planet.TransformDirection(transform.right), speed * Time.deltaTime);
		
		//}
		
		//if (Input.GetKey(KeyCode.D)) Translate(-translateSpeed, 0);
		
		//UpdatePositionRotation();
		//}

}

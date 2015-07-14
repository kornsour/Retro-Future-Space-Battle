using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	private Vector3 originalPOS;
	private Vector3 endPOS;
	private float startTime;

	public bool horizontal = false;
	public bool vertical = true;
	public float distance = 10;
	public float speed = 5;

	// Use this for initialization
	void Start () {
		originalPOS = transform.position;
		if (horizontal && vertical)
			horizontal = false;
		if (horizontal)
			endPOS = new Vector3 (transform.position.x + distance, transform.position.y, transform.position.z); 
		else
			endPOS = new Vector3 (transform.position.x, transform.position.y + distance, transform.position.z); 

		startTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / distance;
		transform.position = Vector3.Lerp (originalPOS, endPOS, fracJourney);

		if (transform.position == endPOS) 
		{
			endPOS = originalPOS;
			originalPOS = transform.position;
			startTime = Time.time;
		}
	
	}
	
}

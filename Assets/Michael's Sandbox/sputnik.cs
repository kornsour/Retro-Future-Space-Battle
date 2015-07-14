using UnityEngine;
using System.Collections;

public class sputnik : MonoBehaviour
{
	public float speed = 1f;
	
	
	void Update ()
	{
		transform.Rotate(Vector3.forward, speed * Time.deltaTime);
	}
}
using UnityEngine;
using System.Collections;

public class spin2D : MonoBehaviour
{
	public float speed = 1f;
	
	
	void Update ()
	{
		transform.Rotate(-Vector3.forward, speed * Time.deltaTime);
	}
}
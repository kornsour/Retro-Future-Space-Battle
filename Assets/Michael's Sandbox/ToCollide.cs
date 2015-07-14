using UnityEngine;
using System.Collections;

public class speed : MonoBehaviour
{
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "speed")
		{
			Destroy(col.gameObject);
		}
	}
}
using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public GameObject destination;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<AudioSource>().pitch = 2;
			other.gameObject.GetComponent<AudioPlayer>().PlayAudioAt(5, 0.5f);
			other.gameObject.transform.position = destination.transform.position;
			other.gameObject.transform.rotation = Quaternion.identity;
		}
	}
	
}

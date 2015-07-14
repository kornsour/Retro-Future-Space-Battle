using UnityEngine;
using System.Collections;

public class SpecialGrav : MonoBehaviour {
	
	public GameObject objToSpawn;
	private float spawnIn=1.0f;
	
	// Update is called once per frame
	void Update () {
		if(!objToSpawn) return;
		spawnIn -= Time.deltaTime;
		if(spawnIn < 0){
			Vector3 pos = Random.insideUnitSphere.normalized;
			pos *= Random.Range(10.0f, 40.0f);
			Instantiate(objToSpawn, pos, Random.rotation);
			spawnIn = Random.Range(1.0f, 3.0f);
		}
	}
}

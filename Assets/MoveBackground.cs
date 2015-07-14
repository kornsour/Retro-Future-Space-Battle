using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
	
	// Update is called once per frame
	public float offset;
	private float time = 0.0f;
	public float changetime = 3.0f;
	public float now;
	public int sign = 1;
	void Start(){

		time = Time.time;
	}

	void Update () {

		now = Time.time - time;
		if(now >= changetime){
			foreach(Transform child in transform){

				child.position = new Vector3(child.position.x + Mathf.Pow(-1,sign)*offset,child.position.y + Mathf.Pow(-1,sign)*offset,0);
				if(sign == 1){
					sign = 2;
				}
				else if(sign ==2 ){
					sign =1;
				}
			}
			time = Time.time;
		}
	}
}

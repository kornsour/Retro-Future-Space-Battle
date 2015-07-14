using UnityEngine;
using System.Collections;

public class ContMusic : MonoBehaviour {
	
	private static ContMusic instance = null;
	public static ContMusic Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
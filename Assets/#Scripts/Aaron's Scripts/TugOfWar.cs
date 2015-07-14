using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TugOfWar : MonoBehaviour {
	public Image gray;
	public Image blue;
	public Image red;
	public Image handle;

	private int value;

	private Slider slider;

	// Use this for initialization
	void Start () {
		value = PlayerPrefs.GetInt ("TugOfWar");
		slider = gameObject.GetComponent<Slider>();

		if(value == 0)
		{
			handle.sprite = gray.sprite;
		}
		if(value > 0)
		{
			handle.sprite = blue.sprite;
		}
		if(value < 0)
		{
			handle.sprite = red.sprite;
		}

		slider.value = value;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

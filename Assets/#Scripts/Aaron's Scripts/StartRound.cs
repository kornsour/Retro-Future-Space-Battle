using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartRound : MonoBehaviour {

	public Image TextBox;
	public float timer = 1;

	public GameObject player1;
	public GameObject player2;

	private float timerMax;
	private int time;

	// Use this for initialization
	void Start () {
		time = 3;
		timerMax = timer;
		player1.SetActive(false);
		player2.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(time == 3)
		{
			TextBox.GetComponentInChildren<Text>().text = "3";
		}
		if(time == 2)
		{
			TextBox.GetComponentInChildren<Text>().text = "2";
		}
		if(time == 1)
		{
			TextBox.GetComponentInChildren<Text>().text = "1";
		}
		if(time == 0)
		{
			TextBox.GetComponentInChildren<Text>().text = "Fight";
			player1.SetActive(true);
			player2.SetActive(true);
		}

		timer -= Time.deltaTime;

		if(timer <= 0)
		{
			if(time == 0)
			{
				TextBox.gameObject.SetActive(false);
				time--;
			}
			else
			{
				time--;
				timer = timerMax;
			}
		}


	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
		
	public string type = "A";

	public int playerNum;

	public Image TextBox;

	private bool shield = false;
	private HealthController hpControl;
	private ManaController ManaBar;

	private float lerpDelay = 0.01f;
	private float nextLerp = 0;

	public float setspd;

	private AudioPlayer audio;

	public GameObject Celebration;


	// Use this for initialization
	void Awake () {
		if(gameObject.name == "Player 1")
		{
			playerNum = 1;
		}
		else if (gameObject.name == "Player 2")
		{
			playerNum = 2;
		}

		if(PlayerPrefs.HasKey("Player " + playerNum + " special"))
		{
			type = PlayerPrefs.GetString("Player " + playerNum + " special");
		}

		Debug.Log (playerNum + " " + type);

		hpControl = GameObject.Find ("HealthBar " + playerNum).GetComponent<HealthController>(); 
		ManaBar = GameObject.Find ("ManaBar " + playerNum).GetComponent<ManaController>(); 

		hpControl.SetHP (3);
		//PlayerMovement pm = (PlayerMovement)gameObject.GetComponent("PlayerMovement");
		//pm.speed = setspd+2*spd;

		audio = gameObject.GetComponent<AudioPlayer>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(hpControl.GetCurrHP() <= 0 && !TextBox.gameObject.activeSelf)
		{
			if(playerNum == 1)
			{
				PlayerPrefs.SetInt ("TugOfWar", PlayerPrefs.GetInt ("TugOfWar") + 1);
				TextBox.gameObject.SetActive(true);
				if(PlayerPrefs.GetInt ("TugOfWar") >= 3)
				{
					Fireworks();
					TextBox.GetComponentInChildren<Text>().text = "Player 2 Wins the Game!";
				}
				else
					TextBox.GetComponentInChildren<Text>().text = "Player 2 Wins the Round!";
				GameObject.Find ("Player 2").GetComponentInChildren<PlayerShooter>().enabled = false;
			}
			if(playerNum == 2)
			{
				PlayerPrefs.SetInt ("TugOfWar", PlayerPrefs.GetInt ("TugOfWar") - 1);
				TextBox.gameObject.SetActive(true);
				if(PlayerPrefs.GetInt ("TugOfWar") <= -3)
				{
					Fireworks();
					TextBox.GetComponentInChildren<Text>().text = "Player 1 Wins the Game!";
				}
				else
					TextBox.GetComponentInChildren<Text>().text = "Player 1 Wins the Round!";
				GameObject.Find ("Player 1").GetComponentInChildren<PlayerShooter>().enabled = false;

			}
			hpControl.EndGame();
			Destroy (gameObject);
		}

		if(Input.GetButton("Player " + playerNum + " Special") && ManaBar.GetCurrMP() > 0 && type == "D")
		{
			if(!audio.source.isPlaying)
			{
				audio.PlayAudioAt (0, 2);
			}
			ManaBar.regenMode = false;
			shield = true;
			if(Time.time > nextLerp)
			{
				ManaBar.AdjustCurrMP(-0.1f);
				nextLerp = Time.time + lerpDelay;
			}
		}
		else
		{
			if(audio.source.clip == audio.audio[0])
			{
				audio.source.Stop();
			}
			ManaBar.regenMode = true;
			shield = false;
		}
	
	}

	public void DealDmg(int dmg)
	{
		if(!shield)
			hpControl.AdjustCurrHP(dmg);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Spikes")
		{
			audio.PlayAudio(3);
			DealDmg (-1);
		}
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Land" || other.gameObject.tag == "Map")
		{
			audio.PlayAudio(3);
		}
	}

	public void Fireworks()
	{
		Celebration.SetActive(true);
	}
}

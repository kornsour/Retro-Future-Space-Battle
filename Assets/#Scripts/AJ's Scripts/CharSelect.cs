using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour {

	public int currPlayer = 1;

	public float waitTime = 1;

	public DialogueText TextOptions;

	private float nextTime = 0;

	private GameObject[] buttons;
	public Text questionText;
	public Text playerName;

	public bool answered = false;
	public bool questioned = false;

	public SpriteRenderer girl;
	public Sprite girl2;
	public Sprite girl1;

	private float beginTimer = 1.5f;

	void Start(){
		//PlayerPrefs.DeleteAll ();
		if(!PlayerPrefs.HasKey("TugOfWar"))
		{
			/*
			PlayerPrefs.SetInt ("Player 1 atk", 1);
			PlayerPrefs.SetInt ("Player 1 def", 1);
			PlayerPrefs.SetInt ("Player 1 spd", 1);
			PlayerPrefs.SetInt ("Player 1 wins", 0);

			PlayerPrefs.SetInt ("Player 2 atk", 1);
			PlayerPrefs.SetInt ("Player 2 def", 1);
			PlayerPrefs.SetInt ("Player 2 spd", 1);
			PlayerPrefs.SetInt ("Player 2 wins", 0);
			*/

			PlayerPrefs.SetInt("TugOfWar", 0);
			PlayerPrefs.SetInt ("Level", 1);
		}

		buttons = GameObject.FindGameObjectsWithTag("Button");

	}

	void FixedUpdate() {

		if(beginTimer > 0)
			beginTimer -= Time.deltaTime;
		if(beginTimer <= 0 && !questioned)
		{
			LoadNewQuestion();
			questioned = true;
		}

		if(nextTime > 0)
		{
			if(!answered)
			{
				playerName.text = "";
				
				questionText.text = Answer ();
				girl.sprite = girl2;
				answered = true;
			}
			if(Time.time > nextTime)
			{
				if(currPlayer == 1)
				{
					currPlayer = 2;
					LoadNewQuestion();
					//GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
					foreach (GameObject button in buttons)
					{
						button.GetComponent<Button>().interactable = true;
					}
					nextTime = 0;
					girl.sprite = girl1;
					answered = false;
				}
				else if(currPlayer == 2)
				{
					Application.LoadLevel("Level 1");
					//Application.LoadLevel ("Level 1 Test");
				}
			}
		}
		
	}


	public void plusAttack(){
		if(currPlayer == 1)
			PlayerPrefs.SetString ("Player 1 special", "A");
		else if(currPlayer == 2)
			PlayerPrefs.SetString ("Player 2 special", "A");
		//GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
		foreach (GameObject button in buttons)
		{
			button.GetComponent<Button>().interactable = false;
			nextTime = Time.time + waitTime;
		}
	}

	public void plusDefense(){
		if(currPlayer == 1)
			PlayerPrefs.SetString ("Player 1 special", "D");
		else if(currPlayer == 2)
			PlayerPrefs.SetString ("Player 2 special", "D");
		//GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
		foreach (GameObject button in buttons)
		{
			button.GetComponent<Button>().interactable = false;
			nextTime = Time.time + waitTime;
		}
	}

	public void plusSpeed(){
		if(currPlayer == 1)
			PlayerPrefs.SetString ("Player 1 special", "S");
		else if(currPlayer == 2)
			PlayerPrefs.SetString ("Player 2 special", "S");
		//GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
		foreach (GameObject button in buttons)
		{
			button.GetComponent<Button>().interactable = false;
			nextTime = Time.time + waitTime;
		}
	}

	public void plusRandom(){
		float floatran = Random.Range (1, 3);
		int intran = (int)floatran;
		if (intran==1){
			plusAttack ();
		}
		if(intran==2){
			plusDefense ();
		}
		if(intran==3){
			plusSpeed ();
		}
	}

	public void LoadNewQuestion(){

		TextOptions.SetQuestion ();

		playerName.text = "This Question is for Player " + currPlayer + ". Please answer this question to help us pick the right spacecraft for you:";

		questionText.text = TextOptions.question[0];

		foreach (GameObject button in buttons)
		{

			if(button.name == "atk button")
				button.GetComponentInChildren<Text>().text = TextOptions.question[1];
			if(button.name == "dfs button")
				button.GetComponentInChildren<Text>().text = TextOptions.question[2];
			if(button.name == "spd button")
				button.GetComponentInChildren<Text>().text = TextOptions.question[3];
			if(button.name == "rand button")
				button.GetComponentInChildren<Text>().text = TextOptions.question[4];
				
		}

	}

	public string Answer()
	{
		float floatran = Random.Range (1, 5);
		int intran = (int)floatran;

		if(intran == 1)
			return "Wow! That's really kinky!";
		if(intran == 2)
			return "Well that's um.....erm.... interesting....";
		if(intran == 3)
			return "I've never heard that before.";
		if(intran == 4)
			return "Wow! You're really unique!";
		if(intran == 5)
			return "No wonder you're on this show.....";

		return "Wow! That's interesting!";
	}

}

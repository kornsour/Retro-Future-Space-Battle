using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string name;

	// Use this for initialization
	public void LoadGame () {
		PlayerPrefs.DeleteAll();
		Application.LoadLevel ("Intro");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void LoadTut () {
		PlayerPrefs.DeleteAll();
		Application.LoadLevel (name);
	}

	public void LoadCred(){
		Application.LoadLevel (name);

	}

	public void LoadMenu(){
		Application.LoadLevel("main menu");
	}

}

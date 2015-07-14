using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Pause") && pauseMenu.activeSelf == true)
		{
			pauseMenu.SetActive(false);
		}
		else if(Input.GetButtonDown("Pause")) //&& pauseMenu.activeInHierarchy == false)
		{
			pauseMenu.SetActive(true);
		}

	
	}

	public void MenuButton()
	{
		Application.LoadLevel("main menu");
	}

	public void Resume()
	{
		pauseMenu.SetActive(false);
	}
}

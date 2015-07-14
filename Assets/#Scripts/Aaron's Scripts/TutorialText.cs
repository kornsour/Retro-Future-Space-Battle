using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {

	public List<string> tutorial;

	public Text TextArea;

	public int i = 0;

	private float timer = 1.5f;

	// Use this for initialization
	void Start () {
		tutorial.Add("Hey kid, you ready to go? The Dating Games Commision finally approved your application and your special someone is waiting for you.");
		tutorial.Add("But, just look at them. You knew there’d be competition. Beat the other applicant in the arena and you get the date.");
		tutorial.Add("Now remember, when they come over here they’re going to ask you a question. The spacecraft you get to use in battle depends on how you respond so choose your answer carefully.");
		tutorial.Add("I know you can do it...but good luck just in case. Alright here they come, act normal!");
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0)
			TextArea.text = tutorial[i];
	
	}

	public void Next()
	{
		if(i < tutorial.Count - 1)
			i++;
		else
			Skip ();
	}

	public void Skip()
	{
		Application.LoadLevel ("Questions");
	}
}

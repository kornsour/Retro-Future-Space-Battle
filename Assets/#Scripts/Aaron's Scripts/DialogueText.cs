using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueText : MonoBehaviour {

	public List<string> question;

	public float size;

	public List<int> used;

	// Use this for initialization
	void Awake () {


		size = 5;
	

		//SetQuestion();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetQuestion()
	{
		question.Clear ();

		float floatran = Random.Range (1, size);
		int intran = (int)floatran;

		if(used.Contains(intran))
		{
			if(used.Count == size)
				used.Clear();
			SetQuestion ();
		}
		else
		{

			used.Add (intran);

			Debug.Log (intran);

			if(intran == 1)
			{
				question.Add("If I were a taco, how would you eat me?");
				question.Add("I would eat every last part of you until there was nothing left.");
				question.Add("I would make sure I had some water near by incase you were too hot to handle.");
				question.Add("You’d be so delicious that I would be finished with you in a second.");
				question.Add("I guess it depends on the taco.");
			}

			if(intran == 2)
			{
				question.Add("What’s your best quality?");
				question.Add("I do everything necessary to come out on top.");
				question.Add("I always plan in advance to have the proper precautions.");
				question.Add("I’m spontaneous and will choose to do something on the fly.");
				question.Add("All my qualities are great. I couldn’t pick just one.");
			}

			if(intran == 3)
			{
				question.Add("What song best describes you?");
				question.Add("Bring da Ruckus");
				question.Add("Brick House");
				question.Add("Greased Lightnin");
				question.Add("Really Don’t Care");
			}

			if(intran == 4)
			{
				question.Add("If you were to propose, how would you do it?");
				question.Add("We’re married now, congratulations.");
				question.Add("Wanna get a prenup?");
				question.Add("Let’s go to Vegas. Done and done.");
				question.Add("How would you like me to propose to you?");
			}

			if(intran == 5)
			{
				question.Add("What superpower would you want?");
				question.Add("TO DESTROY EVERYTHING!");
				question.Add("To protect myself from any weapon or threat!");
				question.Add("I want to go anywhere in the world in a second!");
				question.Add("I only get one? Hmm");
			}
		}

	}
	
}

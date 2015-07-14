using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaController : MonoBehaviour {
	public float MP;
	public float currMP;
	public float MPregen;
	public bool regenMode;
	
	public Scrollbar ManaBar;
	
	private float lerpDelay = 0.005f;
	private float nextLerp = 0;
	private float lerp = 0.01f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		ManaBar.size = currMP / MP;
		if(Time.time > nextLerp)
		{
			//Mana Bar lerping
			if(ManaBar.size != 1 && regenMode)
				currMP += MPregen;

			//Set next lerp time
			nextLerp = Time.time + lerpDelay;
		}
		
	}
	
	public void SetMP(int def)
	{
		MP = (float)def + 2;
		currMP = MP;
	}
	
	public float GetCurrMP()
	{
		return currMP;
	}
	
	public void AdjustCurrMP(float num)
	{
		currMP += num;
	}
}

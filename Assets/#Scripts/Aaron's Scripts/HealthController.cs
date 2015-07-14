using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	public float HP;
	public float currHP;

	public Scrollbar HealthBar;
	public Scrollbar ShadowBar;

	public float timer = 10;

	private float lerpDelay = 0.005f;
	private float nextLerp = 0;
	private float lerp = 0.01f;

	private float timerMax;

	// Use this for initialization
	void Start () {
		ShadowBar.size = HealthBar.size;

		timerMax = timer;
	}
	
	// Update is called once per frame
	void Update () {

		HealthBar.size = currHP / HP;
		if(Time.time > nextLerp)
		{
			if(HealthBar.size < ShadowBar.size)
				ShadowBar.size -= lerp;
			if(HealthBar.size > ShadowBar.size)
				ShadowBar.size = HealthBar.size;
			nextLerp = Time.time + lerpDelay;
		}

		//End Game
		if(timer < timerMax)
		{
			timer -= Time.deltaTime;
		}
		if(timer <= 0)
		{
			if(PlayerPrefs.GetInt ("TugOfWar") >= 3 || PlayerPrefs.GetInt ("TugOfWar") <= -3)
			{
				PlayerPrefs.DeleteAll();
				Application.LoadLevel("main menu");
			}
			else
			{
				if(PlayerPrefs.GetInt ("Level") >= 5)
				{
					float floatran = Random.Range (1, 5);
					int intran = (int)floatran;
					Application.LoadLevel ("Level " + intran);
				}
				else
				{
					int num = PlayerPrefs.GetInt ("Level");
					num += 1;
					Debug.Log ("num " + num);
					PlayerPrefs.SetInt ("Level", num);
					Application.LoadLevel ("Level " + num);
				}
			}
		}
	
	}

	public void SetHP(int def)
	{
		HP = (float)def + 2;
		currHP = HP;
	}

	public float GetCurrHP()
	{
		return currHP;
	}

	public void AdjustCurrHP(int num)
	{
		currHP += (float)num;
	}

	public void EndGame()
	{
		timer -= Time.deltaTime;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooter : MonoBehaviour {

	public int playerNum;

	public GameObject projectile;

	public GameObject bazooka;

	public float fireRate = 2f;

	public string type;

	private float nextFire = 0.0f;

	private ManaController ManaBar;

	public Orbital orbit;

	public Gravity g;

	public GameObject player;

	public GameObject planet;

	public float timer = 0.3f;

	private float tm = 0.3f;

	private AudioPlayer audio;

	private bool shoot = false;

	private bool special = false;
	
	public bool orbitNow = false;	

	void Start(){

		orbit = GetComponent<Orbital>();
		orbit.enabled = false;
		g = player.GetComponent<Gravity>();
		g.enabled = true;
		timer = tm;

		audio = gameObject.GetComponentInParent<AudioPlayer>();
	}

	// Update is called once per frame
	void Update () {
		if(playerNum == 0)
		{
			playerNum = gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().playerNum;
			ManaBar = GameObject.Find ("ManaBar " + playerNum).GetComponent<ManaController>(); 
			type = gameObject.transform.parent.gameObject.GetComponent<PlayerStats>().type;
		}
		if(/*Input.GetButtonDown("Player " + playerNum + " Shoot")*/ shoot)
			Fire ();
		//else if(Input.GetButtonDown("Player " + playerNum + " Special")&& ManaBar.GetCurrMP() > 0 && type == "A")
			//Special ();
		/*else if(Input.GetButtonDown("Player " + playerNum + " Special") && ManaBar.GetCurrMP() > 10 && type == "S"){
			if(Vector3.Distance(player.transform.position,planet.transform.position) <= 10){
			Vector3 up = planet.transform.position - transform.position;
			Vector3 targetPosition = player.transform.position - up.normalized*orbit.orbitHeight;
			player.transform.position = targetPosition;
				ManaBar.AdjustCurrMP(-0.5f);
				ManaBar.regenMode = false;
			//Debug.Log (Vector3.Distance(player.transform.position,planet.transform.position));}
			}
		}*/

			else if(/*Input.GetButton("Player " + playerNum + " Special")*/ special && ManaBar.GetCurrMP() > 0 && type == "S"){
				if(ManaBar.GetCurrMP() <= 5){


					g.enabled = true;
					orbit.enabled = false;
				}
				else{
					if(timer <= 0 && !orbitNow)
					{
						if(Vector3.Distance(player.transform.position,planet.transform.position) <= 10){
							Vector3 up = planet.transform.position - transform.position;
							Vector3 targetPosition = player.transform.position - up.normalized*orbit.orbitHeight;
							player.transform.position = targetPosition;
							ManaBar.AdjustCurrMP(-0.5f);
							ManaBar.regenMode = false;
							orbitNow = true;
						}
					
					}
				if(orbitNow){
					if(!audio.source.isPlaying)
						audio.PlayAudio (8);
					g.enabled = false;
					orbit.enabled = true;
					ManaBar.AdjustCurrMP(-1.5f);
				}
			}
			timer -= Time.deltaTime;
		}
		else if(/*Input.GetButtonUp("Player " + playerNum + " Special")*/ !special && ManaBar.GetCurrMP() > 0 && type == "S"){
			if(audio.source.clip == audio.audio[8])
			{
				audio.source.Stop();
			}
			g.enabled = true;
			orbit.enabled = false;
			ManaBar.regenMode = true;
			orbitNow = false;
			timer = tm;
		}
		if(/*Input.GetButton("Player " + playerNum + " Special")*/ special && ManaBar.GetCurrMP() > 0 && type == "D"){
			transform.FindChild("Shield").gameObject.SetActive(true);
		}
		else{
			transform.FindChild("Shield").gameObject.SetActive(false);

		}
			
		
	}

	public void Fire()
	{
		if (Time.time > nextFire) 
		{
			player.GetComponent<AudioPlayer>().PlayAudio(4);
			
			// setup cool down
			nextFire = Time.time + fireRate;
			GameObject clone = (GameObject)Instantiate (projectile, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
			clone.GetComponent<ProjectileMovement>().dmg = 1;
			clone.GetComponent<ProjectileMovement>().playerNum = playerNum;
		}
	}

	public void Special()
	{
		if (Time.time > nextFire) 
		{
			player.GetComponent<AudioPlayer>().PlayAudio(6);
			// setup cool down
			nextFire = Time.time + fireRate;
		GameObject clone = (GameObject)Instantiate (bazooka, new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.Euler(new Vector3(0, 0, -90)));
		clone.GetComponent<BazookaMovement>().dmg = 1;
			clone.GetComponent<BazookaMovement>().playerNum = playerNum;
			clone.GetComponent<BazookaMovement>().ManaBar = ManaBar;
			clone.GetComponent<BazookaMovement>().shooter = this; //this line added for android only
			if(playerNum == 1)
				clone.GetComponent<BazookaMovement>().target = GameObject.Find ("Player 2");
			if(playerNum == 2)
				clone.GetComponent<BazookaMovement>().target = GameObject.Find ("Player 1");
		}
	}

	public void SpecialOn()
	{
		special = true;

		if(/*Input.GetButtonDown("Player " + playerNum + " Special")*/ ManaBar.GetCurrMP() > 0 && type == "A")
			Special ();
	}

	public void SpecialOff()
	{
		special = false;
	}

	public bool IsSpecial()
	{
		return special;
	}
}

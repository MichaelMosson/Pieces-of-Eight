using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {

	public string characterName = "";

	public bool firstBoot = false;

	public float balance = 0f;
	public float experiencePoints = 0f;
	public float health = 1000f;
	public float armour = 0f;
	public float earningsPerTerm = 0.005f; //Term duration TBD
	public float level = 0f;
	public float xpReq;
	public float totalxp = 0;
	public float saveOfEPT;





	//Test Variables
	public float xpTestEarnings = 1;

		private HUD hud;

	// Use this for initialization
	void Start () {

		hud = GetComponent<HUD> ();

		if (level == 0f) {
			xpReq = 500f;
		}

		if (level > 0){
			xpReq = level * 1000f;
		}

		if (firstBoot == true) {
			//ask player to define 'name' and go to character creation scene
		}

	}

	void FixedUpdate () {

		balance = balance + earningsPerTerm;
		totalxp = totalxp + xpTestEarnings;
		
		if (health == 0f && armour == 0f) {
			onDeath ();
		}

		if (totalxp == xpReq) {
			onLevelUp ();
		}


	}

	void onPayment() {
		
	}

	void onLevelUp(){
		level = level + 1;
		xpReq = level * 1000f;
	}

	void onDeath() {
		saveOfEPT = earningsPerTerm;
		//earningsPerTerm = 0f;
		hud.alertText.text = "YOU ARE DEAD.";
		Time.timeScale = 0;
	}

	void onRestart () {
		//TODO set perameters for the game restarting
		Time.timeScale = 1;
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {

	public string characterName = "";

	public bool firstBoot = false;

	//variables for player stats
	public float balance = 0f;
	public float experiencePoints = 0f;
	public int paymentTimer = 0;
	public float paymentAmount = 0f;

	//Health is capped, cap raises by 10% when the player levels up
	public float health = 1000f;
	public float maxHealth = 1000f;
	public float healthPercentage = 0f;
	public bool isDead = false;
	public bool isRestarting = false;

	//No maximum amount for armour
	public float armour = 0f;

	public float earningsPerTerm = 0.005f; //Term duration TBD

	//variables relating to leveling of player
	public float level = 0f;
	public float xpReq;
	public float totalxp = 0;

	//Variables for clearing hud.alertText.text after a set period of time
	public bool alertTextEnabled = false;
	public int alertTextTimer = 0;

	//save of earnings per term, used in onDeath()
	public float saveOfEPT;

	//Test Variables
	public float xpTestEarnings = 1;

	//Variables for other classes
	private HUD hud;
	//private bankController bankController;
	private Crew crew;

	//This is run once at startup, before the start function is called
	void Awake (){
		
	}

	// Use this for initialization
	void Start () {

		hud = GetComponent<HUD> ();
		//bankController = GetComponent<bankController> ();
		crew = GetComponent<Crew> ();

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
		healthPercentage = (health / maxHealth) * 100;
		if (paymentTimer < 1001) {
			paymentTimer++;
		}
		if (paymentTimer > 1000) {
			onPayment ();
			Debug.Log ("Player was payed");
			paymentTimer = 0;
		}

		balance = balance + earningsPerTerm;
		totalxp = totalxp + xpTestEarnings;
		
		if (health == 0f && armour == 0f && !isDead) {
			onDeath ();
		}

		if (totalxp == xpReq) {
			onLevelUp ();
		}

		if (health > maxHealth) {
			health = maxHealth;
		}
		 
		if (alertTextEnabled) {
			if (alertTextTimer < 250) {
				alertTextTimer++;
			}

			if(alertTextTimer > 249) {
				Debug.Log ("alertTextTimer has ended");
				hud.alertText.text = "";
				alertTextEnabled = false;
				alertTextTimer = 0;

				if (isDead) {
					isRestarting = true;
					health = maxHealth * 0.75f;
					onRestart ();
				}
			}

		}

	}

	void onPayment() {
		balance = balance + 100;//The value 100 is a placeholder, the correct line is on line 122
		//balance = balance + bankController.playerPaymentAmount;
	}

	void onLevelUp(){
		//increase level value by one
		level = level + 1;
		xpReq = level * 1000f;

		hud.alertText.text = "Level "+level+" reached!";
		alertTextEnabled = true;

		Debug.Log ("Player Levelup, current lvl: " + level);

		//Increase player's max health and fully heal player
		maxHealth = maxHealth * 1.1f;
		health = maxHealth;
		Debug.Log ("maxHealth has increased, maxHealth = " + maxHealth);
	}

	void onDeath() {
		//Stops player's income
		saveOfEPT = earningsPerTerm;
		earningsPerTerm = 0f;

		//Show message on screen to player
		hud.alertText.text = "YOU ARE DEAD.";
		//TODO make restart and quit buttons visible and usable
		alertTextEnabled = true;
		isDead = true;



	}

	//Activated with button
	void onRestart () {
		Debug.Log ("Player Restarting!");
		//TODO set perameters for the game restarting
		health = maxHealth*0.75f;//Player restarts game on 75% of max health
		earningsPerTerm = saveOfEPT;
		isDead = false;

	}

	//determines how much the player is paid on the execution of onPayment
	void calculatePlayerPaymentAmount(){
		if (level == 0) {
			paymentAmount = 0.14f;
		}
		if (level == 1) {
			paymentAmount = 0.27f;
		}
		if (level == 2) {
			paymentAmount = 0.35f;
		}
		if (level == 3) {
			paymentAmount = 0.46f;
		}
		if (level == 4) {
			paymentAmount = 0.54f;
		}
		if (level == 5) {
			paymentAmount = 0.64f;
		}
		if (level > 5) {
			paymentAmount = 100f;
		}
	}
}

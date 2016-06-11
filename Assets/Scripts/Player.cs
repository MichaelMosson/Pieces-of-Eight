using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public int health = 100;
	public int armour = 0;
	public float balance = 0f;
	public float level = 0;
	public float experiencePoints = 1f;
	public float xpRequirement = 1f;
	public float timeLeft = 30f;


	private Crew crew;
	private ShipsRoster shipsRoster;



	//Runs before Start () function
	void Awake (){
	
		//TODO add the loading of a players stats
	}

	// Use this for initialization
	void Start () {
		crew = GetComponent<Crew> ();
		shipsRoster = GetComponent<ShipsRoster> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (level == 0) {
			xpRequirement = 500;
		} else {
			xpRequirement = level * 1000;
		}
			
		//on player's death
		if (health < 1 && armour < 1) {
			DEATH ();
		}

		if (experiencePoints == xpRequirement) {
			LEVELUP ();
		}
	}

	/*-=-=-=-=-=-=-=-=-=-=-=
	 END OF UPDATE FUNCTION
	-=-=-=-=-=-=-=-=-=-=-= */

	void DEATH () {
		Debug.Log ("player has died");
		//player looses 1/4 of their balance when they die (to pay the shaman to bring them back)
		balance = balance * 0.75;
	}

	void afterDeathRestart(){
		//player does not start with 100 health 
		health = 75;
	}

	void LEVELUP (){
		Debug.Log ("Player has leveled up to level " + level);
		level++;
		//TODO play sound and show text on screen
	}

}

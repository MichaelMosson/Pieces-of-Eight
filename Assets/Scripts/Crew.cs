using UnityEngine;
using System.Collections;

public class Crew : MonoBehaviour {

	private Player player;

	//variables relating to the crew
	public int numberOfCrew = 1;
	public int Happieness;
	public float desiredCut;
	public float actualCut;

	public int playerMutanyNumber;

	// Use this for initialization
	void Start () {
		player = GetComponent<Player> ();
		Happieness = 100;

		//Default cut and desired cut both 10% of player.balance
		//actual cut can be changed by the player in menus
		//desired cut may go up after a mutany
		actualCut = player.balance / 10;
		desiredCut = player.balance / 10;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (Happieness < 50) {
			//Roll the dice
			playerMutanyNumber = Random.Range(1,1000);
			if (playerMutanyNumber > 500) {
				checkForMutany ();
			}
		}

		//Cap on desired cut so that player.balance is not completely eaten by desiredCut
		if (desiredCut > 45) {
			desiredCut = 45;
		}
	}

	//Occurs if crew.happieness < 50 to see if any of the crew carry out mutany
	void checkForMutany (){

		playerMutanyNumber = Random.Range (1, 1000);
		//check for mutany
		//<0.5% chance of mutany
		if (Happieness < 50 && Happieness > 40){
			if (playerMutanyNumber > 995) {
				mutany ();
			}
		}
		//1% chance of mutany
		if (Happieness < 40 && Happieness > 30){
			if (playerMutanyNumber > 990) {
				mutany ();
			}
		}
		//15% chance of mutany
		if(Happieness < 30 && Happieness > 20){
			if (playerMutanyNumber > 850) {
				mutany ();
			}
		}
		//25% chance if mutany
		if(Happieness < 20 && Happieness > 10){
			if (playerMutanyNumber > 750) {
				mutany ();
			}
		}
		//45% chance of mutany
		if(Happieness < 10 && Happieness > 0){
			if (playerMutanyNumber > 550) {
				mutany ();
			}
		}
		//60% chance of mutany
		if (Happieness < 1) {
			if (playerMutanyNumber > 400) {
				mutany ();
			}
		}
	}

	//Occurs if there is a mutany, function determines how bad the consiquenses are
	void mutany (){
		
		Debug.Log ("You are probably fucked mate...");	
		//TODO make this a timed event
		desiredCut = desiredCut + 5;
	}
}

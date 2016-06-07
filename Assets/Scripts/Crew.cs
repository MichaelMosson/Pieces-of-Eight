using UnityEngine;
using System.Collections;

public class Crew : MonoBehaviour {


	int crewHappieness = 100;
	int crewRoster = 1;//Player is counted in crewRoster too

	//TODO load stats

	private Player player;
	private ShipsRoster shipsRoster;

	// Use this for initialization
	void Start () {
		player = GetComponent<Player> ();
		shipsRoster = GetComponent<ShipsRoster> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (crewHappieness < 55) {
			int mutinyEventChance = Random.Range (0, 1000);
			if (mutinyEventChance < 11) {
				checkForMutiny ();
			}
			if (crewHappieness < 10) {
				checkForMutiny ();
			}
		}

	}

	void checkForMutiny (){

		//random number to determine if a mutiny event takes place
		int chanceOfMutiny = Random.Range (0, 100);
		Debug.Log (chanceOfMutiny);

		//low chance of mutiny
		if (crewHappieness > 50) {
			if (chanceOfMutiny < 10) {
				MutinyEvent ();
			}
		} else if (crewHappieness < 50 && crewHappieness > 40) {
			if (chanceOfMutiny < 30) {
				MutinyEvent ();
			}
		} else if (crewHappieness < 40 && crewHappieness > 30) {
			if (chanceOfMutiny < 50) {
				MutinyEvent ();
			}
			if (chanceOfMutiny > 51) {
				//TODO alert player that there is talk of mutiny
			}
		} else if (crewHappieness < 30 && crewHappieness > 20) {
			if (chanceOfMutiny < 75) {
				MutinyEvent ();
			}
		} else if (crewHappieness < 20 && crewHappieness > 15) {
			if (chanceOfMutiny < 85) {
				MutinyEvent ();
			}
		} else if (crewHappieness < 15) {
			//1% chance of not 
			if (chanceOfMutiny < 100) {
				MutinyEvent ();
			}
		}

	}

	void MutinyEvent(){
		
		Debug.Log ("Mutiny Event Active");
		//Change scene to Mutiny 
		//Player may loose ships, gold, and health as well as loosing some of the crew

		int chanceOShipCaptured = Random.Range (0, 100);

		//player can not loose their last ship
		if (shipsRoster.numberOfShips < 2) {
			chanceOShipCaptured = 100;
		}
		if (chanceOShipCaptured > 90 && chanceOShipCaptured < 99) {
			shipsRoster.lossOfShip ();
			crewRoster = crewRoster - 15;
		}
		if (chanceOShipCaptured > 80 && chanceOShipCaptured < 91) {
			shipsRoster.lossOfShip ();
			crewRoster = crewRoster - 20;
			player.balance = player.balance - 100;
		}
		if (chanceOShipCaptured > 65 && chanceOShipCaptured < 81) {
			crewRoster = crewRoster - 40;
			player.balance = player.balance *  0.85;
		}
		if (chanceOShipCaptured > 50 && chanceOShipCaptured < 66) {
		}
		if (chanceOShipCaptured > 40 && chanceOShipCaptured < 51) {
		}
		if (chanceOShipCaptured > 30 && chanceOShipCaptured < 41) {
		}
		if (chanceOShipCaptured > 20 && chanceOShipCaptured < 31) {
		}
		if (chanceOShipCaptured > 10 && chanceOShipCaptured < 21) {
		}
		if (chanceOShipCaptured > 0 && chanceOShipCaptured < 11) {
		}
		if (chanceOShipCaptured == 100) {
			player.balance = player.balance * 0.7;
		}
	}
}

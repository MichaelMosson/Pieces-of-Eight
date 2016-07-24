using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BankingSystem : MonoBehaviour {

	private Player player;
	private Crew crew;

	//NOTE: All monetary variables have to be of float type
	public float dockRentCost;
	public float boatMaintenienceCost;
	//Restocking costs are based on the number of crew
	public float restockingAmmoCost;
	public float restockingProvisionsCost;
	public float paymentAmount;


	// Use this for initialization
	void Start () {
		player = GetComponent<Player> ();
		crew = GetComponent<Crew> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		setRestockingCosts ();
	}

	//TODO numbers may be changed later on in game's development cycle so to create balance

	//Function sets restocking costs that the player needs
	void setRestockingCosts(){
		
		restockingAmmoCost = crew.numberOfCrew * 20;
		restockingProvisionsCost = crew.numberOfCrew * 15;

		if (crew.numberOfCrew > 1000) {
			restockingAmmoCost = restockingAmmoCost + 500;
			restockingProvisionsCost = restockingProvisionsCost + 350;
		}
		if (crew.numberOfCrew > 2500) {
			restockingAmmoCost = restockingAmmoCost + 600;
			restockingProvisionsCost = restockingProvisionsCost + 420;
		}
		if (crew.numberOfCrew > 5000) {
			restockingAmmoCost = restockingAmmoCost + 700;
			restockingProvisionsCost = restockingProvisionsCost + 490;
		}
		if (crew.numberOfCrew > 7500) {
			restockingAmmoCost = restockingAmmoCost + 750;
			restockingProvisionsCost = restockingProvisionsCost + 530;
		}
		if (crew.numberOfCrew > 10000) {
			restockingAmmoCost = restockingAmmoCost + 900;
			restockingProvisionsCost = restockingProvisionsCost + 600;
		}
		if (crew.numberOfCrew > 15000) {
			restockingAmmoCost = restockingAmmoCost + 1000;
			restockingProvisionsCost = restockingProvisionsCost + 750;
		}
		if (crew.numberOfCrew > 15000) {
			restockingAmmoCost = restockingAmmoCost + 1500;
			restockingProvisionsCost = restockingProvisionsCost + 900;
		}
		if (crew.numberOfCrew > 20000) {
			restockingAmmoCost = restockingAmmoCost + 2000;
			restockingProvisionsCost = restockingProvisionsCost + 1337;
		}
	}

	void setBoatRelatedCosts (){
		//TODO calculate boat related costs, this is based on how many ships the player has and how many crew the player has
	}
}

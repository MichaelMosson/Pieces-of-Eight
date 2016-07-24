using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class HUD : MonoBehaviour {

	//Link other classes with this class to use their variables
	private Player player;

	//hud.x is a test variable
	public float truncatedBalance;

	//Text elements variables
	public Text levelText;
	public Text balanceText;
	public Text eptText;
	public Text alertText;

	public string suffix = "";

	// Use this for initialization
	void Start () {
		
		player = GetComponent<Player> ();

		//Set the texts to 
		setHUDTexts ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		truncateBalance ();
		updateTexts ();
	}

	//Sets texts when the game is launched
	void setHUDTexts (){
		levelText.text = "level: 0";
		balanceText.text ="0 Gold";
		eptText.text ="0.05 Gold/s";
		alertText.text = "";
	}

	void updateTexts(){
		levelText.text = "level: "+player.level.ToString();
		//balanceText.text = player.balance.ToString ("n2") + " Gold";
		balanceText.text = truncatedBalance.ToString("n2") + suffix + " Gold ";
		eptText.text = player.earningsPerTerm.ToString() + " Gold/s";

	}

	void truncateBalance (){
		/*changes player.balance to a number between 1.00 - 10.00 and adds the appropriate prefix
		 * example 1,230,470 becomes written as 1.23 Million. */

		if (player.balance < 1000) {
			
			truncatedBalance = player.balance;
			suffix = "";
		}

		if (player.balance > 999.99 && player.balance < 1000000) {
			
			truncatedBalance = player.balance / 1000f;
			suffix = "K";
		} 

		if (player.balance > 999999.99 && player.balance < 1000000000) {

			truncatedBalance = player.balance / 1000000f;
			suffix = "M";
			}

		//TODO fix bugs with numbers below
		if(player.balance > 999999999.99 && player.balance < 1000000000000){

			truncatedBalance = player.balance / 1000000000f;
			suffix = "Bn";
		
		   }

		if(player.balance > 999999999999.99 && player.balance < 1000000000000000){

			truncatedBalance = player.balance / 1000000000000f;
			suffix = "Tn";

		   }

		if(player.balance > 999999999999999.99 && player.balance < 1000000000000000000){

			truncatedBalance = player.balance / 1000000000000000f;
			suffix = "Quad";

		   }

	}


}

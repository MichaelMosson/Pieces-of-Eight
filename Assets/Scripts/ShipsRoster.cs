using UnityEngine;
using System.Collections;

public class ShipsRoster : MonoBehaviour {

	private Player player;

	//base number of ships is 10
	public int maxNumberOShips = 10;
	public int numberOfShips = 1;

	//TODO load stats

	// Use this for initialization
	void Start () {
		player = GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void lossOfShip () {
		numberOfShips = numberOfShips - 1;
	}


}

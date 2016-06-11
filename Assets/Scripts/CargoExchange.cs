using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CargoExchange : MonoBehaviour {


	/*
	 * TODO Hundreds of errors here, complete re-write needed 
	 * 
	//Price index's can make the price of a stock rise or fall dramatically
	//Luxury Price Index
	float LPI = 1;
	//Essential Price Index
	float EPI = 1;

	//cargo is transported and sold in units

	 // find a way to store data for the stock market
	 // need to store ID, Item type (Lux or Ess), Base price, and Unlock level (Unlock level may be removed?)
	float [,] cargo = new float[100, 100]{
		//ID | Item Type | Base Unit Price (constant) | Unlock Level
		//Luxury = 1, Essential = 2
		//Final price can be a decimal - anything lower than a whole gold is a silver
		{1, 2, 35, 1},//Timber
		{2, 2, 20, 1},//Farming ploughs
		{3, 2, 30, 1},//Raw Metal
		{4, 2, 20, 1},//Grain
		{5, 1, 35, 3},//Brandy
		{6, 1, 35, 3},//Port
		{7, 1, 35, 3},//Rum
		{8, 2, 10, 1},//Ale
		{9, 2, 10, 1},//Beer
		{10, 2, 20, 5},//Preserved Fruits
		{11, 1, 60, 5}//Fresh Fruits
	};


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Inflation and Deflation can happen sometimes
	void randomDeflation (){
		float deflationAmmount = Random.Range (0.5, 0.9);
		LPI = LPI - deflationAmmount;
		deflationAmmount = Random.Range (0.5, 0.9);
		EPI = EPI - deflationAmmount;
	}

	void randomInflation (){
		float inflationAmmount = Random.Range (0.5, 0.9);
		LPI = LPI + inflationAmmount;
		inflationAmmount = Random.Range (0.5, 0.9);
		EPI = EPI + inflationAmmount;
	}

	void resetMarket (){
		LPI = 1;
		EPI = 1;
	}


	void marketCrash (){
		//When market crash event takes place this calculates how bad it is 
		float crashSeverity = Random.Range (0.05, 0.5);
		LPI = LPI * crashSeverity;
		crashSeverity = Random.Range (0.05, 0.5);
		EPI = EPI * crashSeverity;
	}
}
*/
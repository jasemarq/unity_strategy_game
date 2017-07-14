using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SIRManager : MonoBehaviour {
 
	protected double susceptible, infected, removed;
	protected double infectivityRate, lethalityRate;
	protected double sus, inf, rem;
	protected double susceptibleF, infectedF, removedF;
	protected double susp;
	protected double population_sum, infected_sum, removed_sum;

	// Use this for initialization
	void Start () 
	{
		Invoke ("startingCountry", 5f);
		InvokeRepeating ("updateSIRValues", 0, 1f);
		allTransmissionVectors ();
	}
		
	// Update is called once per frame
	void Update () 
	{
	}
		
	// Infectivity Rate, can get disease info?
	protected void infectivityBaseValue()
	{
	}

	// lethality base rate.
	protected void lethalityBaseValue()
	{
	}

	// Each country can have an infectivity Value and Lethality Value that is determined in prior functions
	// and that value is used to determine the SIR in time step.

	// Susceptible population for given country.
	protected double Susceptible(double susceptible, double infected, double infectivityRate) 
	{
		sus = susceptible - susceptible * infected * infectivityRate;
		return sus;
	}

	// Infected population for given country.
	protected double Infected(double susceptible, double infected, double infectivityRate, double lethalityRate)
	{
		inf = (infected + susceptible * infected * infectivityRate) - (infected * lethalityRate);
		return inf;
	}

	// Removed population for given country.
	protected double Removed(double removed, double infected, double lethalityRate) 
	{
		rem = removed + infected * lethalityRate;
		return rem;
	}

	// Game adjustment for infection rate requires play testing.

	// WORLD FUNCTION

	protected void worldCalculation()
	{
		foreach (KeyValuePair<string, Country> world in GameManager.Instance.Country) 
		{
			GameManager.Instance.worldPopulation = 
				System.Math.Floor(GameManager.Instance.worldPopulation =+ GameManager.Instance.Country [world.Value.id].population);

			GameManager.Instance.worldInfected =
				System.Math.Ceiling(GameManager.Instance.worldInfected = GameManager.Instance.Country [world.Value.id].infected);

			GameManager.Instance.worldRemoved =
				System.Math.Floor(GameManager.Instance.worldRemoved = GameManager.Instance.Country[world.Value.id].removed);
		}
	}


	// PANDEMIC FUNCTIONS

	public bool startingCountry() 
	{
		string startingCountry;
		System.Random rand = new System.Random();
		startingCountry = GameManager.Instance.Country.ElementAt(rand.Next(0, GameManager.Instance.Country.Count)).Key;

		if (startingCountry == "R255G255B255") {
			startingCountry = GameManager.Instance.Country.ElementAt(rand.Next(0, GameManager.Instance.Country.Count)).Key;
		}
		Debug.Log (startingCountry);
		int initialInfected = Random.Range (300, 700);
		GameManager.Instance.Country [startingCountry].infected = initialInfected;
		Debug.Log (GameManager.Instance.Country [startingCountry].name + " is the origin country!");
		var msgbox = GameObject.Find ("eventPanel").GetComponent<CanvasRenderer> ();
		msgbox.SetAlpha (255f);
		Time.timeScale = 0;
//		EventManager.Instance.eventBodyText.text = "An unknown disease has been discovered in " 
//			+ GameManager.Instance.Country [startingCountry].name
//				+ ". Send an epidemiologist team to investigate.";
//			GameManager.Instance.timeManager = 1;
		return true;
	}


	// SCIENTIST FUNCTIONS


	// PHYSICIAN FUNCTIONS

	protected void physicianResistance()
	{
		foreach (KeyValuePair<string, Country> phy in GameManager.Instance.Country) 
		{
			if (phy.Value.phyPresent == true) 
			{
				// Add to the base resistance to the country according to the physician resistance.
				// I can analyze by graphing infectivity rate for a given country over period of time, and taking area of curve.
				// Then, I can set where I would want the value to be for a given period of time, and add physicianResistance for that.
				// Calculus for the win.
			}
		}
	}

	// EPIDEMIOLOGIST FUNCTIONS

	protected void epidemiologistDiscovery()
	{
		foreach (KeyValuePair<string, Country> epi in GameManager.Instance.Country) 
		{
			if (epi.Value.epiPresent == true) 
			{
				// Epidemiologists should have set amount of discovery time? A week?
				// Then that information can shorten I imagine.
				// Need to figure out the time step shit.

				// 1. Determine percentage chance of disease information discovery.
				// 2. Run and select which value of disease will be determined.
				// 3. In menu canvas, set disease panel corresponding to it as active.
				// 4. Raise an event alert for player.
			}
		}
	}


	// TRANSMISSION FUNCTIONS

	protected void allTransmissionVectors()
	{
		InvokeRepeating("landTransmission",5, 1f);
		InvokeRepeating("seaTransmission",5, 1f);
		InvokeRepeating("airTransmission",5, 1f);
	}

	protected void landTransmission()
	{
		foreach (KeyValuePair<string, Country> transmit_land in GameManager.Instance.Country) {
			if (transmit_land.Value.infected > 0) {
				// insert random thing here.
				// ... Jay Z beat Nas.
				double transmission = Random.Range (0, 100);
				Debug.Log (transmission);
				// deny means when infected / pop * 1000 max being 6%)
				double deny = (transmit_land.Value.infected /
					transmit_land.Value.population) * 100;
				if (deny > 5) {
					deny = 5;
				}
				if (transmission < deny) {
					string country_infect =
					GameManager.Instance.Country [transmit_land.Value.id].borderingLand [Random.Range (0, GameManager.Instance.Country 
							[transmit_land.Value.id].borderingLand.Length)];
					if (GameManager.Instance.Country.ContainsKey (country_infect)) {
						GameManager.Instance.Country [country_infect].infected += 1;
						GameManager.Instance.Country [transmit_land.Value.id].infected -= 1;
						Debug.Log (GameManager.Instance.Country [country_infect].name + " is infected by land!");
					}	
				}
			}
		}
	}

	// Update to contain correct values.

	protected void seaTransmission()
	{
		foreach (KeyValuePair<string, Country> transmit in GameManager.Instance.Country) {
			if (transmit.Value.infected > 0) {
				// insert random thing here.
				// ... Jay Z beat Nas.
				double transmission = Random.Range (0, 100);
				Debug.Log (transmission);
				// deny means when infected / pop * 1000 max being 6%)
				double deny = (transmit.Value.infected /
					transmit.Value.population) * 100;
				if (deny > 5) {
					deny = 5;
				}
				if (transmission < deny) {
					string country_infect =
						GameManager.Instance.Country [transmit.Value.id].borderingSea [Random.Range (0, GameManager.Instance.Country 
							[transmit.Value.id].borderingSea.Length)];
					if (GameManager.Instance.Country.ContainsKey (country_infect)) {
						GameManager.Instance.Country [country_infect].infected += 1;
						GameManager.Instance.Country [transmit.Value.id].infected -= 1;
						Debug.Log (GameManager.Instance.Country [country_infect].name + " is infected by sea!");
					}	
				}
			}
		}
	}

	// Update to contain correct values.

	protected void airTransmission()
	{
		foreach (KeyValuePair<string, Country> transmit in GameManager.Instance.Country) {
			if (transmit.Value.infected > 0) {
				// insert random thing here.
				// ... Jay Z beat Nas.
				double transmission = Random.Range (0, 100);
				Debug.Log (transmission);
				// deny means when infected / pop * 1000 max being 6%)
				double deny = (transmit.Value.infected /
					transmit.Value.population) * 100;
				if (deny > 5) {
					deny = 5;
				}
				if (transmission < deny) {
					string country_infect =
						GameManager.Instance.Country [transmit.Value.id].borderingAir [Random.Range (0, GameManager.Instance.Country 
							[transmit.Value.id].borderingAir.Length)];
					if (GameManager.Instance.Country.ContainsKey (country_infect)) {
						GameManager.Instance.Country [country_infect].infected += 1;
						GameManager.Instance.Country [transmit.Value.id].infected -= 1;
						Debug.Log (GameManager.Instance.Country [country_infect].name + " is infected by air!");
					}	
				}
			}
		}
	}
		
	// Update SIR values for next timestep.
	protected void updateSIRValues() {
		
		// Run functions to determine susceptible, infected and removed population.
		foreach(KeyValuePair<string, Country> entry in GameManager.Instance.Country)
		{
			susceptibleF = Susceptible(entry.Value.population,entry.Value.infected,0.0000000005);
			infectedF = Infected (entry.Value.population,entry.Value.infected,0.0000000005, 0.00);
			removedF = Removed (entry.Value.removed,entry.Value.infected,0.00);
			entry.Value.population = System.Math.Floor (susceptibleF);
			entry.Value.infected = System.Math.Ceiling (infectedF);
			entry.Value.removed = System.Math.Floor (removedF);
		}
	}
}



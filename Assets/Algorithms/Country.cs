using UnityEngine;
using System.Collections;


public class Country {

	public string id;
	public string name;
	public double population;
	public double infected;
	public double removed;
	public double baseResistance;
	public string climate;
	public bool epiPresent;
	public bool phyPresent;
	public string[] borderingLand;
	public string[] borderingSea;
	public string[] borderingAir;


	public Country(string id, string name, double population, 
		double infected, double removed, double baseResistance, string climate, bool epiPresent, bool phyPresent,
		string[] borderingLand, string[] borderingSea, string[] borderingAir) 
	{
		this.id = id;
		this.name = name;
		this.population = population;
		this.infected = infected;
		this.removed = removed;
		this.baseResistance = baseResistance;
		this.climate = climate;
		this.epiPresent = epiPresent;
		this.phyPresent = phyPresent;
		this.borderingLand = borderingLand;
		this.borderingSea = borderingSea;
		this.borderingAir = borderingAir;

	}
		

} 

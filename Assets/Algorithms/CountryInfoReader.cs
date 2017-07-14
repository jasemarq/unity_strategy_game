using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class CountryInfoReader {

	protected string name;
	protected string climate;
	protected string id;
	protected double population;
	protected double infected;
	protected double removed;

	// Base resistance value will need to be influenced by if physicianPresence is there.
	protected double baseResistance;
	protected bool epiPresent;
	protected bool phyPresent;

	// These will need to be arrays, can parse via '&' character, see pandemic code for reference.
	protected string[] borderingLand;
	protected string[] borderingSea;
	protected string[]  borderingAir;

	// protected string countryAffinity; -- this will determine the regions' research affinity. ex: France in Western Europe affinity is fever.
	// protected string epidemiologistPresence; -- this will determine if the region has a epidemiologist team present. If yes, certain functions will be run. 
	// protected string physicianPresence; -- this will determine if the region has a physician team present. If yes, certain functions will be run.


	// pandemic will need to keep track of ground zero region. deployment of epidemiologist to ground zero will allow for... stuff.

	JsonData info;

	public Dictionary<string, Country> countryInfoReader(JsonData info) 
	{
		Dictionary<string, Country> countries 
		= new Dictionary<string, Country> ();

			for (int i = 0; i <= 31; i++) 
			{ 
			
			id = info ["Countries"] [i] ["id"].ToString();
			name = info["Countries"] [i] ["name"].ToString();
			population = double.Parse (info["Countries"][i]["population"].ToString());
			infected = double.Parse (info["Countries"][i]["infected"].ToString());
			removed = double.Parse (info["Countries"][i]["removed"].ToString());
			baseResistance = double.Parse (info ["Countries"] [i] ["baseResistance"].ToString ());
			climate = info ["Countries"] [i] ["climate"].ToString ();

			epiPresent = bool.Parse (info ["Countries"] [i] ["epiPresent"].ToString ());
			phyPresent = bool.Parse (info ["Countries"] [i] ["phyPresent"].ToString ());

			borderingLand = info ["Countries"] [i] ["borderingLand"].ToString ().Split('&');
			borderingSea = info ["Countries"] [i] ["borderingSea"].ToString ().Split('&');
			borderingAir = info ["Countries"] [i] ["borderingAir"].ToString ().Split('&');

			foreach (string s in borderingLand) {
				Debug.Log (s);
			}

			Country country = new Country (id, name, population, infected, 
				removed, baseResistance, climate, epiPresent, phyPresent, borderingLand, borderingSea, borderingAir);

			countries.Add (id, country);

			}

		return countries;

	}

	}

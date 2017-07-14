using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class Pandemic 
{
	public string pandemic_id; // ex: insomnia
	public bool symptom; // ex: false
	public string desc; // Sufferer unable to sleep.
	public int cost; // 5
	public string[] heirarchy; // stuff

	public Pandemic(string pandemic_id, bool symptom,
		string desc, int cost, string[] heirarchy)
	{
		this.pandemic_id = pandemic_id;
		this.symptom = symptom;
		this.desc = desc;
		this.cost = cost;
		this.heirarchy = heirarchy;
	}

	// Research Interventions

	// Maybe all be bool values, and set to false. Then once set to TRUE, the function will affect that value. I guess?

	// Should stability be a factor? Yes. fuck it.

}

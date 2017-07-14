using UnityEngine;
using System.Collections;

public class Research {

	// Research Interventions
	protected string id; // ex: phage theraphy
	protected bool researched; // ex: false
	protected string description; // ex: manipulation of bacteriophages.
	protected int userCost; // ex: 12
	protected string[] techHeirarchy; // ex: stuff

	public Research(string id, bool name,
		string description, int userCost, string[]techHeirarchy)
	{
		this.id = id;
		this.researched = researched;
		this.description = description;
		this.userCost = userCost;
		this.techHeirarchy = techHeirarchy;
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class ResearchInfoReader 
{
	protected string id;
	protected bool researched;
	protected string description;
	protected int userCost;
	protected string[] techHeirarchy;

	JsonData technology;

	public Dictionary<string, Research> researchReader(JsonData technology)
	{
		Dictionary<string, Research> research
		= new Dictionary<string, Research> ();
		for (int i = 0; i <= 20; i++) 
		{
		id = technology ["Pandemic"] [i] ["pandemic_id"].ToString ();
		researched = bool.Parse (technology ["Pandemic"] [i] ["symptom"].ToString ());
		description = technology ["Pandemic"] [i] ["desc"].ToString ();
		userCost = int.Parse (technology ["Pandemic"] [i] ["cost"].ToString ());
		techHeirarchy = technology ["Pandemic"] [i] ["cost"].ToString ().Split ('&');
		Research rese = new Research (id, researched, description, userCost, techHeirarchy);
		research.Add (id, rese);
		}
		return research;
	}
}

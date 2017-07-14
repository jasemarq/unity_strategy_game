using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class PandemicInfoReader 
{

	protected string pandemic_id;
	protected bool symptom;
	protected string desc;
	protected int cost;
	protected string[] heirarchy;

	JsonData disease;

	public Dictionary<string, Pandemic> pandemicReader(JsonData disease)
	{
		Dictionary<string, Pandemic> pandemic 
		= new Dictionary<string, Pandemic> ();

		for (int i = 0; i <= 10; i++) 
		{
			pandemic_id = disease ["Pandemic"] [i] ["pandemic_id"].ToString ();
			symptom = bool.Parse (disease ["Pandemic"] [i] ["symptom"].ToString ());
			desc = disease ["Pandemic"] [i] ["desc"].ToString ();
			cost = int.Parse (disease ["Pandemic"] [i] ["cost"].ToString ());
			heirarchy = disease ["Pandemic"] [i] ["cost"].ToString ().Split ('&');
			Pandemic pand = new Pandemic (pandemic_id, symptom, desc, cost, heirarchy);
			pandemic.Add (pandemic_id, pand);
		}
		return pandemic;
	}
}

using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;


public class jsonInput {

	protected bool standard = true;
	protected string userSelection;

	// Country variables
	private string jsonString;
	private JsonData countryInfo;

	// Pandemic variables
	private string jsonStringP;
	private JsonData pandemicInfo;

	// Research variables
	private string jsonStringR;
	private JsonData researchInfo;



	// Country Scenario Selection
	public JsonData JsonInputCountry () 
	{
		// So this doesn't work, and in order for me to get the country clicking correct, it needs to.

		//TextAsset file = Resources.Load("/Assets/Resources/EPICountryDataV2.json") as TextAsset;
		//jsonString = file.ToString ();

		//string jsn = Resources.Load<jsonInput> ("/Resources/EPICountryDataV2.json");
		//countryInfo = JsonMapper.ToObject (jsonString);
		//string filepath = System.IO.Path.Combine(Application.streamingAssetsPath, "EPICountryDataV2.json");
		//jsonString = System.IO.File.ReadAllText(filepath);

		//TextAsset textFile = Resources.Load ("EPICountryDataV2.json") as TextAsset;
		//jsonString = textFile.text;

		//jsonString = txt.ToString();
	//	jsonString = File.ReadAllText (Application.dataPath + "/Resources/" +
	//		textFile);
		jsonString = File.ReadAllText (Application.dataPath +
			"/Resources/EPICountryDataV2.json");
		countryInfo = JsonMapper.ToObject (jsonString);
		return countryInfo;
	}

	public JsonData JsonInputPandemic () 
	{
		
	// Epidemic Scenario Selection 
		if (standard == true) 
		{
			jsonStringP = File.ReadAllText (Application.dataPath + 
				"/Scenarios/Default/EPIPandemicData.json");
			pandemicInfo = JsonMapper.ToObject (jsonStringP);
			return pandemicInfo;
		} 

		else 
		{
			jsonStringP = File.ReadAllText (Application.dataPath + 
				userSelection);
			pandemicInfo = JsonMapper.ToObject (jsonStringP);
			return pandemicInfo;
		}
	}

	public JsonData JsonInputResearch ()
	{
		// Research Scenario Selection
		jsonStringR = File.ReadAllText (Application.dataPath +
		"/Scenarios/Default/EPIResearchData.json");
		researchInfo = JsonMapper.ToObject (jsonStringR);
		return researchInfo;
	}



}

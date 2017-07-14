using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class GameManager : MonoBehaviour 
{
	// Access GameManager script.
	private static GameManager _instance;

	// Return instance.
	public static GameManager Instance
	{
		get
		{ 
			if (_instance == null)
			{
				GameObject go = new GameObject ("Game Manager");	
				go.AddComponent<GameManager>();
			}

			return _instance;
		}
	}

	// Game Manager Members
	public void Pause(bool paused)
	{
		Time.timeScale = 0;
		//Time.timeScale = 1;
	}

	public void inPlay(bool play)
	{
		Time.timeScale = 1.0f;
		GameManager.Instance.timeManager = 2f; // Every two seconds, functions will run in the start.
	}

	public void inPlayFast(bool playFast)
	{
		Time.timeScale = 1.0f;
		GameManager.Instance.timeManager = 1f; // Every one second, functions will run in the start.
	}

	public void Deploying(bool deploying)
	{
		Time.timeScale = 0;
	}

	public void gameOver(bool GameOver)
	{
		Time.timeScale = 0;
		// Load ending scene.
	}

	public void gameStart(bool GameStart)
	{
		Time.timeScale = 0;
	}

	public void Menu(bool menu)
	{
		Time.timeScale = 0;
	}

	public void Options(bool options)
	{
		Time.timeScale = 0;
	}

	// DEFINED VARIABLES
		
	// Capital: User political capital. ( Combination of money & influence )
	public int Capital { get; set; }

	// Stability: User country stability. Lessened by harsh government measures.
	private int Stability { get; set; }

	// Cure
	// 
	public int Cure { get; set; }

	// Time Manager
	public float timeManager {get; set; }

	// Score: User score. ( Need to determine formula. Population saved + length  of time? )
	private int _score { get; set; }

	// Epidemiologist, Scientist  & Physician Count: User counts. 
	public int EpidemiologistCount { get; set; } 
	public int ScientistCount { get; set; }
	public int PhysicianCount { get; set; }

	public int epiEffectiveness;
	public int phyEffectiveness;

	// Research Penalty -- the penalty to user research based on game mode.
	public double researchPenalty;

	// Start out with three physician forces in normal, two in hard, four in easy.
	// In easy mode, scientists research 8% faster.
	// In hard mode, scientists reseach 8% slower. (Those values can change) 

	public Dictionary<string, Country> Country { get; set; }
	public Dictionary<string, Pandemic> Pandemic { get; set; }
	public Dictionary<string, Research> Research { get; set; }

	public Text regionName;
	public Text infectedValue;

	// WORLD VALUES ( Might not be necessary )

	public double worldPopulation;
	public double worldInfected;
	public double worldRemoved;

	public Text capitalTracker;
	public Text panicTracker;
	public Text cureTracker;


	// Selected Country

	public string selectedCountry;
	public string selectedId;
	public string selectedName;
	public double selectedPopulation;
	public double selectedInfected;
	public double selectedRemoved;
	public double selectedbaseResistance;
	public string selectedClimate;
	public bool selectedIsInfect;
	public string[] selectedBorderingLand;
	public string[] selectedBorderingSea;
	public string[] selectedBorderingAir;

	public string value;

	//Player action determines those values that are in the start function.
	public bool _Easy = false;
	public bool _Medium = false;
	public bool _Hard = false;

	colorMapping cm = new colorMapping();
	getUVCoords uvc = new getUVCoords();

	string rname;
	string rinfected;
	SIRManager sir;

	void Awake() 
	{
		_instance = this;
	}

	void Start() 
	{

	//	Debug.Log (Application.persistentDataPath);
	//	Debug.Log (Application.dataPath);
	// Sprite Component
	// sprite = GameObject.Find ("R255G255B140");
	// sprite.GetComponent<SpriteRenderer>().enabled = false;

		GameManager.Instance.Cure = 100; // I imagine the set accessor is accessed here as well...

		// UI
		regionName.text = "World";
		infectedValue.text = "--";
		//capitalTracker.text = GameManager.Instance.Capital.ToString ();

		timeManager = 1;
			
	//	GameObject sprite = GameObject.Find("TransparentUSA_0");
	//	sprite.GetComponent<SpriteRenderer> ().enabled = false;

		// GAMEPLAY & DATA
		Country = initializeCountryList ();
		Pandemic = initializePandemic ();
		Research = initializeResearch ();

		//sir.startingCountry ();

		Capital = 100;
		//Debug.Log (Capital);

		if (_Easy == true) 
		{
			EpidemiologistCount = 1;
			ScientistCount = 1; 
			PhysicianCount = 4;
			researchPenalty = 0.08;

		}

		if (_Medium == true) 
		{
			EpidemiologistCount = 1;
			ScientistCount = 1;
			PhysicianCount = 3;
			researchPenalty = 0;
		}

		if (_Hard == true) 
		{
			EpidemiologistCount = 1;
			ScientistCount = 1;
			PhysicianCount = 2;
			researchPenalty = -0.08;
		}

		// AUDIO


		updateValues ();
	}

	// Retrieve country .json file (In future expansions, allows for scenario swapping)
	Dictionary<string,Country> initializeCountryList() 
	{
		jsonInput js = new jsonInput();
		CountryInfoReader CountryInfo = new CountryInfoReader();
		return CountryInfo.countryInfoReader (js.JsonInputCountry());
	}

	// Retrieve pandemic .json file (In future expansions, allows for scenario swapping)
	Dictionary<string, Pandemic> initializePandemic()
	{
		jsonInput pd = new jsonInput ();
		PandemicInfoReader PandemicInfo = new PandemicInfoReader ();
		return PandemicInfo.pandemicReader (pd.JsonInputPandemic());
	}

	Dictionary<string, Research> initializeResearch ()
	{
		jsonInput re = new jsonInput ();
		ResearchInfoReader ResearchInfo = new ResearchInfoReader ();
		return ResearchInfo.researchReader (re.JsonInputResearch ());
	}

	// Need to define research according to the results that will be acceptable in accordance with how I want.

	void Update()
	{
		// Need to get rid of the world value and add up all the population values and other stuff.	
		// How am I going to run that? Do I put that in a function? Yeah sure.
		if (Input.GetMouseButtonDown (0) && (
			GameManager.Instance.Country[cm.colorIDMatch(uvc.UVCoordinates())].id != "R255G255B255")) 
		{
			// Insert that function here.
			selectedCountry = cm.colorIDMatch (uvc.UVCoordinates ());
		}

		regionName.text = GameManager.Instance.Country [selectedCountry].name;
		infectedValue.text = GameManager.Instance.Country [selectedCountry].population.ToString ("#,##0.") + "<color=grey> / " +
		GameManager.Instance.Country [selectedCountry].infected.ToString ("#,##0.") + "</color>" + "<color=white> / " +
		GameManager.Instance.Country [selectedCountry].removed.ToString ("#,##0.") + "</color>";	


	}

	protected void updateValues()
	{
		// What am I updating here? I guess the score and shit.
	}


	public bool IsGameOver()
	{	
		if (GameManager.Instance.Cure == 100) 
		{
			return true;
			GameManager.Instance.gameOver(true);
		}
		if (GameManager.Instance.worldPopulation == 0) 
		{
			return true;
			GameManager.Instance.gameOver(true);
		}
		if (GameManager.Instance.Stability == 0) 
		{
			return true;
			GameManager.Instance.gameOver(true);
		}
		return false;
	}

}
	
using UnityEngine;
using System.Collections;

public class pandemicManager : MonoBehaviour {

	// Access pandemicManager script.
	private static pandemicManager _instance;

	// Return instance.
	public static pandemicManager Instance
	{
		get
		{
			if (_instance == null) 
			{
				GameObject pm = new GameObject ("Pandemic Manager");
				pm.AddComponent<pandemicManager> ();
			}
		
			return _instance;
		}
	}

	// Pandemic Values

	// Need a base infectivity value.
	// For starting country, can just track a bool in dictionary.

	void Awake()
	{
		_instance = this;
	}

	void Start()
	{
	}


	void Update()
	{
	}


}


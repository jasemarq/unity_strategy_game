using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Just a note to self. Canada still has issues..
public class playerManager : MonoBehaviour
	{

	void Start()
	{
	}

	void Update()
	{
	}
		
	public void physicianDeploy()
	{
		// If phyPresent false & epiPresent false
		if (GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent == false &&
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent == false) {
			GameObject.Find (GameManager.Instance.selectedCountry).GetComponent<SpriteRenderer> ().enabled = true;
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent = true;
			Debug.Log (GameManager.Instance.selectedCountry);
			Debug.Log (GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent);
		} else

		// if phyPresent false & epiPresent true
		if (GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent != true &&
		    GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent == true) {
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent = true;
		} else

		// if phyPresent true & epiPresent false
		if (GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent == true &&
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent == false) {
			GameObject.Find (GameManager.Instance.selectedCountry).GetComponent<SpriteRenderer> ().enabled = false;
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent = false;
			Debug.Log (GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent);
		} else

		// if phyPresent true & epiPresent true
		if (GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent == true &&
		    GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent == true) {
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent = false;
		}
	}

	public void epidemiologistDeploy()
	{
		// If phyPresent false & epiPresent false set epiPresent to TRUE and ... need some functions for epi here.
		// Need to determine how to incorporate those formulas given the infectivity value.
		if (GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent != true &&
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent != true) {
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent = true;
			GameObject.Find (GameManager.Instance.selectedCountry).GetComponent<SpriteRenderer> ().enabled = true;

			// GameManager.Instance.Country[GameManger.Instance.selectedCountry].baseResistance =+ // Some value here.

		} else

		// if phyPresent false & epiPresent true
		if (GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent != true &&
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent == true) {
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent = true;
			} else

		// if phyPresent true & epiPresent false
		if (GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent == true &&
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent != true) {
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent = false;
			GameObject.Find (GameManager.Instance.selectedCountry).GetComponent<SpriteRenderer> ().enabled = false;
				} else

		// if phyPresent true & epiPresent true
		if (GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent == true &&
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].phyPresent == true) {
			GameManager.Instance.Country [GameManager.Instance.selectedCountry].epiPresent = false;
		}
	}

	public void physicianEffectiveness()
	{
	}

	public void epidemiologistEffectiveness()
	{
	}



}

	
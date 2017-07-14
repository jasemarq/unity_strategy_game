using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class colorMapping {

	Texture2D txr;
	float pixUVx;
	float pixUVy;

	// Can add that value now I imagine.
	// This can go on that texture and return the associated color on the GameObject, then look it up.
	public string colorIDMatch(float[] UV)
	{
		pixUVx = UV [0];
		pixUVy = UV [1];
		GameObject rgb = GameObject.Find("LookupMap");
		txr = rgb.GetComponent<Renderer>().material.mainTexture as Texture2D;
		Color color = txr.GetPixel (System.Convert.ToInt16 (pixUVx), System.Convert.ToInt16 (pixUVy));

		string r = System.Math.Floor (color.r*255).ToString();
		string g = System.Math.Floor (color.g*255).ToString();
		string b = System.Math.Floor (color.b*255).ToString();

		string colorMap = "R" + r + "G" + g + "B" + b;
		//Debug.Log (colorMap);
		return colorMap;
	}
}

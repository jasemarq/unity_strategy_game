using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public static Rotation plane;
	public Vector3 pos;

	// Use this for initialization
	void Start () 
	{
		plane = GetComponent<Rotation> ();
		Vector3 pos = new Vector3(90, -180, plane.transform.position.z);
		plane.transform.eulerAngles = pos;
	}
	
	// Update is called once per frame
	void Update () {

	/*	if (plane.transform.eulerAngles != pos)
		{
			plane = GetComponent<Rotation> ();
			Vector3 pos = new Vector3(90, -180, plane.transform.position.z);
			plane.transform.eulerAngles = pos;
		} */

		//plane = GetComponent<Rotation> ();
		//Rotation plane = GetComponent<Rotation> ();
		//plane.transform.Rotate (-0.01981f, 0, 0);
		//Debug.Log(plane.transform.eulerAngles.x + " " + plane.transform.eulerAngles.y + " " + plane.transform.eulerAngles.z);
	}
}

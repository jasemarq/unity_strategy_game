using UnityEngine;
using System.Collections;

public class getUVCoords {

	Texture2D tx;
	float[] UV = new float[2] {0,0};
	// Vector3 fingerPos = new Vector3();
	Ray toMouse;

	public float[] UVCoordinates()
	{	
		//if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		//{

		//	Touch touch = Input.touches[0];
			//toMouse = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			GameObject uv = GameObject.FindWithTag ("Plane");
			RaycastHit rhInfo;
			toMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
			//toMouse = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
		//	Vector3 pos = toMouse;
		//	Vector3 realWorldPos = Camera.main.ScreenToWorldPoint(pos);
			//Debug.Log (toMouse);

			bool didHit = Physics.Raycast (toMouse, out rhInfo, 800.0f);

			if (didHit) {
				//tx = uv.GetComponent<Renderer> ().material.mainTexture as Texture2D;
				tx = uv.GetComponent<Renderer> ().material.mainTexture as Texture2D;
				//tx = gameObject.GetComponent<Renderer> ().material.mainTexture as Texture2D;
				Vector2 pixelUV = rhInfo.textureCoord;
				pixelUV.x *= tx.width;
				pixelUV.y *= tx.height;
				UV [0] = pixelUV.x;
				UV [1] = pixelUV.y;

				//Debug.Log (UV [0]+","+UV[1]);
				return UV;
			}
		//}	
			return UV;
	
	}
}


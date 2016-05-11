using UnityEngine;
using System.Collections;

public class Platforms : MonoBehaviour {
	public int xMax = 25, xMin = 15, yMax = 10, yMin = 5;
	private Vector3 lastPoint = new Vector3(0, 1, 0);
	private System.Random rand;
	
	// Use this for initialization
	void Start () {
		rand = new System.Random();
		for (int i = 0; i < 100; ++i)
		{
			Vector3 nextPoint = GenerateNewPoint();
			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
			Vector3 between = nextPoint - lastPoint;
            go.tag = "Ground";
			go.transform.localScale = new Vector3(1, 1, between.magnitude);
			go.transform.position = lastPoint + (between/2);
			go.transform.LookAt(nextPoint);
			lastPoint = nextPoint;
		}
	}
	
	Vector3 GenerateNewPoint()
	{
		float z = 0;
		float x = lastPoint.x + rand.Next(xMin, xMax);
		float y = lastPoint.y - rand.Next(yMin, yMax);
		return new Vector3(x, y, z);
	} 	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMetrics : MonoBehaviour {
	
	public const float outerRadius = 10f;

	public const float innerRadius = outerRadius * 0.866025404f;

	// Use this for initialization
	void Start () {
		
		
		
	}
	
	public static Vector3[] corners = {
		new Vector3(0f, 0f, outerRadius),
		new Vector3(innerRadius, 0f, 0.5f * outerRadius),
		new Vector3(innerRadius, 0f, -0.5f * outerRadius),
		new Vector3(0f, 0f, -outerRadius),
		new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
		new Vector3(-innerRadius, 0f, 0.5f * outerRadius)
	};
	
	// Update is called once per frame
	void Update () {
		
	}
}

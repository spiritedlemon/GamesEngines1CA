﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateTerrain : MonoBehaviour {

	int heightScale = 5;
	float detailScale = 5.0f;
	List<GameObject> myTrees = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		Mesh mesh = this.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		for(int v = 0; v < vertices.Length; v++)
		{
			vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x)/detailScale,
				                              (vertices[v].z + this.transform.position.z)/detailScale)*heightScale;

			if(vertices[v].y > 2.7 && Mathf.PerlinNoise((vertices[v].x+5)/10,(vertices[v].z+5)/10)*10 > 4.8)
			{
				GameObject newTree = TreePool.getTree();
				if(newTree != null)
				{
					Vector3 treePos = new Vector3(vertices[v].x + this.transform.position.x,
												  vertices[v].y - 0.5f,
												  vertices[v].z + this.transform.position.z);
					newTree.transform.position = treePos;
					newTree.SetActive(true);
					myTrees.Add(newTree);

				}
			}
			
			//if(vertices[v].y < 0.3 && Mathf.PerlinNoise((vertices[v].x+5)/10,(vertices[v].z+5)/10)*10 > 4.6)
			//{
				
				
			//}

		}

		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		this.gameObject.AddComponent<MeshCollider>();

	}

	void OnDestroy()
	{
		for(int i = 0; i < myTrees.Count; i++)
		{
			if(myTrees[i] != null)
				myTrees[i].SetActive(false);
		}
		myTrees.Clear();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

//Adapted from tutorial available at: https://www.youtube.com/watch?v=uDMfVMKM_98&list=WL&index=2&t=749s
//Used to limit number of trees and list types for selection
public class TreePool : MonoBehaviour {

	static int numTrees = 1000;
	public GameObject treePrefab;
	public GameObject treePrefab1;
	public GameObject treePrefab2;
	public GameObject treePrefab3;
	static GameObject[] trees;

	// Use this for initialization
	void Start () {
		int rand = 0;
	
		trees = new GameObject[numTrees];
		for(int i = 0; i < numTrees; i++)
		{
			rand = Random.Range(0,4); //Meaning 0, 1, 2 & 3 can be chosen
			Debug.Log(rand);
			switch(rand)
			{
				default:
					trees[i] = (GameObject) Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
					trees[i].SetActive(false);
					break;
				
				case 1:
					trees[i] = (GameObject) Instantiate(treePrefab1, Vector3.zero, Quaternion.identity);
					trees[i].SetActive(false);
					break;
				
				case 2:
					trees[i] = (GameObject) Instantiate(treePrefab2, Vector3.zero, Quaternion.identity);
					trees[i].SetActive(false);
					break;
				
				case 3:
					trees[i] = (GameObject) Instantiate(treePrefab3, Vector3.zero, Quaternion.identity);
					trees[i].SetActive(false);
					break;

			}
		}

	}
	
	
	static public GameObject getTree()
	{
		for(int i = 0; i < numTrees; i++)
		{
			if(!trees[i].activeSelf)
			{
				return trees[i];
			}
		}
		return null;
	}

	// Update is called once per frame
	void Update () {
	
	}
}

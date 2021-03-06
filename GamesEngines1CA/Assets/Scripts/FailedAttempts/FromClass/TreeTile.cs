﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTile : MonoBehaviour {
	
	
	public int quadsPerTile = 10;

    //public Material meshMaterial;

    public float amplitude = 50;

    Mesh m;

    private delegate float SampleCell(float x, float y);
	
	SampleCell[] sampleCell = 
	{
               new SampleCell(SampleCell3)
    };

    public int whichSampler = 0;

	//Vector2 offset;
	// Use this for initialization
	void Awake () {
		
		//GameObject tree = GameObject.Find("Tree1"); //Find tree game object
		//int treeCount = 0;
		
        //offset = Random.insideUnitCircle * Random.Range(0, 1000); 
        //MeshFilter mf = gameObject.AddComponent<MeshFilter>(); // Container for the mesh
        //MeshRenderer mr = gameObject.AddComponent<MeshRenderer>(); // Draw
        //MeshCollider mc = gameObject.AddComponent<MeshCollider>();
        //m = mf.mesh;

        int verticesPerQuad = 4;
        Vector3[] vertices = new Vector3[verticesPerQuad * quadsPerTile * quadsPerTile];
        Vector2[] uv = new Vector2[verticesPerQuad * quadsPerTile * quadsPerTile];

        int vertexTriangesPerQuad = 6;
        int[] triangles = new int[vertexTriangesPerQuad * quadsPerTile * quadsPerTile];

        Vector3 bottomLeft = new Vector3(-quadsPerTile / 2, 0, -quadsPerTile / 2);
        int vertex = 0;
        int triangleVertex = 0;
        float minY = float.MaxValue;
        float maxY = float.MinValue;
        for (int row = 0; row < quadsPerTile; row++)
        {
            for (int col = 0; col < quadsPerTile; col++)
            {
                Vector3 bl = bottomLeft + new Vector3(col, sampleCell[whichSampler](transform.position.x + col, transform.position.z + row), row);
                Vector3 tl = bottomLeft + new Vector3(col, sampleCell[whichSampler](transform.position.x + col, transform.position.z + row + 1), row + 1);
                Vector3 tr = bottomLeft + new Vector3(col + 1, sampleCell[whichSampler](transform.position.x + col + 1, transform.position.z + row + 1), row + 1);
                Vector3 br = bottomLeft + new Vector3(col + 1, sampleCell[whichSampler](transform.position.x + col + 1, transform.position.z + row), row);

                int startVertex = vertex;
                vertices[vertex++] = bl;
                vertices[vertex++] = tl;
                vertices[vertex++] = tr;
                vertices[vertex++] = br;
                               

                vertex = startVertex;
                float fNumQuads = quadsPerTile;
                uv[vertex++] = new Vector2(col / fNumQuads, row / fNumQuads);
                uv[vertex++] = new Vector2(col / fNumQuads, (row + 1) / fNumQuads);
                uv[vertex++] = new Vector2((col + 1) / fNumQuads, (row + 1) / fNumQuads);
                uv[vertex++] = new Vector2((col + 1) / fNumQuads, row / fNumQuads);

                triangles[triangleVertex++] = startVertex;
                triangles[triangleVertex++] = startVertex + 1;
                triangles[triangleVertex++] = startVertex + 3;
                triangles[triangleVertex++] = startVertex + 3;
                triangles[triangleVertex++] = startVertex + 1;
                triangles[triangleVertex++] = startVertex + 2;

                if (bl.y > maxY)
                {
                    maxY = bl.y;
                }
                if (bl.y < minY)
                {
                    minY = bl.y;
                }
				
				
            }
        }
		
		//m.vertices = vertices;
        //m.uv = uv;
        //m.triangles = triangles;        
        //m.RecalculateNormals();
        //mr.material = meshMaterial;
        //mc.sharedMesh = m;
        //mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        //mr.receiveShadows = true;
		
	}
	
	public static float SampleCell3(float x, float y)
    {
        float flatness = 0.2f;
        float noise = Mathf.PerlinNoise(10000 + x / 100, 10000 + y / 100);
        if (noise > 0.5f + flatness)
        {
            noise = noise - flatness;
        }
        else if (noise < 0.5f - flatness)
        {
            noise = noise + flatness;
        }
        else
        {
            noise = 0.5f;
			
        }
        
        return (noise * 300) + (Mathf.PerlinNoise(1000 + x / 5, 100 + y / 5) * 2);
    }
	
	public static float Map(float value, float r1, float r2, float m1, float m2)
    {
        float dist = value - r1;
        float range1 = r2 - r1;
        float range2 = m2 - m1;
        return m1 + ((dist / range1) * range2);
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}
}

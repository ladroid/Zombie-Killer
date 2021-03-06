﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    int heightScale = 5;
    float detailScale = 5.0f;
    //public GameObject tree;
    List<GameObject> myTrees = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
		{
            vertices[i].y = Mathf.PerlinNoise((vertices[i].x + transform.position.x) / detailScale,
                                              (vertices[i].z + transform.position.z) / detailScale) * heightScale;

            if(vertices[i].y > 2.6 && Mathf.PerlinNoise((vertices[i].x + 5) / 10, (vertices[i].z+5)/10)*10 > 4.6)
            {
                GameObject newTree = TreePool.getTree();
                if(newTree != null)
                {
                    Vector3 treePos = new Vector3(vertices[i].x + this.transform.position.x, vertices[i].y,
                                              vertices[i].z + this.transform.position.z);
                    newTree.transform.position = treePos;
                    newTree.SetActive(true);
                    myTrees.Add(newTree);
                }
            }
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
            if (myTrees[i] != null)
            {
                myTrees[i].SetActive(false);
            }
        }
        myTrees.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

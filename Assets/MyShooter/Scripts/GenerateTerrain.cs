using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    int heightScale = 5;
    float detailScale = 5.0f;
    public GameObject tree;


    //TODO: DELETE TREES
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
		{
            vertices[i].y = Mathf.PerlinNoise((vertices[i].x + transform.position.x) / detailScale,
                                              (vertices[i].z + transform.position.z) / detailScale) * heightScale;

            if(vertices[i].y > 3.4)
            {
                Vector3 treePos = new Vector3(vertices[i].x + this.transform.position.x, vertices[i].y,
                                              vertices[i].z + this.transform.position.z);

                Instantiate(tree, treePos, Quaternion.identity);
            }
		}
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.gameObject.AddComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

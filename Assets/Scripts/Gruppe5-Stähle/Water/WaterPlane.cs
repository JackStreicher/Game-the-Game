using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlane : MonoBehaviour
{
    public float size = 1;
    public int gridSize = 16;

    private MeshFilter filter;

    void Start()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
    }

    private Mesh GenerateMesh()
    {
        Mesh m = new Mesh();
        var vertices = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>();

        for(int i = 0; i < gridSize + 1; i++)
        {
            for(int j = 0; j < gridSize + 1; j++)
            {
                vertices.Add(new Vector3(-size * 0.5f + size * (i / ((float)gridSize)), 0, -size * 0.5f + size * (j / ((float)gridSize))));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(i / (float)gridSize, j / (float)gridSize));
            }
        }

        var triangles = new List<int>();
        var vertCount = gridSize + 1;
        for(int i = 0; i < vertCount * vertCount - vertCount; i++)
        {
            if ((i + 1) % vertCount == 0)
            {
                continue;
            }
            triangles.AddRange(new List<int>() { i + 1 + vertCount, i + vertCount, i, i, i + 1, i + vertCount + 1 });

        }            
        m.SetVertices(vertices);
        m.SetNormals(normals);
        m.SetUVs(0, uvs);
        m.SetTriangles(triangles, 0);
        return m;
    }
}

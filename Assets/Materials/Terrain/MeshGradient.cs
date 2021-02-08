using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGradient : MonoBehaviour
{
    Mesh mesh;
    Vector2[] uvs;
    

    public Gradient gradient;

    
    float minTerrainHeight = 0;
    
    float maxTerrainHeight = 0;

    //public bool update;


    public void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        UpdateMesh();

       
    }


   //public void Update()
   //{
   //    if (update)
   //    {
   //        UpdateMesh();
   //        update = false;
   //    }
   //}

    public void UpdateMesh()
    {
        for (int i = 0; i < mesh.vertexCount; i++)
        {

            if (mesh.vertices[i].y > maxTerrainHeight)
            {
                maxTerrainHeight = mesh.vertices[i].y;
            }
            if (mesh.vertices[i].y < minTerrainHeight)
            {
                minTerrainHeight = mesh.vertices[i].y;
            }

        }



        for (int i= 0; i< mesh.vertexCount; i++)
        {
            float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight,mesh.vertices[i].y);
            mesh.colors[i] = gradient.Evaluate(height);

            if (mesh.vertices[i].y > maxTerrainHeight)
            {
                maxTerrainHeight = mesh.vertices[i].y;
            }
            if (mesh.vertices[i].y < minTerrainHeight)
            {
                minTerrainHeight = mesh.vertices[i].y;
            }

        }
      
       // xSize = mesh.
       //
       // uvs = new Vector2[mesh.vertices.Length];
       //
       // for (int i = 0; i< )
       // {
       //
       // }

    }

}

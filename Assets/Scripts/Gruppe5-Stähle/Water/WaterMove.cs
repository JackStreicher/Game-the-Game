using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public float power = 3;
    public float scale = 1;
    public float timeScale = 1;

    private float offsetX;
    private float offsetY;
    private MeshFilter mf;
    void Start()
    {
        mf = GetComponent<MeshFilter>();
        MoveWater();
    }

    void FixedUpdate()
    {
        MoveWater();
        offsetX += Time.deltaTime * timeScale; //Der Spieler kann kontrollieren wie schnell sich das Wasser bewegt
        offsetY += Time.deltaTime * timeScale; //Der Spieler kann kontrollieren wie schnell sich das Wasser bewegt
    }

    void MoveWater()
    {
        Vector3[] vertices = mf.mesh.vertices;

        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z) * power; // verändert die position auf der y achse aller vertices
        }

        mf.mesh.vertices = vertices; // "Updated" die vertices
    }

    float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + offsetX;
        float yCord = y * scale + offsetY;

        return Mathf.PerlinNoise(xCord, yCord); //gibt einen random float wert zurück
    }
}

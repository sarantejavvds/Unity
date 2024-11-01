using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone_3D : MonoBehaviour
{
    Mesh mesh;

    MeshRenderer meshRenderer;

    // Triangular vertices
    List<Vector3> vertices;

    List<int> triangles;

    public Material material;

    public float Height = 3.0f;

    public float Radius = 5.0f;

    public int Segments = 7;

    Vector3 pos;

    float angle = 0.0f;

    float angle_Amount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.AddComponent<MeshFilter>();

        meshRenderer = gameObject.AddComponent<MeshRenderer>();

        meshRenderer.material = material;

        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new List<Vector3>();

        pos = new Vector3();

        angle_Amount = 2 * Mathf.PI / Segments;

        angle = 0.0f;


        pos.x = 0.0f;

        pos.y = Height;

        pos.z = 0.0f;

        vertices.Add(new Vector3(pos.x, pos.y, pos.z));


        pos.y = 0.0f;

        vertices.Add(new Vector3(pos.x, pos.y, pos.z));


        for(int i = 0 ; i < Segments ; i++)
        {
            pos.x = Radius * Mathf.Sin(angle);

            pos.z = Radius * Mathf.Cos(angle);

            vertices.Add(new Vector3(pos.x, pos.y, pos.z));

            angle -= angle_Amount;
        }

        mesh.vertices = vertices.ToArray();

        triangles = new List<int>();

        for(int i = 2 ; i < Segments + 1 ; i++)
        {
            triangles.Add(0);

            triangles.Add(i + 1);

            triangles.Add(i);

        }

        triangles.Add(0);

        triangles.Add(2);

        triangles.Add(Segments + 1);

        

        for (int i = 2; i < Segments + 1; i++)
        {
            triangles.Add(0);

            triangles.Add(i);

            triangles.Add(i + 1);

        }


        triangles.Add(1);

        triangles.Add(Segments + 1);

        triangles.Add(2);


        mesh.triangles = triangles.ToArray();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

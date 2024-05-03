using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StaticMesh))]
public class StaticMeshEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        StaticMesh script = (StaticMesh)target;

        if (GUILayout.Button("Generate Mesh"))
        {
            script.GenerateMesh();
        }
    }
}

public class StaticMesh : MonoBehaviour
{
    public Material material;

    Vector3 GetNormal(Vector3 v1, Vector3 v2)
    {
        Vector3 result = Vector3.Normalize(Vector3.Cross(v1, v2)); //Vector3.Normalize(v1), Vector3.Normalize(v2) 
        return result;
    }

    Vector3 GetVector(Vector3 v1, Vector3 v2)
    {
        return v1 - v2;
    }

    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            //����
            new Vector3(0.0f,0, 1.0f), //0
            new Vector3(1.0f,0, -0.55f), //1
            new Vector3(-1.0f,0, -0.55f),//2

            new Vector3(-1.0f,0, 0.55f),//3
            new Vector3(1.0f,0, 0.55f),//4
            new Vector3(0.0f,0, -1.0f),//5

            //�Ʒ���
            new Vector3(0.0f,-0.5f, 1.0f),//6
            new Vector3(1.0f,-0.5f, -0.55f),//7
            new Vector3(-1.0f,-0.5f, -0.55f),//8

            new Vector3(-1.0f,-0.5f, 0.55f),//9
            new Vector3(1.0f,-0.5f, 0.55f),//10
            new Vector3(0.0f,-0.5f, -1.0f),//11
        };
        mesh.vertices = vertices;

        int[] triangleIndices = new int[]
        {
            0,1,2,
            3,4,5,
            6,8,7,
            9,11,10,
            1,8,2,
            1,7,8,
            1,0,7,
            7,0,6,
            0,2,8,
            0,8,6,
            3,5,11,
            3,11,9,
            5,4,10,
            5,10,11,
            4,3,9,
            4,9,10
        };
        mesh.triangles = triangleIndices;

        Vector3[] normals = new Vector3[]
        {
            Vector3.Normalize(GetNormal(vertices[0] - vertices[1], vertices[0] - vertices[2]) + GetNormal(vertices[0] - vertices[6], vertices[0] - vertices[1]) + GetNormal(vertices[0] - vertices[2], vertices[0] - vertices[6])),
            Vector3.Normalize(GetNormal(vertices[1] - vertices[2], vertices[1] - vertices[0]) + GetNormal(vertices[1] - vertices[7], vertices[1] - vertices[2]) + GetNormal(vertices[1] - vertices[0], vertices[1] - vertices[7])),
            Vector3.Normalize(GetNormal(vertices[2] - vertices[0], vertices[2] - vertices[1]) + GetNormal(vertices[2] - vertices[8], vertices[2] - vertices[0]) + GetNormal(vertices[2] - vertices[1], vertices[2] - vertices[8])),

            Vector3.Normalize(GetNormal(vertices[3] - vertices[4], vertices[3] - vertices[5]) + GetNormal(vertices[3] - vertices[9], vertices[3] - vertices[4]) + GetNormal(vertices[3] - vertices[5], vertices[3] - vertices[9])),
            Vector3.Normalize(GetNormal(vertices[4] - vertices[5], vertices[4] - vertices[3]) + GetNormal(vertices[4] - vertices[10], vertices[4] - vertices[5]) + GetNormal(vertices[4] - vertices[3], vertices[4] - vertices[10])),
            Vector3.Normalize(GetNormal(vertices[5] - vertices[3], vertices[5] - vertices[4]) + GetNormal(vertices[5] - vertices[11], vertices[5] - vertices[3]) + GetNormal(vertices[5] - vertices[4], vertices[5] - vertices[11])),


            Vector3.Normalize(GetNormal(vertices[6] - vertices[8], vertices[6] - vertices[7]) + GetNormal(vertices[6] - vertices[0], vertices[6] - vertices[8]) + GetNormal(vertices[6] - vertices[7], vertices[6] - vertices[0])),
            Vector3.Normalize(GetNormal(vertices[7] - vertices[6], vertices[7] - vertices[8]) + GetNormal(vertices[7] - vertices[8], vertices[7] - vertices[1]) + GetNormal(vertices[7] - vertices[1], vertices[7] - vertices[6])),
            Vector3.Normalize(GetNormal(vertices[8] - vertices[7], vertices[8] - vertices[6]) + GetNormal(vertices[8] - vertices[6], vertices[8] - vertices[2]) + GetNormal(vertices[8] - vertices[2], vertices[8] - vertices[7])),

            Vector3.Normalize(GetNormal(vertices[9] - vertices[11], vertices[9] - vertices[10]) + GetNormal(vertices[9] - vertices[3], vertices[9] - vertices[11]) + GetNormal(vertices[9] - vertices[10], vertices[9] - vertices[3])),
            Vector3.Normalize(GetNormal(vertices[10] - vertices[9], vertices[10] - vertices[11]) + GetNormal(vertices[10] - vertices[11], vertices[10] - vertices[4]) + GetNormal(vertices[10] - vertices[4], vertices[10] - vertices[9])),
            Vector3.Normalize(GetNormal(vertices[11] - vertices[10], vertices[11] - vertices[9]) + GetNormal(vertices[11] - vertices[9], vertices[11] - vertices[5]) + GetNormal(vertices[11] - vertices[5], vertices[11] - vertices[10])),
        };

        mesh.normals = normals;

        for (int i = 0; i < vertices.Length; i++)
        {
            Debug.DrawRay(transform.position + vertices[i], normals[i], Color.red);

            if (i < 6)
            {
                Debug.DrawRay(transform.position + vertices[i], GetNormal(vertices[i] - vertices[i + 1], vertices[i + 0] - vertices[i + 2]), Color.blue);
                Debug.DrawRay(transform.position + vertices[i], GetNormal(vertices[i] - vertices[i + 6], vertices[i + 0] - vertices[i + 1]), Color.blue);
                Debug.DrawRay(transform.position + vertices[i], GetNormal(vertices[i] - vertices[i + 2], vertices[i + 0] - vertices[i + 6]), Color.blue);
            }
        }

        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = mesh;

        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.material = material;
    }

    void Start()
    {
        GenerateMesh();
    }


    // Update is called once per frame
    void Update()
    {
        //GenerateMesh();
    }
}
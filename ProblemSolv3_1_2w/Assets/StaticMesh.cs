using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StaticMesh))]
public class StaticMeshEditor:Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        //if(GUILayout.Button())
    }
}

public class StaticMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.45f, -1.0f, 0.0f),
            new Vector3(-1.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(-0.45f, -1.0f, 0.0f),
            new Vector3(0.0f, 0.0f, 0.0f)
        };
        mesh.vertices = vertices;

        int[] triangleIndices = new int[]
        {
            0,1,6,
            1,2,6,
            2,3,6,
            3,4,6,
            4,5,6
        };
        mesh.triangles = triangleIndices;

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}

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
        StaticMesh script = (StaticMesh)target;

        if(GUILayout.Button("Generate Mesh"))
        {
            script.GenerateMesh();
        }
    }
}

public class StaticMesh : MonoBehaviour
{
    public Material material;

    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            //윗판
            new Vector3(0.0f,0, 1.0f), //0
            new Vector3(1.0f,0, -0.55f), //1
            new Vector3(-1.0f,0, -0.55f),//2

            new Vector3(-1.0f,0, 0.55f),//3
            new Vector3(1.0f,0, 0.55f),//4
            new Vector3(0.0f,0, -1.0f),//5

            //아래판
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

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;
        mr.material = material;

        //노멀 계산해서 메시에 던져주기
        //메시-머테리얼-쉐이더 순서로 노멀 정보를 받아오는데 별에는 지금 노멀이 없음
        //그래서 정점 정보 넘겨주는 것처럼 노멀 넘겨주기
    }

    void Start()
    {
        GenerateMesh();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}

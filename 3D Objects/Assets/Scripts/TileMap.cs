using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//scriptin bulundugu objede kotrol yapar eger yoksa gerekli componentleri ekler
[RequireComponent (typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshCollider))]
public class TileMap : MonoBehaviour
{

    int size_x = 100;
    int size_z = 100;

    void Start()
    {
        BuildMesh();
    }


  void  BuildMesh()
    {


        Vector3[] vertices = new Vector3[4];
        int[] triangles = new int[6];
        Vector3[] normals = new Vector3[4];
        Vector2[] uv = new Vector2[4];





        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;
















        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();

        mesh_filter.mesh = mesh;
    }
}

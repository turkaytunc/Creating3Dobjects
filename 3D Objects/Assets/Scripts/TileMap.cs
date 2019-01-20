using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//scriptin bulundugu objede kotrol yapar eger yoksa gerekli componentleri ekler
[RequireComponent (typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshCollider))]
public class TileMap : MonoBehaviour
{

    int size_x = 100;//yuzeyin eni
    int size_z = 50;//yuzey boyu
    float tileSize = 1.0f;

    void Start()
    {
        BuildMesh();
    }


  void  BuildMesh()
    {
        //mesh icin gerekli verinin olusturulmasi
        int vsize_x = size_x + 1;
        int vsize_z = size_z + 1;

        int numTiles = size_x * size_z;//yuzeyi olusturacak kare sayisi
        int numTriangles = numTiles * 2;//karenin sahip oldugu ucgen sayisi
        int numVertices = vsize_x * vsize_z;//ucgenlerin olusturulmasi icin gereken nokta miktari

        Vector3[] vertices = new Vector3[numVertices];
        Vector3[] normals = new Vector3[numVertices];
        Vector2[] uv = new Vector2[numVertices];

        int[] triangles = new int[numTriangles * 3];


        //uzaydaki noktalarin koordinatlarinin vektorler ile belirlenmesi ve normal vektorleri ile materyal kaplamasinin nasil olacaginin belirlenmesi
        int x, z;

        for (z = 0; z < vsize_z; z++)//yuzeyin boyunun donguye alinmasi
        {
            for (x = 0; x < vsize_x; x++)//yuzeyin genisliginin donguye alinmasi
            {
                vertices[z * vsize_x + x] = new Vector3(x * tileSize, 0, z * tileSize);
                normals[z * vsize_x + x] = new Vector3(0, 1, 0);
                uv[z * vsize_x + x] = new Vector2((float)x / size_x, (float)z / size_z);
            }
        }

        //yuzeyin sahip olmasi gereken ucgen sayisinin belirlenmesi

        for (z = 0; z < size_z; z++)
        {
            for (x = 0; x < size_x; x++)
            {
                int squareIndex = z * size_x + x;
                int trianglesOffset = squareIndex * 6;

                triangles[trianglesOffset + 0] = z * vsize_x + x +           0;
                triangles[trianglesOffset + 2] = z * vsize_x + x + vsize_x + 1;
                triangles[trianglesOffset + 1] = z * vsize_x + x + vsize_x + 0;

                triangles[trianglesOffset + 3] = z * vsize_x + x +           0;
                triangles[trianglesOffset + 5] = z * vsize_x + x +           1;
                triangles[trianglesOffset + 4] = z * vsize_x + x + vsize_x + 1;
            }

        }

        //olusturdugumuz veri kullanilarak yeni mesh olusturulmasi
        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;


        //obje uzerindeki componentlerin degiskene atanmasi
        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();

        //objenin mesh'inin degistirilmesi
        mesh_filter.mesh = mesh;
    }
}

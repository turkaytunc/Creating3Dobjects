using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileMap))]
[System.Serializable]
public  class TileMapInspector : Editor
{

    float p;
    



    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        

        if (GUILayout.Button("Yuzey Olustur"))
        {
           TileMap tileMap = (TileMap)target;

           tileMap.BuildMesh();

        }
    }
}

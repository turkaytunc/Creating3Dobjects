using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TileMap))]
public class TileMouseOver : MonoBehaviour
{
    TileMap tileMap;
    Vector3 currentCoordinates;
    public GameObject selectionCube;
    float parca = 1.0f;


    private void Start()
    {
        tileMap = GetComponent<TileMap>();
       

    }


    void Update()
    {
        // ray yollayip bir collider a carpip carpmadigi kontrol ediyor
        // eger collision varsa  mouse'un bulundugu noktaya secim kubunu yolluyor.

        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit myRaycastHit;
        Physics.Raycast(myRay, out myRaycastHit, Mathf.Infinity);
        Collider col = myRaycastHit.collider;


        if (myRaycastHit.collider)
        {
            int x = Mathf.FloorToInt(myRaycastHit.point.x / tileMap.parcaBoyutu);
            int z = Mathf.FloorToInt(myRaycastHit.point.z / tileMap.parcaBoyutu);
            currentCoordinates.x = x;
            currentCoordinates.z = z;

            Debug.Log("tile " + x + " + " + z);
            selectionCube.transform.position = currentCoordinates * tileMap.parcaBoyutu;

            //parca boyutuna gore secim kubunun boyutunu ayarlar
            if (parca != tileMap.parcaBoyutu)
            {
                Vector3 selectionVector = selectionCube.transform.localScale;
                selectionCube.transform.localScale = new Vector3(tileMap.parcaBoyutu, 1, tileMap.parcaBoyutu) ;
            }
            else
            {
                parca = tileMap.parcaBoyutu;
            }

        }
        
        // eger mouse sol tusuna basilirsa bulundugu noktaya secili oyun objesi instatiate edilecek
        // henuz yapim asamasinda
        if (Input.GetMouseButtonDown(0))
        {

        }


   

    }

   
}

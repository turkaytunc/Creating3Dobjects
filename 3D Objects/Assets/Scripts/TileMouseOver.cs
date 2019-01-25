﻿using UnityEngine;

[RequireComponent(typeof(TileMap))]
public class TileMouseOver : MonoBehaviour
{
    TileMap tileMap;
    Vector3 currentCoordinates;
    Vector3 towerTransformVector;

    float parca = 1.0f;
    const int towerLimit = 10;
    int towerCount = 0;
    bool isTower = false;


    public GameObject selectionCube;
    public GameObject tower;



  



    private void Start()
    {
        tileMap = GetComponent<TileMap>();
        towerTransformVector = new Vector3();
       



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
            towerTransformVector = selectionCube.transform.position;
            isTower = false;
            if(!(towerCount >= towerLimit) && myRaycastHit.collider != null)
            {
                if (isTower == false && !col.CompareTag("Tower"))
                {
                    Instantiate(tower, towerTransformVector, Quaternion.identity);
                    isTower = true;
                    towerCount += 1;
                }

            }
            else if(towerCount >= towerLimit)
            {
                Debug.Log("maximum tower dikme limiti asildi!!");
            }


        }


           


    }

   
}

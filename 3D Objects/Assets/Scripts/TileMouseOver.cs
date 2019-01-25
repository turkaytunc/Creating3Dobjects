using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(TileMap))]
public class TileMouseOver : MonoBehaviour
{
    TileMap tileMap;
    Vector3 currentCoordinates;
    Vector3 towerTransformVector;
    List<Vector3> towerTransformList;

    float parca = 1.0f;
    const int towerLimit = 10;
    int towerCount = 0;
    bool isTower = false;
    bool canBuild = false;



    public GameObject selectionCube;
    public GameObject tower;
    

    private void Start()
    {
        tileMap = GetComponent<TileMap>();
        towerTransformVector = new Vector3();
        towerTransformList = new List<Vector3>(towerLimit);


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
            //boylece gorsel olarak problem cikmasi engellenir.
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

        //mouse ile tiklanan noktada tower objesi olusturuluyor
        //yeni tower tipleri eklendikce guncellenmeli
        //tower dikme ya da o noktada bulundan tower'i yok etme ozelligi eklenecek
        // henuz yapim asamasinda
        if (Input.GetMouseButtonDown(0))
        {
            towerTransformVector = selectionCube.transform.position;

            isTower = false;
            canBuild = TowerTransformList(towerTransformVector);

            if(!(towerCount >= towerLimit))
            {
                if (isTower == false && canBuild)
                {
                    Instantiate(tower, towerTransformVector, Quaternion.identity);
                    isTower = true;
                    canBuild = false;
                    towerCount += 1;
                }

            }
            else if(towerCount >= towerLimit)
            {
                Debug.Log("maximum tower dikme limiti asildi!!");
            }


        }


    }


    //mouse ile tiklanan yerin koordinatini alip , daha once tiklanan noktalarla benzerligini kontrol ediyor
    //eger daha once ayni noktaya tower dikilmis ise tower dikmeyi engelliyor
    //aksi halde o noktaya tower dikilebilir deyip, koordinati listeye ekliyor.
    bool TowerTransformList(Vector3 trans)
    {
        
       
        foreach (Vector3 tr in towerTransformList)
        {
            if (trans == tr)
            {
                return false;
            }

        }

        towerTransformList.Add(towerTransformVector);
        return true;

    }

   
}

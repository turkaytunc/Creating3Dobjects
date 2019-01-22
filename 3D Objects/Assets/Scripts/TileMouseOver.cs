using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TileMap))]
public class TileMouseOver : MonoBehaviour
{
    TileMap tileMap;
    Vector3 currentCoordinates;
    public GameObject selectedUnit;

    private void Start()
    {
        tileMap = GetComponent<TileMap>();
    }

    void Update()
    {


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

        }

        if (Input.GetMouseButtonDown(0))
        {
            selectedUnit.transform.position = currentCoordinates*2f;

        }


   

    }

   
}

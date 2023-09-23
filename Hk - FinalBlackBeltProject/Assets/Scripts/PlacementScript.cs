using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlacementScript : MonoBehaviour
{
    [Header("Towers Selected")]
    public GameObject Tower1;
    public GameObject Tower2;
    public GameObject Tower3;
    private GameObject TowerSelectedForPlacement;
    bool TowerPlaced = false;

    [Header("Mouse Position")]
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, 0);

    [Header("Tower Upgrade And Upgrade UI")]
    public GameObject UpgradeCanvas;
    public GameObject selectedObject;
    public GameObject highlightedObject;
    public LayerMask selectableLayer;
    RaycastHit hitData;
    public TowerAttributes towerAttributes; 

    // Start is called before the first frame update
    void Start()
    {
        TowerPlaced = false;

        UpgradeCanvas.SetActive(false);

        towerAttributes = towerAttributes.GetComponent<TowerAttributes>(); 
    }

    void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        Vector3 WorldPosition = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);

        if (worldPosition.x > -60 && worldPosition.x < -3)
        {
            if (TowerPlaced && Input.GetMouseButtonDown(0))
            {
                Instantiate(TowerSelectedForPlacement, WorldPosition, Quaternion.identity);
                TowerPlaced = false;
            }
        }

        if (Physics.Raycast(ray, out hitData, 1000, selectableLayer))
        {
            highlightedObject = hitData.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                selectedObject = hitData.transform.gameObject;
                UpgradeCanvas.SetActive(true); 
            }
        }
        else
        {
            highlightedObject = null;
            if (Input.GetMouseButtonDown(0))
            {
                selectedObject = null;
                UpgradeCanvas.SetActive(false); 
            }
        }
    }

    public void ButtonPressed()
    {
        TowerPlaced = true; 
        if (TowerPlaced && towerAttributes.MoneyAmount >= 100)
        {
            TowerSelectedForPlacement = Tower1;
            towerAttributes.MoneyAmount -= 100; 
        } else
        {
            TowerPlaced = false; 
        }
    }


}

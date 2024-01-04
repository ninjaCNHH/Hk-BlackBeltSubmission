using System;
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
    private GameObject TowerSelectedForPlacement;
    bool TowerPlaced = false;
    public GameObject ClonedTower; 

    [Header("Mouse Position")]
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, 0);

    [Header("Tower Upgrade And Upgrade UI")]
    public GameObject CancelButton; 
    public GameObject UpgradeCanvas;
    public GameObject selectedObject;
    public GameObject highlightedObject;
    public LayerMask selectableLayer;
    RaycastHit hitData;
    public int MoneyAmount;
    public Text MoneyText;
    public int SellAmount;
    public Text SellPriceText;
    bool sellingTower;
    bool ButtonClicked;

    [Header("Tower Attribute Canvas")]
    private TowerAttributes CurrentTowerAttribute; 
    public Text AtkSpeedText;
    public Text AttackText;
    public Text UpgradePriceText;

    // Start is called before the first frame update
    void Start()
    {
        MoneyAmount = 1000;
        SellAmount = 50;
        sellingTower = false;
        SellPriceText.text = SellAmount.ToString();


        TowerPlaced = false;
        ButtonClicked = true; 

        CancelButton.SetActive(false); 

        UpgradeCanvas.SetActive(false);
    }

    void Update()
    {
        MoneyText.text = MoneyAmount.ToString();

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
                ClonedTower = Instantiate(TowerSelectedForPlacement, WorldPosition, Quaternion.identity);
                TowerPlaced = false;
                ButtonClicked = true; 

            }
        }

        if (Physics.Raycast(ray, out hitData, 1000, selectableLayer))
        {
            highlightedObject = hitData.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                selectedObject = hitData.transform.gameObject;
                CancelButton.SetActive(true);
                UpgradeCanvas.SetActive(true);
                CurrentTowerAttribute = selectedObject.GetComponent<TowerAttributes>();
                AttackText.text = CurrentTowerAttribute.AttackAmount.ToString();
                UpgradePriceText.text = CurrentTowerAttribute.UpgradeAmount.ToString();
                AtkSpeedText.text = CurrentTowerAttribute.TotalTime.ToString();
            }
        }
        else
        {
            highlightedObject = null;
        }

        if (selectedObject != null)
        {
            sellingTower = true;
        }
    }

    public void ButtonPressed()
    {
        TowerPlaced = true;
        if (TowerPlaced && MoneyAmount >= 100 && ButtonClicked)
        {
            TowerSelectedForPlacement = Tower1;
            MoneyAmount -= 100;
            MoneyText.text = MoneyAmount.ToString();
            ButtonClicked = false; 
        }
        else if (ButtonClicked == true)
        {
            TowerPlaced = false; 
        }
    }


    public void SellButtonPressed()
    {
        if (selectedObject.CompareTag("Towers") && sellingTower)
        {
            Destroy(selectedObject);
            UpgradeCanvas.SetActive(false);
            MoneyAmount += SellAmount;
            MoneyText.text = MoneyAmount.ToString();
            sellingTower = false;
            Debug.Log("Button Is Clicked");
            CancelButton.SetActive(false);
        }
    }

    public void CancelButtonFunction()
    {
        CancelButton.SetActive(false);
        UpgradeCanvas.SetActive(false);
        selectedObject = null;
    }

}

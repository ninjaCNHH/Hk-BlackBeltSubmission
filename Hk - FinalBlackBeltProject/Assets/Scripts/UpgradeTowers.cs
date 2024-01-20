using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UpgradeTowers : MonoBehaviour
{
    public GameObject ImportantScripts; 
    private PlacementScript placementScript;
    public GameObject CurrentSelectedObject;
    private TowerAttributes SpecificTowerAttributeOfSelectedObj;

    // Start is called before the first frame update
    void Start()
    {
        placementScript = ImportantScripts.GetComponent<PlacementScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void UpgradeButtonPressed()
    {
        CurrentSelectedObject = placementScript.selectedObject;
        SpecificTowerAttributeOfSelectedObj = CurrentSelectedObject.GetComponent<TowerAttributes>(); 

        if (placementScript.MoneyAmount > SpecificTowerAttributeOfSelectedObj.UpgradeAmount && SpecificTowerAttributeOfSelectedObj.NumberOfUpgrades <=5)
        {
            Debug.Log("functionworks");
            SpecificTowerAttributeOfSelectedObj.AttackAmount += 10;
            SpecificTowerAttributeOfSelectedObj.AttackSpeed -= 1;
            SpecificTowerAttributeOfSelectedObj.NumberOfUpgrades += 1;
            SpecificTowerAttributeOfSelectedObj.TotalTime = SpecificTowerAttributeOfSelectedObj.WaitTime + SpecificTowerAttributeOfSelectedObj.AttackSpeed; 
            placementScript.MoneyAmount -= SpecificTowerAttributeOfSelectedObj.UpgradeAmount;
            SpecificTowerAttributeOfSelectedObj.UpgradeAmount += 400;
            CurrentSelectedObject.GetComponent<Renderer>().material.color = new Color(SpecificTowerAttributeOfSelectedObj.Red -= 50,
            SpecificTowerAttributeOfSelectedObj.Green -= 50, SpecificTowerAttributeOfSelectedObj.Blue -= 50);
            placementScript.AttackText.text = SpecificTowerAttributeOfSelectedObj.AttackAmount.ToString();
            placementScript.UpgradePriceText.text = SpecificTowerAttributeOfSelectedObj.UpgradeAmount.ToString();
            placementScript.AtkSpeedText.text = SpecificTowerAttributeOfSelectedObj.TotalTime.ToString();

            if (SpecificTowerAttributeOfSelectedObj.NumberOfUpgrades == 1)
            {
                SpecificTowerAttributeOfSelectedObj.Upgrade1.SetActive(false);
                SpecificTowerAttributeOfSelectedObj.Upgrade2.SetActive(true);
                SpecificTowerAttributeOfSelectedObj.Upgrade3.SetActive(false);
                SpecificTowerAttributeOfSelectedObj.Upgrade4.SetActive(false); 
            }

            if (SpecificTowerAttributeOfSelectedObj.NumberOfUpgrades == 2)
            {
                SpecificTowerAttributeOfSelectedObj.Upgrade1.SetActive(false);
                SpecificTowerAttributeOfSelectedObj.Upgrade2.SetActive(false);
                SpecificTowerAttributeOfSelectedObj.Upgrade3.SetActive(true);
                SpecificTowerAttributeOfSelectedObj.Upgrade4.SetActive(false);
            }

            if (SpecificTowerAttributeOfSelectedObj.NumberOfUpgrades == 3)
            {
                SpecificTowerAttributeOfSelectedObj.Upgrade1.SetActive(false);
                SpecificTowerAttributeOfSelectedObj.Upgrade2.SetActive(false);
                SpecificTowerAttributeOfSelectedObj.Upgrade3.SetActive(false);
                SpecificTowerAttributeOfSelectedObj.Upgrade4.SetActive(true);
            }

        } else if (SpecificTowerAttributeOfSelectedObj.NumberOfUpgrades > 5)
        {
            Destroy(gameObject); 
        }
    }
}

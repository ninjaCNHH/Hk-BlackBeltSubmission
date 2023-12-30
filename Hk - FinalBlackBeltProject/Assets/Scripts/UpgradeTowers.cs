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

        if (placementScript.MoneyAmount > SpecificTowerAttributeOfSelectedObj.UpgradeAmount)
        {
            Debug.Log("functionworks");
            SpecificTowerAttributeOfSelectedObj.AttackAmount += 5;
            SpecificTowerAttributeOfSelectedObj.AttackSpeed -= 2;
            placementScript.MoneyAmount -= SpecificTowerAttributeOfSelectedObj.UpgradeAmount;
            SpecificTowerAttributeOfSelectedObj.UpgradeAmount += 200;
            CurrentSelectedObject.GetComponent<Renderer>().material.color = new Color(SpecificTowerAttributeOfSelectedObj.Red -= 20,
                SpecificTowerAttributeOfSelectedObj.Green -= 50, SpecificTowerAttributeOfSelectedObj.Blue -= 50);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TowerAttributes : MonoBehaviour
{
    public int MoneyAmount;
    public Text Money; 
    public int SellAmount;
    public Text SellPrice;
    public PlacementScript placementScript; 

    // Start is called before the first frame update
    void Start()
    {
        placementScript = placementScript.GetComponent<PlacementScript>(); 
        MoneyAmount = 1000;
        SellAmount = 50; 
    }

    // Update is called once per frame
    void Update()
    {
        Money.text = MoneyAmount.ToString();
        SellPrice.text = SellAmount.ToString(); 
    }

    public void SellButtonPressed()
    {
        Destroy(placementScript.selectedObject);
        MoneyAmount += SellAmount;
        Debug.Log("Button Is Clicked"); 
    }
}

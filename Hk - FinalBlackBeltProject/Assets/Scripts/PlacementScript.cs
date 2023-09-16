using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlacementScript : MonoBehaviour
{
    public GameObject Tower1; 
    public GameObject Tower2;
    public GameObject Tower3;

    public bool HoldingTower;

    Vector3 mousePositionOffset;

    public float mouseX; 
    public float mouseY;
    public float mouseZ; 

    Vector3 Vector3mousePosition;




    // Start is called before the first frame update
    void Start()
    {
        HoldingTower = false; 
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        mouseZ = Input.mousePosition.z;

        Vector3mousePosition = new Vector3(mouseX, mouseY, mouseZ); 
    }

    private void FixedUpdate()
    {
        if (HoldingTower)
        {
            Tower1.transform.position = Input.mousePosition;
        }

        if (HoldingTower && Input.GetMouseButtonDown(0)) 
        {
            HoldingTower= false;
            Instantiate(Tower1, Vector3mousePosition    GetMouseWorldPosition, Quaternion.identity);
            Debug.Log("Tower is placed"); 
        }
    }

    public void ButtonPressed()
    {
        //mousePositionOffset = Tower1.transform.position - GetMouseWorldPosition();
        Debug.Log("Button pressed");
        HoldingTower = true; 
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        pos.y =0f;
        return pos;
    }
}

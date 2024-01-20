using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public PlacementScript placementScript; 

    // Start is called before the first frame update
    void Start()
    {
        placementScript.NumberofParticles -= 1; 
        Destroy(gameObject, 0.2f);
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

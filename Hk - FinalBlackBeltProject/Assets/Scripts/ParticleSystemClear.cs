using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemClear : MonoBehaviour
{

    public ParticleSystem ParticleSystemAni; 

    public void Awake()
    {
        ParticleSystemAni = gameObject.GetComponent<ParticleSystem>(); 
    } 
  
    // Update is called once per frame
    void Update()
    {
        if (!ParticleSystemAni.IsAlive())
        {
            Destroy(gameObject); 
        }
    }
}

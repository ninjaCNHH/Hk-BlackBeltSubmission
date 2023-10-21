using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieExplosionScript : MonoBehaviour
{
    public Animation ZombieHitAnimation;
    public Animation ZombieDeathAnimation; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZombieHitAnimationStart()
    {
        ZombieHitAnimation.Play(); 
    }

    public void ZombieHitAnimationStop()
    {
        ZombieHitAnimation.Stop(); 
    }

    public void ZombieDeathAnimationStart()
    {
        ZombieDeathAnimation.Play(); 
    }
}

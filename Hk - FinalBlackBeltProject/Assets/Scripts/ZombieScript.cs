using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.AI;
using UnityEngine.UI; 

public class ZombieScript : MonoBehaviour
{
    public GameObject Zombie;

    [Header("Zombie Traits")] 
    public int Health;
    public int Defence;
    public int Speed;
    public int AngularSpeed;
    public int Acceleration; 

    [Header("AI Movement")]
    public NavMeshAgent agent;
    public GameObject alliedBase;
    public Animation ZombieWalk;

    [Header("UI")]
    public BaseHealth BaseHealthScript; 
    public ParticleSystem ZombieHitAnimation;
    public ParticleSystem ZombieDeathAnimation;

    // Start is called before the first frame update
    void Start()
    {

        alliedBase = GameObject.FindGameObjectWithTag("Base"); 

        agent = GetComponent<NavMeshAgent>();
        agent.destination = alliedBase.transform.position;
        agent.speed = Speed;
        agent.angularSpeed = AngularSpeed;
        agent.acceleration = Acceleration;
        ZombieHitAnimation.Stop();
    }
    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
        {
            GameObject.Find("Important Scripts").GetComponent<PlacementScript>().MoneyAmount += 50;
            Instantiate(ZombieDeathAnimation, Zombie.transform.position, Zombie.transform.rotation);
            Destroy(gameObject);
        }
    }



    public void ZombieDeathAnimationStart()
    {
        ZombieDeathAnimation.transform.position = gameObject.transform.position;
        ZombieDeathAnimation.Play();
    }

    public void ZombieHitAnimationStart()
    {
        ZombieHitAnimation.transform.position = gameObject.transform.position;
        ZombieHitAnimation.Play();

    }
}

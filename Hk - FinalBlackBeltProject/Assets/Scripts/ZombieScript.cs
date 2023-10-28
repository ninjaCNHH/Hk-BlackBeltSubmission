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
    public Transform alliedBase;
    public Animation ZombieWalk;

    [Header("UI")]
    public int AllyHealth; 
    public Text BaseHealth;
    public ParticleSystem ZombieHitAnimation;
    public ParticleSystem ZombieDeathAnimation; 

    // Start is called before the first frame update
    void Start()
    {
        AllyHealth = 100;
        
        Health = 30;

        agent = GetComponent<NavMeshAgent>();
        agent.destination = alliedBase.position;
        agent.speed = Speed;
        agent.angularSpeed = AngularSpeed;
        agent.acceleration = Acceleration;
        ZombieHitAnimation.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        BaseHealth.text = AllyHealth.ToString();

        if (Health<= 0)
        {
            Instantiate(ZombieDeathAnimation, Zombie.transform.position, Zombie.transform.rotation); 
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            AllyHealth -= 20;
            Destroy(Zombie);
            
        }
    }

    public void ZombieDeathAnimationStart()
    {
        ZombieDeathAnimation.transform.position = gameObject.transform.position;
        ZombieDeathAnimation.Play();
        Debug.Log("DeathAnimationPlay");
    }

    public void ZombieHitAnimationStart()
    {
        ZombieHitAnimation.transform.position = gameObject.transform.position;
        ZombieHitAnimation.Play();
        Debug.Log("HitAnimationPlay");
    }
}

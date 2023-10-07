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


    // Start is called before the first frame update
    void Start()
    {
        AllyHealth = 100;

        agent = GetComponent<NavMeshAgent>();
        agent.destination = alliedBase.position;
        agent.speed = Speed;
        agent.angularSpeed = AngularSpeed;
        agent.acceleration = Acceleration; 
    }
    // Update is called once per frame
    void Update()
    {
        BaseHealth.text = AllyHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            AllyHealth -= 20;
            Destroy(Zombie);
        }
    }
}

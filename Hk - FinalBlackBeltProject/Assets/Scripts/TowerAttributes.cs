using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerAttributes : MonoBehaviour
{
    [Header("TowerNumbers")]
    public int UpgradeAmount;
    public int NumberOfUpgrades; 
    public int AttackAmount;
    public float AttackSpeed;
    public float WaitTime;
    public float TotalTime; 
    public int Red = 0;
    public int Green = 255;
    public int Blue = 255; 

    [Header("SpecificFactors")]
    public GameObject[] Targets;
    public GameObject Enemy;
    public GameObject PlaceMentScript; 
    private PlacementScript placementScript;
    public ZombieScript ZombieScript;
    public ParticleSystem EnemyHit;

    [Header("Upgrades")]
    public GameObject Upgrade1;
    public GameObject Upgrade2;
    public GameObject Upgrade3;
    public GameObject Upgrade4; 
    

    // Start is called before the first frame update
    void Awake()
    {
        placementScript = PlaceMentScript.GetComponent<PlacementScript>();
        AttackAmount = 10;
        AttackSpeed = 6;
        UpgradeAmount = 50;
        NumberOfUpgrades = 0;
        WaitTime = 1.5f;
        Upgrade1.SetActive(true);
        Upgrade2.SetActive(false);
        Upgrade3.SetActive(false);
        Upgrade4.SetActive(false); 

        StartCoroutine(BulletAttacking());

        if (ZombieScript)
        {
            ZombieScript.ZombieHitAnimation.Stop();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Enemy)
        {
            ZombieScript = Enemy.GetComponent<ZombieScript>();
        }

        TotalTime = WaitTime + AttackSpeed;
    }

    IEnumerator BulletAttacking()
    {
        Targets = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = 1000;
        foreach (GameObject Targets in Targets)
        {
            float TargetDistance = Vector3.Distance(transform.position, Targets.transform.position);
            if (TargetDistance < minDistance)
            {
                minDistance = TargetDistance;
                Enemy = Targets;
            }
        }


        yield return new WaitForSeconds(WaitTime);
        if (Enemy && gameObject.transform.position.x > -70 && gameObject.transform.position.z > -50)
        {
            transform.LookAt(Enemy.transform.position);
            ZombieScript.Health -= AttackAmount;
            if (placementScript.NumberofParticles <= 20)
            {
                Instantiate(EnemyHit, Enemy.transform.position, Enemy.transform.rotation);
                placementScript.NumberofParticles += 1;
            }
            yield return new WaitForSeconds(AttackSpeed);
            StartCoroutine(BulletAttacking());
        }

        if (!Enemy)
        {
            StartCoroutine(BulletAttacking()); 
        }
    }
}

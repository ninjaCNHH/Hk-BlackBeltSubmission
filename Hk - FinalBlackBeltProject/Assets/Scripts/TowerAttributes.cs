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
    

    // Start is called before the first frame update
    void Start()
    {
        placementScript = PlaceMentScript.GetComponent<PlacementScript>();
        AttackAmount = 10;
        AttackSpeed = 6;
        UpgradeAmount = 50;
        NumberOfUpgrades = 0;
        WaitTime = 4; 

        StartCoroutine(BulletAttacking());
        if (ZombieScript)
        {
            ZombieScript.ZombieHitAnimation.Stop();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy)
        {
            ZombieScript = Enemy.GetComponent<ZombieScript>();
        }

        TotalTime = WaitTime + AttackSpeed; 

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

    }

    IEnumerator BulletAttacking()
    {
        yield return new WaitForSeconds(WaitTime);
        if (Enemy)
        {
            transform.LookAt(Enemy.transform.position);

            ZombieScript.Health -= AttackAmount;
            ZombieScript.ZombieHitAnimationStart();
            yield return new WaitForSeconds(AttackSpeed);
            StartCoroutine(BulletAttacking());
        }
    }
}

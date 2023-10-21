using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerAttributes : MonoBehaviour
{
    [Header("TowerNumbers")]
    public int UpgradeAmount;
    public Text UpgradePriceText;
    public int AttackAmount;
    public Text AttackText;
    public float AttackSpeed;
    public Text AtkSpeedText;
    public int Range;
    public Text RangeAmountText;

    [Header("SpecificFactors")]
    public GameObject[] Targets;
    public GameObject Enemy; 
    public PlacementScript placementScript;
    public ZombieScript ZombieScript;
    public ZombieExplosionScript ZombieExplosionScript;
    

    // Start is called before the first frame update
    void Start()
    {
        placementScript = placementScript.GetComponent<PlacementScript>();
        AttackAmount = 10;
        AttackSpeed = 1;
        ZombieExplosionScript = Enemy.GetComponent<ZombieExplosionScript>();
        ZombieExplosionScript.ZombieHitAnimationStop(); 
        StartCoroutine(BulletAttacking()); 
    }

    // Update is called once per frame
    void Update()
    {
        ZombieScript = Enemy.GetComponent<ZombieScript>();
        AttackText.text = AttackAmount.ToString();
        AtkSpeedText.text = AttackSpeed.ToString();
        RangeAmountText.text = Range.ToString();

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
        yield return new WaitForSeconds(4f); 
        
        transform.LookAt(Enemy.transform.position);
        Debug.Log("Towerislooking");
        ZombieScript.Health -= AttackAmount;
        ZombieExplosionScript.ZombieHitAnimationStart(); 
        yield return new WaitForSeconds(AttackSpeed);
        ZombieExplosionScript.ZombieHitAnimationStop(); 
        StartCoroutine(BulletAttacking());
    }
}

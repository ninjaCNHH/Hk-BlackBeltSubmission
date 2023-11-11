using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class RoundCount : MonoBehaviour
{
    public ZombieScript ZombieScirpt;
    public GameObject FastZombie; 
    public Text RoundText;
    public int RoundNumber;
    public int WaveNumber; 
    public Vector3 OriginalSpawnLocation;
    bool NewRoundStarts; 
    bool CorutineNormalZombieFinished = true; 
    bool CorutineFastZombieFinished = true;
    // Start is called before the first frame update
    void Start()
    {
        RoundNumber= 0;
        WaveNumber = 1;
        NewRoundStarts = true; 
        
        Vector3 OGspawn = new Vector3(OriginalSpawnLocation.x, OriginalSpawnLocation.y, OriginalSpawnLocation.z);

        ZombieScirpt = ZombieScirpt.GetComponent<ZombieScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveNumber == 1 && NewRoundStarts)
        {
            StartCoroutine(SpawnNormalZombie());  
            Invoke("StopNormalZombieSpawn" , 20f);
            Invoke("Round1Finish", 20f);
            RoundNumber = 1; 
            RoundText.text = RoundNumber.ToString(); 
            NewRoundStarts= false;
        }

        if (WaveNumber == 2 && NewRoundStarts)
        {
            StartCoroutine(SpawnNormalZombie());
            Invoke("StopNormalZombieSpawn", 10f);
            StartCoroutine(SpawnFastZombie());
            Invoke("StopFastZombieSpawn", 20f); 
            Invoke("Round2Finish", 20f); 
            RoundNumber = 2;
            RoundText.text = RoundNumber.ToString();
            NewRoundStarts= false;
            Debug.Log("Round 2 Has Started"); 

        }

        if (WaveNumber == 3 && NewRoundStarts)
        {
            Debug.Log("WAVE 3 BEGINS"); 
        }
    }

    IEnumerator SpawnNormalZombie()
    { 
        yield return new WaitForSeconds(4f);
        Instantiate(ZombieScirpt.Zombie, OriginalSpawnLocation, Quaternion.identity);
        if (CorutineNormalZombieFinished == true)
        {
           StartCoroutine(SpawnNormalZombie());
        }
    }

    IEnumerator SpawnFastZombie()
    {
        yield return new WaitForSeconds(4f);
        Instantiate(FastZombie, OriginalSpawnLocation, Quaternion.identity);
        if (CorutineFastZombieFinished == true)
        {
            StartCoroutine(SpawnFastZombie());
        }
    }

    public void StopNormalZombieSpawn()
    {
        CorutineNormalZombieFinished = false;

    }  
    
    public void StopFastZombieSpawn()
    {
        CorutineFastZombieFinished = false;
    }

    public void Round1Finish()
    {
        WaveNumber = 2;
        NewRoundStarts = true; 
    }

    public void Round2Finish()
    {
        WaveNumber = 3;
        NewRoundStarts = true; 
    }
}

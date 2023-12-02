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
    public GameObject HeavyZombie; 
    public Text RoundText;
    public int RoundNumber;
    public int WaveNumber; 
    public Vector3 OriginalSpawnLocation;
    bool NewRoundStarts; 
    bool CorutineNormalZombieFinished = true; 
    bool CorutineFastZombieFinished = true;
    bool CorutineHeavyZombieFinished = true;
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

        }

        if (WaveNumber == 3 && NewRoundStarts)
        {
            StartCoroutine(SpawnNormalZombie());
            Invoke("StopNormalZombieSpawn", 10f);
            StartCoroutine(SpawnFastZombie());
            Invoke("StopFastZombieSpawn", 30f);
            Invoke("Round3Finish", 30f);
            RoundNumber = 3;
            RoundText.text = RoundNumber.ToString();
            NewRoundStarts = false;
        }

        if (WaveNumber == 4 && NewRoundStarts)
        {
            StartCoroutine(SpawnFastZombie());
            Invoke("StopFastZombieSpawn", 40f);
            Invoke("Round4Finish", 40f);
            RoundNumber = 4;
            RoundText.text = RoundNumber.ToString();
            NewRoundStarts = false;
        }

        if (WaveNumber == 5 && NewRoundStarts)
        {
            StartCoroutine(SpawnFastZombie());
            Invoke("StopFastZombieSpawn", 10f);
            StartCoroutine(SpawnHeavyZombie());
            Invoke("StopHeavyZombieSpawn", 30f); 
            Invoke("Round5Finish", 30f);
            RoundNumber = 5;
            RoundText.text = RoundNumber.ToString();
            NewRoundStarts = false;
        }
    }

    IEnumerator SpawnNormalZombie()
    { 
        yield return new WaitForSeconds(2f);
        Instantiate(ZombieScirpt.Zombie, OriginalSpawnLocation, Quaternion.identity);
        if (CorutineNormalZombieFinished == true)
        {
           StartCoroutine(SpawnNormalZombie());
        }
    }

    IEnumerator SpawnFastZombie()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(FastZombie, OriginalSpawnLocation, Quaternion.identity);
        if (CorutineFastZombieFinished == true)
        {
            StartCoroutine(SpawnFastZombie());
        }
    }

    IEnumerator SpawnHeavyZombie()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(HeavyZombie, OriginalSpawnLocation, Quaternion.identity);
        if (CorutineHeavyZombieFinished == true)
        {
            StartCoroutine(SpawnHeavyZombie());
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

    public void StopHeavyZombieSpawn()
    {
        CorutineHeavyZombieFinished = false;
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

    public void Round3Finish()
    {
        WaveNumber = 4;
        NewRoundStarts = true;
    }

    public void Round4Finish()
    {
        WaveNumber = 5;
        NewRoundStarts = true;
    }

    public void Round5Finish()
    {
        WaveNumber = 6;
        NewRoundStarts = true;
    }

    public void Round6Finish()
    {
        WaveNumber = 7;
        NewRoundStarts = true;
    }

    public void Round7Finish()
    {
        WaveNumber = 8;
        NewRoundStarts = true;
    }

    public void Round8Finish()
    {
        WaveNumber = 9;
        NewRoundStarts = true;
    }

    public void Round9Finish()
    {
        WaveNumber = 10;
        NewRoundStarts = true;
    }

    public void Round10Finish()
    {
        WaveNumber = 11;
        NewRoundStarts = true;
    }
}

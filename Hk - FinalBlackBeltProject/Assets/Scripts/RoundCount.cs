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
    public GameObject MiniBoss;
    public GameObject FastHeavy;
    public GameObject BigBoss; 
    public Text RoundText;
    public int RoundNumber;
    public int WaveNumber; 
    public Vector3 OriginalSpawnLocation;
    bool NewRoundStarts; 
    bool CorutineNormalZombieFinished = true; 
    bool CorutineFastZombieFinished = true;
    bool CorutineHeavyZombieFinished = true;
    bool CourtineMiniBossFinished = true;
    bool CourtineFastHeavyFinished = true; 
    bool CorutineBigBossFinished = true;
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
            Invoke("Round3Finish", 10f);
            RoundNumber = 3;
            RoundText.text = RoundNumber.ToString();
            NewRoundStarts = false;
        }

        if (WaveNumber == 4 && NewRoundStarts)
        {
            StartCoroutine(SpawnFastZombie());
            Invoke("StopFastZombieSpawn", 30f);
            StartCoroutine(SpawnHeavyZombie());
            Invoke("StopHeavyZombieSpawn", 10f);
            Invoke("Round4Finish", 30f);
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

        if (WaveNumber == 6 && NewRoundStarts)
        {

            StartCoroutine(SpawnFastZombie());
            Invoke("StopFastZombieSpawn", 30f);
            StartCoroutine(SpawnMiniBoss());
            Invoke("StopMiniBossSpawn", 5f);
            Invoke("Round6Finish", 30f);
            RoundNumber = 6;
            RoundText.text = RoundNumber.ToString();
            NewRoundStarts = false;
        }

        if (WaveNumber == 7 && NewRoundStarts)
        {
            StartCoroutine(SpawnHeavyZombie());
            Invoke("StopHeavyZombieSpawn", 20f);
            StartCoroutine(SpawnFastZombie());
            Invoke("StopFastZombieSpawn", 15f);
            StartCoroutine(SpawnMiniBoss());
            Invoke("StopMiniBossSpawn", 10f);
            Invoke("Round7Finish", 30f);
            RoundNumber = 7;
            RoundText.text = RoundNumber.ToString();
            NewRoundStarts = false;
        }

        if (WaveNumber == 8 && NewRoundStarts)
        {
            StartCoroutine(SpawnMiniBoss());
            Invoke("StopMiniBossSpawn", 10f);
            StartCoroutine(SpawnFastHeavy());
            Invoke("StopFastHeavySpawn", 20f);
            Invoke("Round8Finish", 30f);
            RoundNumber = 8;
            RoundText.text = RoundNumber.ToString();
            NewRoundStarts = false;
        }

        if (WaveNumber == 9 && NewRoundStarts)
        {
            StartCoroutine(SpawnMiniBoss());
            Invoke("StopMiniBossSpawn", 15f);
            StartCoroutine(SpawnFastHeavy());
            Invoke("StopFastHeavySpawn", 30f);
            Invoke("Round9Finish", 35f);
            RoundNumber = 9;
            RoundText.text = RoundNumber.ToString();
            NewRoundStarts = false;
        }

        if (WaveNumber == 10 && NewRoundStarts)
        {
            StartCoroutine(SpawnMiniBoss());
            Invoke("StopMiniBossSpawn", 15f);
            StartCoroutine(SpawnBigBoss());
            Invoke("StopBigBossSpawn", 2f);
            StartCoroutine(SpawnFastHeavy());
            Invoke("StopFastHeavySpawn", 20f);
            Invoke("Round10Finish", 30f);
            RoundNumber = 10;
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

    IEnumerator SpawnMiniBoss()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(MiniBoss, OriginalSpawnLocation, Quaternion.identity);
        if (CourtineMiniBossFinished == true)
        {
            StartCoroutine(SpawnMiniBoss());
        }
    }

    IEnumerator SpawnFastHeavy()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(FastHeavy, OriginalSpawnLocation, Quaternion.identity);
        if (CourtineFastHeavyFinished == true)
        {
            StartCoroutine(SpawnFastHeavy());
        }
    }

    IEnumerator SpawnBigBoss()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(BigBoss, OriginalSpawnLocation, Quaternion.identity);
        if (CorutineBigBossFinished == true)
        {
            StartCoroutine(SpawnBigBoss());
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

    public void StopMiniBossSpawn()
    {
        CourtineMiniBossFinished = false;
    }

    public void StopFastHeavySpawn()
    {
        CourtineFastHeavyFinished = false;
    }

    public void StopBigBossSpawn()
    {
        CorutineBigBossFinished = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class RoundCount : MonoBehaviour
{
    public ZombieScript ZombieScirpt;
    public Vector3 OriginalSpawnLocation;
    bool Round1; 
    bool Round2;
    bool Round3;
    bool Round4;
    bool Round5;
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 OGspawn = new Vector3(OriginalSpawnLocation.x, OriginalSpawnLocation.y, OriginalSpawnLocation.z);
        Round1 = true;
        Round2 = false;
        Round3 = false;
        Round4 = false;
        Round5 = false;
        ZombieScirpt = ZombieScirpt.GetComponent<ZombieScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Round1)
        {
            StartCoroutine(SpawnNormalZombie());  
            Invoke("StopNormalZombieSpawn" , 20f);
            Round1= false;
            Round2 = true;
        }

        if (!Round1 && Round2)
        {

        }
    }

    IEnumerator SpawnNormalZombie()
    {
        yield return new WaitForSeconds(4f); 
        Instantiate(ZombieScirpt.Zombie, OriginalSpawnLocation, Quaternion.identity); 
        StartCoroutine(SpawnNormalZombie());
    }
    public void StopNormalZombieSpawn()
    {
        StopCoroutine(SpawnNormalZombie());
    }    
}

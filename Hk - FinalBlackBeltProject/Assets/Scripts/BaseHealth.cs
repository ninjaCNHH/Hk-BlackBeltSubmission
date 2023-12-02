using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class BaseHealth : MonoBehaviour
{
    public int AllyHealth;
    public Text BaseHP; 
    // Start is called before the first frame update
    void Start()
    {
        BaseHP = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();

        AllyHealth = 100; 
    }
    // Update is called once per frame
    void Update()
    {
        BaseHP.text = AllyHealth.ToString();

        if (AllyHealth <= 0)
        {
            SceneManager.LoadScene(2); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AllyHealth -= 20; 
            Destroy(other.gameObject);
        }
    }
}

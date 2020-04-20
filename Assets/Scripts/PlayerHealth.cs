using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 20;
    [SerializeField] Text healthText;

    EnemySpawner enemySpawner;

    private void Start()
    {
        healthText.text = health.ToString();
        enemySpawner = GetComponent<EnemySpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        health = health - 1;
        healthText.text = health.ToString();
        if (health < 0)
        {
            healthText.text = "0";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 20;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip selfDestructSFX;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(selfDestructSFX);
        health = health - 1;
        healthText.text = health.ToString();
        if (health < 0)
        {
            healthText.text = "0";
        }
    }
}

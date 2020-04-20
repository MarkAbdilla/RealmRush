using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 20;

    private void OnTriggerEnter(Collider other)
    {
        health = health - 1;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponConfig config;
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        Debug.Log($"Weapon Name: {config.name}");
        Debug.Log($"Max Ammo: {config.maxAmmo}");
        Debug.Log($"Damage: {config.damage}");
        Debug.Log($"Distance: {config.distance}");

    }
}

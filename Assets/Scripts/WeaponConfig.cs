using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "WeaponModel", order = 0)]
public class WeaponConfig : ScriptableObject
{
    public string weaponName;
    public int maxAmmo;
    public float damage;
    public float distance;
}
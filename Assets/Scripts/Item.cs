using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Unnamed Item", menuName = "Invetory Item")]
public class Item : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string descrption;
    [SerializeField] float itemWeight;

    public string GetName()
    {
        return itemName;
    }
}

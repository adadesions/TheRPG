using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Item[] contents;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in contents) {
            Debug.Log($"Has item: {item.GetName()}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

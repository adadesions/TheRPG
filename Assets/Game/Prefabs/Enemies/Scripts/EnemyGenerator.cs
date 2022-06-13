using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    Transform centerPoint = null;

    [SerializeField]
    int numOfEnemy = 3;

    [SerializeField]
    GameObject enemyPrefab = null;

    void Start()
    {        
        for (int i = 0; i < numOfEnemy; i++)
        {   
            float posX = Random.Range(-30.0f, 30.0f);
            float posZ = Random.Range(-30.0f, 30.0f);
            Transform spawn = centerPoint;            
            Vector3 offset = new Vector3(posX, 0, posZ);
            spawn.position += offset;            

            Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

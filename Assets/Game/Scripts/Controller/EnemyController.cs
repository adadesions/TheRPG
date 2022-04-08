using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRPG.Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 6f;

        private void Update()
        {
            if (DistanceToPlayer() < chaseDistance)
            {
                print("Should chase!!");
            }
        }

        private float DistanceToPlayer()
        {
            GameObject player = GameObject.FindWithTag("Player");
            Vector3 playerPosition = player.transform.position;
            return Vector3.Distance(transform.position, playerPosition);
        }
    }
}


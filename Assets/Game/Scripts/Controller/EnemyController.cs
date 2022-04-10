using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Combat;

namespace TheRPG.Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 6f;
        Fighter fighter;
        GameObject player;
        Health health;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (DistanceToPlayer() < chaseDistance)
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }

        private float DistanceToPlayer()
        {
            Vector3 playerPosition = player.transform.position;
            return Vector3.Distance(transform.position, playerPosition);
        }
    }
}


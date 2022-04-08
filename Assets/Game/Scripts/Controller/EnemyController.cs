using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Combat;

namespace TheRPG.Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        Fighter fighter;
        GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {            
            if (isInRangeToPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }
        
        private bool isInRangeToPlayer()
        {
            return Vector3.Distance(player.transform.position, transform.position) < chaseDistance;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using TheRPG.Movement;
using UnityEngine;

namespace TheRPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;

        void Update()
        {
            if (target != null)
            {
                bool isInRange = Vector3.Distance(transform.position, target.position) <= weaponRange;
                if (isInRange)
                {
                    GetComponent<Mover>().Stop();
                }
                else
                {
                    GetComponent<Mover>().MoveTo(target.position);
                    target = null;
                }
            }    
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("Attacking!!");
        }
    }
}


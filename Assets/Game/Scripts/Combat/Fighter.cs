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
            if (target == null) return;

            if (!GetInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
                GetComponent<Animator>().SetTrigger("attack");
            }
        }

        private bool GetInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            
            print("Attacking!!");
        }

        public void Cancel()
        {
            target = null;
        }
    }
}


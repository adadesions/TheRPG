using System.Collections;
using System.Collections.Generic;
using TheRPG.Movement;
using TheRPG.Core;
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
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
                GetComponent<Animator>().SetTrigger("attack");
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;            
        }

        public void Cancel()
        {
            target = null;
        }
    }
}


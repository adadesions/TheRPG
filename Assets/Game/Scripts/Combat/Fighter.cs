using System.Collections;
using System.Collections.Generic;
using TheRPG.Movement;
using TheRPG.Core;
using UnityEngine;

namespace TheRPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttack = 1f;
        [SerializeField] float weaponDamage = 5f;

        Transform target;
        float timeSinceLastAttack = 0f;

        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttack)
            {
                GetComponent<Animator>().SetTrigger("attack");              
                timeSinceLastAttack = 0;
            }   
        }

        public bool CanAttack(CombatTarget combetTarget)
        {
            if (combetTarget == null) { return false; }
            Health targetHealth = combetTarget.GetComponent<Health>();
            return targetHealth != null && !targetHealth.GetIsDead();

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
            GetComponent<Animator>().SetTrigger("stopAttack");
            target = null;
        }

        // Animation Event methods
        void Hit()
        {
            if (target != null)
            {
                target.GetComponent<Health>().TakeDamage(weaponDamage);
            }
        }
    }
}


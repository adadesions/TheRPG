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
        [SerializeField] GameObject weaponEquipped = null;
        [SerializeField] Transform handTransform = null;

        Transform target;
        float timeSinceLastAttack = Mathf.Infinity;

        void Start() {
            SpawnWeapon();
        }

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

        private void SpawnWeapon() {
            Instantiate(weaponEquipped, handTransform);
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target);
            bool isDead = target.GetComponent<Health>().GetIsDead();
            if (timeSinceLastAttack > timeBetweenAttack)
            {
                AttackAction();             
                timeSinceLastAttack = 0;
            }

            if (isDead)
            {
                Cancel();
            }
            
        }

        private void AttackAction()
        {
            Animator animator = GetComponent<Animator>();
            if (weaponRange >= 12)
            {
                animator.SetTrigger("rangeAttack");
            }
            else
            {
                animator.SetTrigger("attack");
            }
        }

        public bool CanAttack(GameObject combetTarget)
        {
            if (combetTarget == null) return false;
            Health targetHealth = combetTarget.GetComponent<Health>();

            return targetHealth != null && !targetHealth.GetIsDead();
        }

        private bool GetIsInRange()
        {
            if (target == null) return false;
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(GameObject combatTarget)
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


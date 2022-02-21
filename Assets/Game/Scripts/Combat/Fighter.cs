using System.Collections;
using System.Collections.Generic;
using TheRPG.Movement;
using UnityEngine;

namespace TheRPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        //[SerializeField] float weaponRange = 2f;
        Transform target;

        public void Update()
        {
            //bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
            if (target != null)
            {
                GetComponent<Mover>().MoveTo(target.position);
                
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("Attacking: " + target.name);
        }
    }
}


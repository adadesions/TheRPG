using System.Collections;
using System.Collections.Generic;
using TheRPG.Movement;
using UnityEngine;

namespace TheRPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        Transform target;

        void Update()
        {
            if (target != null)
            {
                GetComponent<Mover>().MoveTo(target.position);
                target = null;
            }    
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("Attacking!!");
        }
    }
}


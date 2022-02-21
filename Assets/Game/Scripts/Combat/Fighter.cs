using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        public void Attack(CombatTarget target)
        {
            print("Attacking: " + target.name);
        }
    }
}


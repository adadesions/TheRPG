using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Movement;
using System;
using TheRPG.Combat;

namespace TheRPG.Controller
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            if (InteractWithDPad()) return;
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;            
        }

        private bool InteractWithDPad() {            
            if (Input.GetButtonDown("xboxB")) {
                print("Press: B");
                Animator animator = GetComponent<Animator>();
                animator.SetTrigger("attack");
                return true;
            }

            return false;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();

                if (target == null) continue;
                if (!GetComponent<Fighter>().CanAttack(target.gameObject))
                {
                    continue;
                }

                if (Input.GetMouseButton(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);
                }                
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            float xAxis = Input.GetAxis("Horizontal");
            float zAxis = Input.GetAxis("Vertical");
            
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMove(hit.point);
                }
                else if (xAxis != 0 || zAxis != 0) {
                    Vector3 curPos = transform.position;
                    Vector3 dest = new Vector3(xAxis*10, 0, zAxis*10) + curPos;                    
                    GetComponent<Mover>().StartMove(dest);
                }

                return true;
            }

            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}


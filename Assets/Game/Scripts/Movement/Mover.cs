using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TheRPG.Combat;
using TheRPG.Core;

namespace TheRPG.Movement
{
    public class Mover : MonoBehaviour
    {
        Ray lastRay;
        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }

        public void StartMove(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 hit)
        {
            GetComponent<NavMeshAgent>().destination = hit;
            GetComponent<NavMeshAgent>().isStopped = false;
        }

        public void Stop()
        {
            GetComponent<NavMeshAgent>().isStopped = true;
        }


        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;

            // Global to Local
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);

            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}

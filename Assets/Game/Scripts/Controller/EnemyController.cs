using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Combat;
using TheRPG.Movement;
using TheRPG.Core;

namespace TheRPG.Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 6f;
        [SerializeField] WayPoints wayPoints;
        [SerializeField] float wayPointTolerance = 1f;
        [SerializeField] float waypointDwellTime = 3f;
        [SerializeField] float suspicionTime = 3f;

        Fighter fighter;
        GameObject player;
        Health health;
        int curWayPointIndex = 0;
        float timeLastSawPlayer = Mathf.Infinity;
        float timeSinceArrivedAtWaypoint = Mathf.Infinity;
        Mover mover;
        Vector3 guardPosition;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            player = GameObject.FindWithTag("Player");
            guardPosition = transform.position;
        }

        private void Update()
        {
            if (health.GetIsDead()) return;

            if (DistanceToPlayer() && fighter.CanAttack(player))
            {
                AttackBehavior();
            }
            else if (timeLastSawPlayer < suspicionTime)
            {
                SuspicionBehavior();
            }
            else
            {
                WayPointBehavior();
            }

            UpdateTimer();
        }

        private void UpdateTimer()
        {
            timeLastSawPlayer += Time.deltaTime;
            timeSinceArrivedAtWaypoint += Time.deltaTime;
        }

        private void WayPointBehavior()
        {
            Vector3 nextPosition = guardPosition;
            if (wayPoints != null)
            {
                if (AtWayPoint())
                {
                    timeSinceArrivedAtWaypoint = 0;
                    loopWayPoint();
                }
                nextPosition = GetCurrentWayPoint();
            }

            if (timeSinceArrivedAtWaypoint > waypointDwellTime)
            {
                mover.StartMove(nextPosition);
            }
        }

        private void loopWayPoint()
        {
            curWayPointIndex = wayPoints.GetNextIndex(curWayPointIndex);
        }

        private bool AtWayPoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWayPoint());

            print("distanceToWaypoint: " + distanceToWaypoint);
            return distanceToWaypoint < wayPointTolerance;

        }

        private Vector3 GetCurrentWayPoint()
        {
            return wayPoints.GetPoint(curWayPointIndex);
        }

        private void SuspicionBehavior()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBehavior()
        {
            timeLastSawPlayer = 0;
            fighter.Attack(player);
        }

        private bool DistanceToPlayer()
        {
            Vector3 playerPosition = player.transform.position;
            return Vector3.Distance(transform.position, playerPosition) < chaseDistance;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
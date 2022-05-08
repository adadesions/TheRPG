using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Combat;
using TheRPG.Movement;
using TheRPG.Core;
using UnityEngine.AI;

namespace TheRPG.Controller
{
    public class RobotController : MonoBehaviour
    {
        [SerializeField] WayPoints wayPoints;
        [SerializeField] float wayPointTolerance = 1f;
        int curWayPointIndex = 0;
        Vector3 robotPos;

        void Start()
        {
            robotPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            WayPointBehavior();
        }

        private void WayPointBehavior()
        {
            Vector3 nextPos = robotPos;
            if (wayPoints != null)
            {
                if (AtWayPoint())
                {
                    loopWayPoint();
                }
                nextPos = GetCurrentWayPoint();
            }

            print("Current Point: " + curWayPointIndex);
            GetComponent<NavMeshAgent>().destination = nextPos;
            GetComponent<NavMeshAgent>().isStopped = false;
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

        private void loopWayPoint()
        {
            curWayPointIndex = wayPoints.GetNextIndex(curWayPointIndex);
        }
    }
}
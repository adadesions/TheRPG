using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TheRPG.Controller
{
    public class LabController : MonoBehaviour
    {
        [SerializeField] WayPoint wayPoints;
        [SerializeField] float wayPointsTolerance = 1f;

        int curWayPointIndex = 0;
        Vector3 robotPos;

        // Start is called before the first frame update
        void Start()
        {
            robotPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            robotPos = transform.position;
            WayPointBehaviour();            
        }

        private void WayPointBehaviour() {
            Vector3 nextPos = robotPos;
            if (wayPoints != null) {
                if (IsAtWayPoint()) {
                    MoveNextWayPoint();
                }
                nextPos = GetCurrentWayPoint();
            }

            GetComponent<NavMeshAgent>().destination = nextPos;
        }

        private bool IsAtWayPoint() {
            Vector3 curWayPoint = GetCurrentWayPoint();
            float distanceToWaypoint = Vector3.Distance(robotPos, curWayPoint);
            return distanceToWaypoint < wayPointsTolerance;
        }

        private Vector3 GetCurrentWayPoint() {
            return wayPoints.GetPoint(curWayPointIndex);
        }

        private void MoveNextWayPoint() {
            curWayPointIndex = wayPoints.GetNextIndex(curWayPointIndex);
        }
    }
}

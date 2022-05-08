using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            WayPointBehaviour();
        }

        private void WayPointBehaviour() {
            Vector3 nextPos = robotPos;
            if (wayPoints != null) {
                if (isAtWayPoint()) {
                    moveNextWayPoint();
                }
                nextPos = GetCurrentWayPoint();
            }

            GetComponent<NavMeshAgent>().destination = nextPos;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LD40.Waypoint
{
    public class WaypointManager : MonoBehaviour
    {

        [SerializeField]
        private List<WaypointBehaviour> m_ListWaypoints;

        public void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                m_ListWaypoints.Add(transform.GetChild(i).GetComponent<WaypointBehaviour>());
            }
        }

        public WaypointBehaviour GetCloserWayPoint(Vector3 m_myPosition)
        {
            WaypointBehaviour _WayPoint = null;
            float _CurrentWayPointDistance = 0f;
            for (int i = 0; i < m_ListWaypoints.Count; i++)
            {
                if (_WayPoint == null)
                {
                    _WayPoint = m_ListWaypoints[i];
                    _CurrentWayPointDistance = Vector2.Distance(m_myPosition, _WayPoint.MyTransform.position);
                }
                else
                {
                    float _AuxWaypointDistance = Vector2.Distance(m_myPosition, m_ListWaypoints[i].MyTransform.position);
                    if (_AuxWaypointDistance < _CurrentWayPointDistance)
                    {
                        _CurrentWayPointDistance = _AuxWaypointDistance;
                        _WayPoint = m_ListWaypoints[i];
                    }
                }
            }

            return _WayPoint;
        }


        public WaypointBehaviour GetNextWayPoint(WaypointBehaviour _CurrentWayPoint)
        {
            int _IndexWayPointList = m_ListWaypoints.IndexOf(_CurrentWayPoint);

            WaypointBehaviour _WayPoint = m_ListWaypoints[_IndexWayPointList];

            int _CountWaypointBrothers = _WayPoint.BrotherWayPoints.Count;

            WaypointBehaviour _NextWayPoint = _WayPoint.BrotherWayPoints[Random.Range(0, _CountWaypointBrothers)];

            return _NextWayPoint;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LD40.Waypoint
{
    public class WaypointBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform m_MyTransform;
        [SerializeField]
        private List<WaypointBehaviour> m_BrotherWayPoints;

        private void Awake()
        {
            m_MyTransform = GetComponent<Transform>();
        }

        public Transform MyTransform
        {
            get
            {
                return m_MyTransform;
            }

            set
            {
                m_MyTransform = value;
            }
        }

        public List<WaypointBehaviour> BrotherWayPoints
        {
            get
            {
                return m_BrotherWayPoints;
            }

            set
            {
                m_BrotherWayPoints = value;
            }
        }
    }
}
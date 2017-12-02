using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD40.Waypoint;

public class CatBehaviour : MonoBehaviour {

    [SerializeField]
    private float m_speed;
    [SerializeField]
    private GameObject m_shit;


    private Transform m_Transform;

    private Vector3 m_LastPosition;

    private WaypointBehaviour m_WayPoint;

    private WaypointManager m_WayPointManager;

    private Animator m_Animator;

    private bool m_IsMove = true;
    private bool m_IsShit = false;

    private IEnumerator Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Animator = GetComponent<Animator>();

        m_WayPointManager = GameObject.FindGameObjectWithTag("WayPoints").GetComponent<WaypointManager>();

        m_WayPoint = m_WayPointManager.GetCloserWayPoint(m_Transform.position);

        yield return new WaitForSeconds(Random.Range(5, 10));

        StartCoroutine(SetShit());
        m_IsShit = false;
    }

    public void Update()
    {

        if(m_IsMove && m_WayPoint != null)
        {
            float _speed = m_speed * Time.deltaTime;

            m_Transform.position = Vector2.MoveTowards( m_Transform.position, 
                                                        m_WayPoint.MyTransform.position, 
                                                        _speed);

            if (m_LastPosition.y < m_Transform.position.y) m_Animator.SetTrigger("up");
            else if(m_LastPosition.y > m_Transform.position.y) m_Animator.SetTrigger("down");

            if (Vector2.Distance(m_Transform.position, m_WayPoint.MyTransform.position) <= 0.2f)
            {
                m_Transform.position = m_WayPoint.MyTransform.position;
                States();
            }

            m_LastPosition = m_Transform.position;

        }

        if(m_IsShit == true)
        {
            StartCoroutine(SetShit());
            m_IsShit = false;
        }
    }

    private void States()
    {
        if(m_IsMove)
        {
            m_IsMove = false;
            m_WayPoint = m_WayPointManager.GetNextWayPoint(m_WayPoint);
            m_Animator.SetTrigger("idle");
            StartCoroutine(Idle(Random.Range(1, 3)));
            ///Implementa Animações, e tempo para o proximo Estado
        }
    }

    private IEnumerator Idle(float _time)
    {
        yield return new WaitForSeconds(_time);

        m_IsMove = true;
    }

    private IEnumerator SetShit()
    {
        var _Object = Instantiate(m_shit);
        _Object.transform.position = m_Transform.position;
        /// Implementar a cagação
        yield return new WaitForSeconds(Random.Range(5, 10));
        m_IsShit = true;
    }

    private void Meow(){ }

}

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

    private PlayerInventory m_Inventory;

    public StatsEnum m_CatEnum;

    Coroutine m_CoroutineIdle;

    private IEnumerator Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Animator = GetComponent<Animator>();
        m_Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
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
            ///Aplicação das Rotas das Animações
            {
                if (m_LastPosition.y < m_Transform.position.y)
                {
                    m_Animator.SetBool("up", true);
                    m_Animator.SetBool("down", false);
                }
                else if (m_LastPosition.y > m_Transform.position.y)
                {
                    m_Animator.SetBool("down", true);
                    m_Animator.SetBool("up", false);
                }
            }

            if (Vector2.Distance(m_Transform.position, m_WayPoint.MyTransform.position) <= 0.2f)
            {
                m_Transform.position = m_WayPoint.MyTransform.position;
                States();
            }

            m_LastPosition = m_Transform.position;

        }

        if(m_IsShit == true && m_CatEnum != StatsEnum.Sleep)
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

            ///Aplicação das Rotas das Animações
            {
                m_Animator.SetBool("down", false);
                m_Animator.SetBool("up", false);
                m_Animator.SetBool("idle", true);
            }

            m_CoroutineIdle = StartCoroutine(Idle(Random.Range(GameAutoConfig.instance.m_RangeTimeIdle.x,
                                                               GameAutoConfig.instance.m_RangeTimeIdle.y)));
        }
    }

    public IEnumerator Sleep(float _time)
    {

        m_IsMove = false;

        ///Aplicação das Rotas das Animações
        {
            m_Animator.SetTrigger("sleep");
            m_Animator.SetBool("down", false);
            m_Animator.SetBool("up", false);
            m_Animator.SetBool("idle", false);
        }

        StopCoroutine(m_CoroutineIdle);
        m_CatEnum = StatsEnum.Sleep;

        yield return new WaitForSeconds(_time);

        m_IsMove = true;
        m_CatEnum = StatsEnum.Move;
    }

    public IEnumerator Idle(float _time)
    {
        StopCoroutine(Sleep(0));
        m_CatEnum = StatsEnum.Idle;
        m_IsMove = false;

        yield return new WaitForSeconds(_time);

        ///Aplicação das Rotas das Animações
        {
            m_Animator.SetBool("idle", false);
        }

        m_IsMove = true;
        m_CatEnum = StatsEnum.Move;
    }

    private IEnumerator SetShit()
    {
        var _Object = Instantiate(m_shit);
        _Object.transform.position = m_Transform.position;
        m_Inventory.SetShit();
        /// Implementar a cagação
        yield return new WaitForSeconds(Random.Range(GameAutoConfig.instance.m_RangeTimeShit.x, GameAutoConfig.instance.m_RangeTimeShit.y));
        m_IsShit = true;
    }

    private void Meow(){ }

}

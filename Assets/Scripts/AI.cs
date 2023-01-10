using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] List<Transform> _wayPoint;
    private int destPoint = 0;
    NavMeshAgent _agent;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        _agent.autoBraking = false;
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    private void GoToNextPoint() 
    {
        if (_wayPoint.Count == 0) return;
        destPoint = Random.Range(0, _wayPoint.Count + 1);
        _agent.destination =_wayPoint[destPoint].position;
    }
}

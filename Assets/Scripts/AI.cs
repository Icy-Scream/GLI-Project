using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] List<Transform> _wayPoint;
    private int destPoint = 0;
    NavMeshAgent _agent;
    bool _reverse = false;
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
        ReversePoint(destPoint);
        GetPoint();        

        // destPoint = (destPoint + 1) % _wayPoint.Count; //Reset to Zero

    }

    private void GetPoint() 
    {
        if (!_reverse) 
        { 
         _agent.destination = _wayPoint[destPoint].position;
         destPoint++;
        }
        else 
        {
            destPoint--;
            _agent.destination = _wayPoint[destPoint].position;
        }
    }
    private void ReversePoint(int destPoint) 
    {
        if (destPoint == _wayPoint.Count) _reverse = true;
        if (destPoint == 0) _reverse = false;
    }
        
}

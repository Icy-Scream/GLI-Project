using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AI : MonoBehaviour
{
    [SerializeField] List<Transform> _wayPoint;
    [SerializeField]private AIState currentState;
    Animator _animator;
    private int destPoint = 0;
    NavMeshAgent _agent;
    bool _reverse = false;
    bool _isAttacking = false;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>(); 
    }
    void Start()
    {
        _agent.autoBraking = false;
        GoToNextPoint();
    }

    void Update()
    {
        if (Keyboard.current.eKey.isPressed) 
        {
            currentState = AIState.jumping;
            _agent.isStopped = true;
        }
        if (_agent.remainingDistance < 0.5f && !_isAttacking)
            currentState = AIState.attacking;
        switch (currentState)
        { 
            case AIState.walking:
                _agent.isStopped = false;
                if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
                    GoToNextPoint();
                break;
            case AIState.jumping:
                Debug.Log("JUMPING");
                break;
            case AIState.attacking:
                if(!_isAttacking)
                StartCoroutine(AttackRoutine());
                break;
        };
        
    }
    IEnumerator  AttackRoutine() 
    {
        _isAttacking = true;
        _animator.SetBool("Attack", true);
        Debug.Log("Attack");
        yield return new WaitForSeconds(3f);
        currentState = AIState.walking;
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("Attack", false);
        _isAttacking = false;
    }

    private void GoToNextPoint() 
    {
        
        if (_wayPoint.Count == 0) return;
        ReversePoint(destPoint);
        GetPoint();        
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
    private enum AIState { walking, jumping, patroling,attacking,death }
}

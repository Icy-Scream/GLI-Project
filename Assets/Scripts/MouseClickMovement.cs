using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClickMovement : MonoBehaviour
{
  
    [SerializeField]LayerMask _mask;
    GameActions input;
    Vector3 movetowards;
    Vector3 mousePosition;
    float distance = 1;
    private void Awake()
    {
        input = new GameActions();
    }

    private void OnEnable()
    {
        input.Player.Enable();
        input.Player.ChangeColor.performed += MoveObject;
    }

    private void MoveObject(InputAction.CallbackContext context)
    {
        Ray _ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(_ray, out RaycastHit _hit, Mathf.Infinity, _mask))
        {
            mousePosition = _hit.point;
            Vector3 currentPosition = transform.position;
            movetowards = (mousePosition - currentPosition).normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,mousePosition) > .7f) 
        {
            Move();  
        }
        
       
    }

    private void Move() 
    {
      transform.Translate(new Vector3(movetowards.x, 0, movetowards.z) * 5f * Time.deltaTime);
    }

}

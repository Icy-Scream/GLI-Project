using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClickMovement : MonoBehaviour
{
  
    [SerializeField]LayerMask _mask;
    Vector3 movetowards;
    float distance;
    // Update is called once per frame
    void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Mouse.current.rightButton.isPressed) 
        {
            if (Physics.Raycast(_ray,out RaycastHit _hit, Mathf.Infinity, _mask)) 
            {
                Vector3 floorPosition = _hit.point;
                Vector3 currentPosition = transform.position;
                movetowards = floorPosition - currentPosition;
                transform.Translate(new Vector3(movetowards.x, 0, movetowards.z).normalized * 5f * Time.deltaTime);
           

            }
        }
       
    }
}

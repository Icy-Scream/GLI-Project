using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed) 
        {

            Ray _ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if(Physics.Raycast(_ray,out RaycastHit _hit,Mathf.Infinity, 1<<6)) 
            {
                _hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        
        
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeColor : MonoBehaviour
{
    private GameActions _input;
    Ray ray;
    RaycastHit hit;
    private void Awake()
    {
        _input = new GameActions();
    }


    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.ChangeColor.performed += ChangeColor_performed;
    }

    private void ChangeColor_performed(InputAction.CallbackContext obj)
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray,out hit)) 
        {
            bool test = hit.transform.GetComponent<MeshFilter>().mesh.ToString() == "Sphere Instance (UnityEngine.Mesh)";
            if (test) return;
            hit.transform.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}

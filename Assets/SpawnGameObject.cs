using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnGameObject : MonoBehaviour
{
    private GameActions _input;
    private Ray _ray;
    [SerializeField] GameObject _spawnObject;

    private void Awake()
    {
        _input = new GameActions();
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.ChangeColor.performed += ChangeColor_performed;
    }

    private void ChangeColor_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if(Physics.Raycast(_ray,out RaycastHit _rayCastHit))
        {
            Vector3 spawn = new Vector3(_rayCastHit.point.x,_rayCastHit.point.y + 1,_rayCastHit.point.z);

                Instantiate(_spawnObject,spawn, Quaternion.identity);
           
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrick : MonoBehaviour
{
   private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb == null) { Debug.Log("Missing Rigidbody"); return; }
        if(Physics.Raycast(transform.position, Vector3.down,1f, 1<<8)) 
        {
            _rb.useGravity = false;
            _rb.isKinematic = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.down * 1f);
    }
}

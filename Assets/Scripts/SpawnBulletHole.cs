using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBulletHole : MonoBehaviour
{
    Ray _ray;
    bool _canFire = true;
    [SerializeField]LayerMask _mask;
    [SerializeField] GameObject _bulletHole;
    private void FixedUpdate()
    {
        _ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (Mouse.current.leftButton.isPressed && _canFire) 
        {
            _canFire = false;
            Firing();
            StartCoroutine(FiringCoolDownRoutine());
        }
        
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(_ray);
    }

   private void Firing() 
    {
        if (Physics.Raycast(_ray, out RaycastHit _hit,Mathf.Infinity,_mask))
        {
            if (_hit.transform.CompareTag("Wall"))
                Instantiate(_bulletHole, new Vector3(_hit.point.x, _hit.point.y, _hit.point.z + -0.01f), Quaternion.LookRotation(_hit.normal));
            if (_hit.transform.CompareTag("Floor"))
                Instantiate(_bulletHole, new Vector3(_hit.point.x, _hit.point.y + 0.01f, _hit.point.z + -0.01f), Quaternion.LookRotation(_hit.normal));
            Debug.Log("Hit");
        }

    }

    IEnumerator FiringCoolDownRoutine() 
    {
        yield return new WaitForSeconds(0.1f);
        _canFire = true;
    }
}

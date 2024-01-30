using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTargetScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layer;
    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layer))
        {
            transform.position = raycastHit.point;
        }
    }
}

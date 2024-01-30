using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BuildManagerScript : MonoBehaviour
{
    [SerializeField] private bool inBuildMode = false;

    private float mouseX = 0;
    private float mouseY = 0;
    private void Update()
    {
        if (inBuildMode)
        {
            StartCoroutine(SendMousePosition());
        }
    }

    private IEnumerator SendMousePosition()
    {
        yield return new WaitForSeconds(2);    
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        Debug.Log($"{mouseX}, {mouseY}");
    }
}










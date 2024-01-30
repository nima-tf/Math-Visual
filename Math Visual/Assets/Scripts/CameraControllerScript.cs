using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraControllerScript : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 10.0f; 
    private float totalRun= 1.0f;
    private void LateUpdate()
    {
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0){ // only move while a direction key is pressed
            
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * cameraSpeed;
            
            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
   
        }
        
    }
    
    private Vector3 GetBaseInput() { 
        //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}

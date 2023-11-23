using System;
using UnityEngine;

public class Math : MonoBehaviour
{
    [Header("Vector Object Refs")]
    public Transform refA;
    public Transform refB;
    
    [Header("Info")] 
    public float scalarProjection;
    public Vector2 vectorProjection;

    private void DrawArrow(Vector2 from, Vector2 to, Color color)
    {
            Gizmos.color = color;
            Gizmos.DrawLine(from, to);
            Gizmos.DrawSphere(to, 0.1f);
    }

    private void OnDrawGizmos()
    {
        Vector2 a = refA.position;
        Vector2 b = refB.position;

        DrawArrow(transform.position, a, Color.red);
        DrawArrow(transform.position, b, Color.blue);
        
        // Scalar Projection
        Vector2 aNorm = a.normalized;
        scalarProjection = Vector2.Dot(aNorm, b);

        // Vector Projection
        vectorProjection = aNorm * scalarProjection;
        
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, vectorProjection);
        Gizmos.DrawSphere(vectorProjection ,0.05f);
    }
    
    // 1.Create a radial trigger - no collider use
    // 2.create a bouncing laser - no reflect function use, use raycast
    // 3.vector transformation - local to world coordinate function and a world to local function
}

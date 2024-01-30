using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;

public class BeltScript : MonoBehaviour
{
    [SerializeField] private Transform beltStart;
    [SerializeField] private Transform beltEnd;
    [FormerlySerializedAs("spline")] [SerializeField] private SplineContainer beltSpline;
    [SerializeField] private Transform itemRef;
    [SerializeField] private float transferPercent = 0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        var startKnot = beltSpline.Spline.ToArray()[0];
        var endKnot = beltSpline.Spline.ToArray()[1];
        
        startKnot.Position = beltStart.localPosition;
        startKnot.Rotation = Quaternion.Inverse(beltSpline.transform.rotation);
        endKnot.Position = beltEnd.localPosition;
        endKnot.Rotation = Quaternion.Inverse(beltSpline.transform.rotation);
        beltSpline.Spline.SetKnot(0, startKnot);
        beltSpline.Spline.SetKnot(1, endKnot);
        
        // var pos = beltSpline.EvaluatePosition(transferPercent);
        // itemRef.position = pos;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoTest : MonoBehaviour
{
    public GameObject Start,End;

    public AnimationCurve HeightCurve;
    public AnimationCurve RotationCurve;
    public float Height = 4;
    public float Spin = 360;
    public GameObject Target;
    [Range(0,1)]
    public float Value;


    private void OnDrawGizmos()
    {        
        Gizmos.color = Color.yellow;

        Vector3 pos, lastpos = Start.transform.position;
        for (float i = 0; i <= 1; i+=0.025f)
        {
            pos = Vector3.Lerp(Start.transform.position, End.transform.position, i);
            pos.y = pos.y+ HeightCurve.Evaluate(i) * Height;
            Gizmos.DrawLine(lastpos,pos);
            lastpos = pos;
        }
    }

    private void OnDrawGizmosSelected()
    {
        
        
    }


    private void OnValidate()
    {
        Vector3 pos = GetPos(Value);
        Vector3 lastPos = GetPos(Value - 0.1f);

        Target.transform.position = pos;

        Target.transform.rotation =
            Quaternion.AngleAxis(RotationCurve.Evaluate(Value) * Spin, pos - lastPos)*
            Quaternion.LookRotation(pos-lastPos);
    }

    private Vector3 GetPos(float value)
    {
        var pos = Vector3.Lerp(Start.transform.position, End.transform.position, value);

        pos.y += HeightCurve.Evaluate(value) * Height;
        return pos;
    }
}

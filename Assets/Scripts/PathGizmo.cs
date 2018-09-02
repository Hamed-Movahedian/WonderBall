using System.ComponentModel;
using UnityEngine;

internal class PathGizmo
{
    private readonly JumpBlock _jumpBlock;
    private readonly float _step=0.05f;

    public PathGizmo(JumpBlock jumpBlock)
    {
        _jumpBlock = jumpBlock;
    }

    [Description("test")]
    public void DrawPath(Vector3 startPos, Vector3 endPos, float radious)
    {
        Vector3 lastPos = startPos;
        float delta = _step / Vector3.Distance(startPos, endPos);
        float value = 0;

        while (value<=1)
        {
            value += delta;

            // set position
            Vector3 pos = Vector3.Lerp(startPos, endPos, value);

            // set height
            pos.y += _jumpBlock.HeightCurve.Evaluate(value) * _jumpBlock.Height;

            // set spin
            float spin = _jumpBlock.SpinCurve.Evaluate(value);

            DrawLine(lastPos,  pos, spin,radious);

            lastPos = pos;
        }
    }

    private void DrawLine(Vector3 lastPos,  Vector3 pos, float spin, float radious)
    {
        if (radious>0.1)
        {
            Gizmos.color=Color.grey;

            Vector3 v = Quaternion.AngleAxis(spin * 360, Vector3.forward) * Vector3.right * radious;

            Gizmos.DrawLine(pos+ v,pos- v
            );
        }
        else
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawLine(lastPos,pos);
        }
    }
}
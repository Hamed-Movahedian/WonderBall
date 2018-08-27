using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : Block
{
    public AnimationCurve HeightCurve=AnimationCurve.Linear(0,0,1,0);
    public AnimationCurve SpinCurve= AnimationCurve.Linear(0, 0, 1,1);
    public int Distance = 4;
    public float Height = 3;
    public float Speed = 10;


    private PathGizmo _pathGizmo;

    private void OnDrawGizmos()
    {
        DrawGizmos(0);
    }
    private void OnDrawGizmosSelected()
    {
        DrawGizmos(0.4f);
    }


    private void DrawGizmos(float radious)
    {
        if (_pathGizmo == null)
            _pathGizmo = new PathGizmo(this);

        if (BallController.Instance == null)
            throw new Exception("Ball controller not found !!!");


        float z = transform.position.z + Distance;

        for (int x = -3; x <= 3; x++)
            if (IsBlockIn(x, z))
                _pathGizmo.DrawPath(transform.position, new Vector3(x, 0, z), radious);
    }

    private bool IsBlockIn(int x, float z)
    {
        return Physics.Raycast(
            new Vector3(x, 10, z), 
            Vector3.down,
            100,
            BallController.Instance.Mask
            );
    }
}

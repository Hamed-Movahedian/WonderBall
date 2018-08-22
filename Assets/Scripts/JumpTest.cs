using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTest : MonoBehaviour
{
    public JumpController JumpController;
    public float JumpDistance = 6;
    public float JumpHeight = 4;
    public AnimationCurve JumpCurve;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(JumpController.Jump(JumpCurve, JumpDistance, JumpHeight));
    }

 
}

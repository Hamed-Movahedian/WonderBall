using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public IEnumerator Jump(AnimationCurve curve, float distance, float height)
    {
        var startPos = transform.position;


        while (transform.position.z <= startPos.z + distance)
        {

            var position = transform.position;

            var passedDistance = position.z - startPos.z;

            var up = curve.Evaluate(passedDistance / distance) ;

            position.y = startPos.y + up * height;

            transform.position = position;

            yield return null;
        }

    }
}

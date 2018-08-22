using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Block : MonoBehaviour
{
    public int i;
    private void OnValidate()
    {
    }

    private void Update()
    {
        if (Application.isPlaying==false && transform.hasChanged)
        {
            var position = transform.position;
            position.x = Mathf.RoundToInt(position.x);
            position.y = Mathf.RoundToInt(position.y);
            position.z = Mathf.RoundToInt(position.z);
            transform.position = position;

        }
    }

}

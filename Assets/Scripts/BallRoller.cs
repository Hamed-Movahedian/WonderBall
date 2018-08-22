using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoller : MonoBehaviour
{
    private Vector3 _lastPos;
    public float Speed=1;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        transform.Rotate(new Vector3(
            (transform.position.z-_lastPos.z)*Speed,
            0,
            0));
	    _lastPos = transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    public Transform Ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var position = transform.position;
	    position.z = Ball.position.z;
        position.x = Ball.position.x / 1.5f;
	    transform.position = position;
	}
}

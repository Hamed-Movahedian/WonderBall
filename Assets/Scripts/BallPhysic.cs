using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysic : MonoBehaviour
{
    public Vector3 MaxVelocity;

    //[HideInInspector]
    public Vector3 Velocity;

    private Vector3 _force;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	    Velocity += _force * Time.deltaTime;

	    Velocity.x = Mathf.Min(Velocity.x, MaxVelocity.x);
	    Velocity.x = Mathf.Max(Velocity.x, -MaxVelocity.x);

	    Velocity.y = Mathf.Min(Velocity.y, MaxVelocity.y);
	    Velocity.y = Mathf.Max(Velocity.y, -MaxVelocity.y);

	    Velocity.z = Mathf.Min(Velocity.z, MaxVelocity.z);
	    Velocity.z = Mathf.Max(Velocity.z, -MaxVelocity.z);

	    transform.position += Velocity * Time.deltaTime;

        _force=Vector3.zero;
	}

    public void AddForce(Vector3 force)
    {
        _force += force;
    }
}

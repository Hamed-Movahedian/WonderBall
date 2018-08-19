using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundZone : MonoBehaviour
{
    public Vector3 Velocity = new Vector3(0, -20, 0);

    private void OnTriggerEnter(Collider other)
    {
        var ballPhysic = other.gameObject.GetComponent<BallPhysic>();
        if (ballPhysic != null)
        {
            ballPhysic.Velocity = new Vector3(0,-ballPhysic.Velocity.magnitude,0);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

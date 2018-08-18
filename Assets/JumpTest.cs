using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTest : MonoBehaviour
{
    public Vector3 Force=new Vector3(0,100,0);

    private void OnTriggerEnter(Collider other)
    {
        var ballPhysic = other.gameObject.GetComponent<BallPhysic>();
        if(ballPhysic!=null)
            ballPhysic.AddForce(Force);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

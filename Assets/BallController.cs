using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Radious=1;
    public Vector3 Force=new Vector3(50,100,100);
    public float AirResistent=10;
    public LayerMask Mask;
    private BallPhysic _ballPhysic;

    // Use this for initialization
    void Start()
    {
        _ballPhysic = GetComponent<BallPhysic>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(transform.position, Vector3.down);

        RaycastHit hitInfo;

        // ************* Check under Ball
        if (Physics.Raycast(ray, out hitInfo, Radious,Mask))
        {
            transform.position = hitInfo.point + Vector3.up * Radious;
            _ballPhysic.Velocity.y = 0;

            // ******************* Forward move
            _ballPhysic.Velocity.z = Force.z;
        }
        else
        {
            //_ballPhysic.Velocity.z-= _ballPhysic.Velocity.z*AirResistent*Time.deltaTime;
            //_ballPhysic.Velocity.y = Mathf.Min(_ballPhysic.Velocity.y ,- _ballPhysic.Velocity.z);
            //_ballPhysic.Velocity.z = 0;
            _ballPhysic.AddForce(Vector3.down * Force.y);
        }



    }
}

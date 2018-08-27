using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region Instance

    private static BallController _instance;

    public static BallController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<BallController>();
            return _instance;
        }
    }

    #endregion

    public float Radious = 1;
    public Vector3 Force = new Vector3(50, 100, 100);
    public LayerMask Mask;
    public bool IsGounded = false;
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
        if (Physics.Raycast(ray, out hitInfo, Radious, Mask))
        {
            transform.position = hitInfo.point + Vector3.up * Radious;

            if(_ballPhysic.Velocity.y<0)
                _ballPhysic.Velocity.y = 0;

            // ******************* Forward move
            _ballPhysic.Velocity.z = Force.z;

            IsGounded = true;
        }
        else
        {
            IsGounded = false;

            if (transform.position.y - Radious*1.5 < 0)
                _ballPhysic.Velocity.Set(0, -_ballPhysic.MaxVelocity.y, 0);
            else
                _ballPhysic.AddForce(Vector3.down * Force.y);
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoller : MonoBehaviour
{
    private Vector3 _lastDelta;
    private float _lastTime;
    private Vector3 _lastPos = Vector3.zero;
    public float Speed=1;

    // Use this for initialization
	void Start () {
        _lastPos = transform.position;

    }

    // Update is called once per frame
    void Update ()
	{

        if (PlayerController.Instance.ForwardPlayerController.enabled)
        {
            var delta = (transform.position - _lastPos);

            transform.Rotate(new Vector3(delta.z, 0, -delta.x) * Speed, Space.World);

            _lastDelta = delta;
            _lastTime = Time.time;
        }
        else
        {
            transform.Rotate(new Vector3(_lastDelta.z, 0, -_lastDelta.x) * Speed, Space.World);

            _lastDelta = Vector3.Lerp(_lastDelta, Vector3.zero, (Time.time-_lastTime)/40);
        }

        
        _lastPos = transform.position;
	}
}

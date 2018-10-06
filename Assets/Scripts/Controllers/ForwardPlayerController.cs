 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardPlayerController : MonoBehaviour
{
    public LayerMask Mask;
    public float Speed = 2;
    public float FallingSpeed;
    public float LoseDelay;

    private Ray _ray = new Ray(Vector3.zero,Vector3.down);
    private RaycastHit _hitInfo;
    private bool _isGrounded;
    private Vector3 _groundPoint;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Check is any block under player
        CheckGround();

        // get player position
        var position=transform.position;

        // there is a block under player
        if(_isGrounded)
        {
            position.y = _groundPoint.y;
            position.z += Speed * Time.deltaTime;
        }
        else // there is no block under player
        {
            position.y -= FallingSpeed * Time.deltaTime;
            PlayerController.Instance.PlayerHorizontalController.enabled = false;
            GameController.Instance.Lose(LoseDelay);
        }

        // set player position
        transform.position = position;
	}

    private void CheckGround()
    {
        _ray.origin = transform.position+ Vector3.up * 10;

        _isGrounded = Physics.Raycast(_ray, out _hitInfo, 1000, Mask);

        if (_isGrounded)
            _groundPoint = _hitInfo.point;
    }
}

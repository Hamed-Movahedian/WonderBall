using System;
using System.Collections;
using System.Collections.Generic;
using Blocks;
using UnityEngine;

[ExecuteInEditMode]
public class JumpBlock : Block
{
    public Transform PlaceHolder;
    public Animator Animator;
    private bool _isPlaying=false;

    private void OnTriggerEnter(Collider other)

    {
        if (_isPlaying == false)
            StartCoroutine(JumpCoroutine());

    }

    private IEnumerator JumpCoroutine()
    {
        // play animation
        _isPlaying = true;
        Animator.SetTrigger("Run");

        // pass a frame
        yield return null;
        yield return null;
        
        // disable player forward movement
        PlayerController.Instance.ForwardPlayerController.enabled = false;

        // save player rotation
        var playerRotation = PlayerController.Instance.ModleTransform.rotation;

        // save z delta
        var zDelta = PlayerController.Instance.transform.position.z - PlaceHolder.position.z;



        // ****************  Set player position and rotation during play time
        var playerTransform = PlayerController.Instance.transform;
        while (_isPlaying)
        {
            // set player position
            var playerPos = playerTransform.position;

            playerPos.y = PlaceHolder.position.y;
            playerPos.z = PlaceHolder.position.z + zDelta;

            playerTransform.position = playerPos;

            // set player rotation
            //PlayerController.Instance.ModleTransform.rotation = PlaceHolder.rotation;

            yield return null;
        }

        // enable player forward movement
        PlayerController.Instance.ForwardPlayerController.enabled = true;

        // set player previous rotation
        PlayerController.Instance.ModleTransform.rotation = playerRotation;

    }
    public void EndPlay()
    {
        _isPlaying = false;
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            PlayerController.Instance.transform.position = PlaceHolder.position;
            PlayerController.Instance.ModleTransform.rotation = PlaceHolder.rotation;

        }
    }

}

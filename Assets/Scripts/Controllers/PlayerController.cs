using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _playerController;
    public static PlayerController Instance
    {
        get
        {
            if (_playerController == null)
                _playerController = FindObjectOfType<PlayerController>();

            if (_playerController == null)
                throw new System.Exception("Player controller doesn't exist!!!");

            return _playerController;
        }
    }

    public PlayerHorizontalController PlayerHorizontalController;
    public ForwardPlayerController ForwardPlayerController;
    public Transform ModleTransform;
    public GameObject DeadEffect;


    public bool IsPlayer(GameObject go)
    {
        return go == gameObject;
    }

    public void Explode(float delay)
    {
        ModleTransform.gameObject.SetActive(false);
        DeadEffect.SetActive(true);

        ForwardPlayerController.enabled=false;
        PlayerHorizontalController.enabled=false;

        GameController.Instance.Lose(delay);
    }
}

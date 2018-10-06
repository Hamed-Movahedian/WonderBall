using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Barrier : MonoBehaviour
{
    public float Delay=2;
    public UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerController.Instance.IsPlayer(other.gameObject))
        {
            PlayerController.Instance.Explode(Delay);
            OnEnter.Invoke();
        }
    }
}

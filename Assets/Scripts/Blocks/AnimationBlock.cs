using UnityEngine;
using UnityEngine.Events;

namespace Blocks
{
    [RequireComponent(typeof(SphereCollider),typeof(Animator))]
    public class AnimationBlock : Block
    {
        public UnityEvent OnEnter;

        private void OnTriggerEnter(Collider other)
        {
            if (PlayerController.Instance.IsPlayer(other.gameObject))
                OnEnter.Invoke();
        }


    }
}

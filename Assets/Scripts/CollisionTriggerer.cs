using UnityEngine;
using UnityEngine.Events;

namespace Blocks
{
    public class CollisionTriggerer : MonoBehaviour
    {
        public UnityEvent OnEnter;
        public UnityEvent OnExit;

        private void OnTriggerEnter(Collider other)
        {
            if (PlayerController.Instance.IsPlayer(other.gameObject))
                OnEnter.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (PlayerController.Instance.IsPlayer(other.gameObject))
                OnExit.Invoke();
        }


    }
}

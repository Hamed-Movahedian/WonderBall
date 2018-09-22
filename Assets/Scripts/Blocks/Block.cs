using UnityEngine;

namespace Blocks
{
    [ExecuteInEditMode]
    public class Block : MonoBehaviour
    {
        private void Update()
        {
            if (Application.isPlaying==false && transform.hasChanged)
            {
                OnTransformChanged();
            }
        }

        protected virtual void OnTransformChanged()
        {
            var position = transform.position;
            position.x = Mathf.RoundToInt(position.x);
            position.y = Mathf.RoundToInt(position.y);
            position.z = Mathf.RoundToInt(position.z);
            transform.position = position;
        }
    }
}

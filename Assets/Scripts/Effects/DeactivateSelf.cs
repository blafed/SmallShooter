using UnityEngine;

namespace SmallShooter.Effects
{
    public class DeactivateSelf : MonoBehaviour
    {
        public float time = .5f;

        private void OnEnable()
        {
            CancelInvoke();
            Invoke(nameof(Disable), time);
        }

        void Disable()
        {
            gameObject.SetActive(false);
        }


    }
}
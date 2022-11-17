using Source.Player;
using UnityEngine;

namespace Source.Obstacles
{
    public class Hive : MonoBehaviour
    {
        [SerializeField] private bool up;
        [SerializeField] private LayerMask playerLayer;

        private void OnTriggerEnter(Collider other)
        {
            var obj = other.gameObject;
            if ((playerLayer.value & (1 << obj.layer)) > 0)
            {
                var view = other.GetComponent<PlayerView>();
                if (up)
                {
                    view.UpSize();
                }
                else
                {
                    view.DownSize();
                }
                Destroy(this.gameObject);
            }
        }
    }
}

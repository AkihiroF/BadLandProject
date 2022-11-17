using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Obstacles
{
    public class Saw : MonoBehaviour
    {
        [SerializeField] private LayerMask layerPlayer;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Interact");
            var point = other.gameObject;
            if ((layerPlayer.value & (1 << point.layer)) > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}

using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Source.Obstacles
{
    public class Gear : MonoBehaviour
    {
        [SerializeField] private float timeRotate;
        private Transform body;
        
        private void OnEnable()
        {
            body = GetComponent<Transform>();
            StartAnimation();
        }
        
        private void StartAnimation()
        {
            body.rotation = new Quaternion(0, 0, 0, 0);
            body.DORotate(new Vector3(0, 0, 360), timeRotate);
            StartCoroutine(WaitAnimation());
        }

        private IEnumerator WaitAnimation()
        {
            yield return new WaitForSeconds(timeRotate);
            StartAnimation();
        }
    }
}

using UnityEngine;

namespace Source.Player
{
   public class PlayerMovementComponent : MonoBehaviour
   {
      [SerializeField] private float speedMove;
      [SerializeField] private float speedUp;
      [SerializeField] private float speedRotation;
      private Rigidbody2D _rb;
      private bool _isWakeUp = false;
      private bool _isWakeRight = false; 
      private bool _isWakeLeft = false;
      
      
      private void OnEnable()
      {
         _rb = GetComponent<Rigidbody2D>();
      }
      
      public void WakeUp(float value)
      {
         _isWakeUp = value != 0f;
      }

      public void WakeRight(float value)
      {
         _isWakeRight = value != 0f;
      }

      public void WakeLeft(float value)
      {
         _isWakeLeft = value != 0f;
      }

      private void FixedUpdate()
      {
         if (_isWakeUp)
         {
            _rb.AddForce(Vector2.up * speedUp, ForceMode2D.Impulse);

            if (transform.rotation.z > 0)
            {
               _rb.AddTorque(-transform.eulerAngles.z * speedRotation * Time.deltaTime);
            }

            if (transform.rotation.z < 0)
            {
               _rb.AddTorque(transform.eulerAngles.z * speedRotation * Time.deltaTime);
            }
         }

         if (_isWakeLeft)
         {
            _rb.AddForce(Vector2.left*speedMove, ForceMode2D.Impulse);
         }

         if (_isWakeRight)
         {
            _rb.AddForce(Vector2.right*speedMove, ForceMode2D.Impulse);
         }
      }
   }
}

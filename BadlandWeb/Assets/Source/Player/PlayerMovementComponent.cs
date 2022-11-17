using UnityEngine;

namespace Source.Player
{
   public class PlayerMovementComponent : MonoBehaviour
   {
      [SerializeField] private float speedMove;
      [SerializeField] private float speedUp;
      [SerializeField] private float speedRotation;
      [SerializeField] private float maxSpeedMove;
      [SerializeField] private float maxSpeedUp;
      private Rigidbody _rb;
      private bool _isWakeUp = false;
      private bool _isWakeRight = false; 
      private bool _isWakeLeft = false;
      private Vector3 _forceRotation;
      
      
      private void OnEnable()
      {
         _rb = GetComponent<Rigidbody>();
         _forceRotation = (speedRotation * Mathf.Deg2Rad) * _rb.inertiaTensor;
         Debug.Log(_forceRotation);
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
         if (_rb.velocity.x > maxSpeedMove)
         {
            _rb.velocity = new Vector2(maxSpeedMove, _rb.velocity.y);
         }

         if (_rb.velocity.x < -maxSpeedMove)
         {
            _rb.velocity = new Vector2(-maxSpeedMove, _rb.velocity.y);
         }

         if (_rb.velocity.y > maxSpeedUp)
         {
            _rb.velocity = new Vector2(_rb.velocity.x, maxSpeedUp);
         }
         
         if (_isWakeUp)
         {
            _rb.AddForce(Vector2.up * speedUp, ForceMode.Impulse);
            if (transform.eulerAngles.z > 180)
            {
               _rb.AddTorque(_forceRotation, ForceMode.Impulse);
            }

            if (transform.eulerAngles.z < 180)
            {
               _rb.AddTorque(-_forceRotation, ForceMode.Impulse);
            }
         }

         if (_isWakeLeft)
         {
            _rb.AddForce(Vector2.left*speedMove, ForceMode.Impulse);
         }

         if (_isWakeRight)
         {
            _rb.AddForce(Vector2.right*speedMove, ForceMode.Impulse);
         }
      }
   }
}

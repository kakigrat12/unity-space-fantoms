using UnityEngine;

namespace Character_Controller
{
    public sealed class SmoothCharacterMovement : CharacterMovement
    {
        private const float MinSpeed = 0f;
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float accelerationInSeconds = 1f;
        [SerializeField] private float deccelerationInSeconds = 1f;
        private Vector3 _lastDirectionMove;

        public override void FixedUpdate()
        {
            SmoothMove();
            Vector3 directionMove = Input.GetDirectionMove();
            if (directionMove != Vector3.zero)
                _lastDirectionMove = directionMove;

            Move(_lastDirectionMove);
            //base.FixedUpdate();
        }

        private void SmoothMove()
        {
            CurrentSpeed = Mathf.Lerp(CurrentSpeed, 
                IsMovement ? maxSpeed : MinSpeed, 
                IsMovement ? accelerationInSeconds * Time.fixedDeltaTime : deccelerationInSeconds * Time.fixedDeltaTime);
            CurrentSpeed = Mathf.Clamp(CurrentSpeed, MinSpeed, maxSpeed);
        }
    }
}
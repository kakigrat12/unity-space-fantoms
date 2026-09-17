using UnityEngine;

namespace Character_Controller
{
    /// <summary>
    /// Main object of the character controller required to move.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public sealed class CharacterMover : MonoBehaviour, IPlayer
    {
        private CharacterController _characterController;
        public bool IsGrounded => _characterController.isGrounded;
        public Vector3 velocity;

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _characterController.Move(velocity * Time.deltaTime);
        }

        /// <summary>
        /// Reset velocity on ground
        /// </summary>
        public void GroundZeroY()
        {
            velocity.y = 0f;
        }
    }
}
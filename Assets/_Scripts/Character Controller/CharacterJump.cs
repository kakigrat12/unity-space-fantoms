using Character_Controller.Character_Inputs.Jump;
using Character_Controller.Static;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Character_Controller
{
    public sealed class CharacterJump : MovementState
    {
        private const float JumpMultiplier = -2.0f;
        private IInputJump _input;
        
        [SerializeField] private float jumpHeight = 1.0f;

        public void Awake()
        {
            _input = new DesktopJump();
            _input.Subscribe(Jump);
        }

        private void OnDisable()
        {
            _input.UnSubscribe(Jump);
        }

        /// <summary>
        /// Jump
        /// </summary>
        /// <param name="obj">Action callback</param>
        private void Jump(CallbackContext obj)
        {
            if (!CharacterMover.IsGrounded) return;
            
            CharacterMover.GroundZeroY();
            CharacterMover.velocity.y += Mathf.Sqrt(jumpHeight * JumpMultiplier * PhysicStaticData.GravityValue);
        }
    }
}
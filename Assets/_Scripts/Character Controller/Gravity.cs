using Character_Controller.Static;
using UnityEngine;

namespace Character_Controller
{
    public sealed class Gravity : MovementState
    {
        [SerializeField] private float gravityScale;

        private void Update()
        {
            if (CharacterMover.IsGrounded) return;
            
            CharacterMover.velocity.y += PhysicStaticData.GravityValue * gravityScale * Time.deltaTime;
        }
    }
}
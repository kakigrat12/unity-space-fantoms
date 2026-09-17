using Character_Controller.Character_Inputs.Walk;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Character_Controller
{
    public class CharacterMovement : MovementState
    {
        protected Transform CharacterTransform => CharacterMover.transform;
        protected IInputWalk Input;
        public float CurrentSpeed { get; set; } = 5f;
        public bool IsMovement => Input.GetDirectionMove() != Vector2.zero;
        
        public void Awake()
        {
            Input = new DesktopWalk();
        }

        public virtual void FixedUpdate()
        {
            Move(Input.GetDirectionMove());
        }

        protected virtual void Move(Vector2 localDirection)
        {
            var moveDirection2D = localDirection.normalized * CurrentSpeed;
            var moveDirection3D = new Vector3(moveDirection2D.x, 0f, moveDirection2D.y);
            moveDirection3D = CharacterTransform.rotation * moveDirection3D;
            CharacterMover.velocity.x = moveDirection3D.x;
            CharacterMover.velocity.z = moveDirection3D.z;
        }
    }
}
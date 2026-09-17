using UnityEngine.InputSystem;

namespace Character_Controller.Character_Inputs.Jump
{
    public sealed class DesktopJump : InputJumpBase
    {
        public override void PressButton(InputAction.CallbackContext obj)
        {
            InputJump.Game.Jump.WasPerformedThisFrame();
        }
    }
}
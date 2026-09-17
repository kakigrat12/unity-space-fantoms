using UnityEngine;

namespace Character_Controller.Character_Camera_Inputs.MouseMove
{
    public class DesktopMouseMove : InputMouseMoveBase
    {
        public override Vector2 GetDirectionMouseMove() => InputMouseMove.Game.MoveCamera.ReadValue<Vector2>();
    }
}
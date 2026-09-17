using UnityEngine;

namespace Character_Controller.Character_Inputs.Walk
{
    public sealed class DesktopWalk : InputWalkBase
    {
        public override Vector2 GetDirectionMove() => InputWalk.Game.Walk.ReadValue<Vector2>();
    }
}
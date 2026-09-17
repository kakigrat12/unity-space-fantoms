using Character_Controller.Static;
using UnityEngine;

namespace Character_Controller.Character_Inputs.Walk
{
    public abstract class InputWalkBase : IInputWalk
    {
        public CharacterControllerInputScheme InputWalk { get; } = InputsStaticData.CharacterControllerInputScheme.Input;
        public abstract Vector2 GetDirectionMove();
    }
}
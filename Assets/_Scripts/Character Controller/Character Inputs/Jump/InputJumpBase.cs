using System;
using Character_Controller.Static;
using UnityEngine.InputSystem;

namespace Character_Controller.Character_Inputs.Jump
{
    public abstract class InputJumpBase : IInputJump
    {
        public CharacterControllerInputScheme InputJump { get; } = InputsStaticData.CharacterControllerInputScheme.Input;
        public void Subscribe(Action<InputAction.CallbackContext> action) => InputJump.Game.Jump.performed += action;

        public void UnSubscribe(Action<InputAction.CallbackContext> action) => InputJump.Game.Jump.performed -= action;

        public abstract void PressButton(InputAction.CallbackContext obj);
    }
}
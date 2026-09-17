using System;
using UnityEngine.InputSystem;

namespace Character_Controller.Character_Inputs.Jump
{
    public interface IInputJump
    {
        public CharacterControllerInputScheme InputJump { get; }
        public void Subscribe(Action<InputAction.CallbackContext> action);
        public void UnSubscribe(Action<InputAction.CallbackContext> action);
    }
}
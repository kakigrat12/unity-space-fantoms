using Character_Controller.Static;
using UnityEngine;

namespace Character_Controller.Character_Camera_Inputs.MouseMove
{
    public abstract class InputMouseMoveBase : IInputMouseMove
    {
        public CameraControllerInputScheme InputMouseMove { get; } = InputsStaticData.CameraControllerInputScheme.Input;
        public abstract Vector2 GetDirectionMouseMove();
    }
}
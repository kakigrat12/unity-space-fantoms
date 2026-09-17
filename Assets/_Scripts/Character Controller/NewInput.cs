using System;
using UnityEngine.InputSystem;

namespace Character_Controller
{
    public sealed class NewInput<T> : IDisposable where T : IInputActionCollection, new()
    {
        public NewInput()
        {
            Bind();
        }

        private void Bind()
        {
            Input = new T();
            Input.Enable();
        }

        public T Input { get; private set; }

        public void UnBind() => Input.Disable();

        public void Dispose()
        {
            UnBind();
            if (Input is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
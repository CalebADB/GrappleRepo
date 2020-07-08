using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class MouseKeyboardInput : MonoBehaviour
    {
        void Update()
        {
            VirtualInputManager.Instance.cursorX = Input.mousePosition.x / 32;
            VirtualInputManager.Instance.cursorY = Input.mousePosition.y / 32;

            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.left = true;
            }
            else
            {
                VirtualInputManager.Instance.left = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.right = true;
            }
            else
            {
                VirtualInputManager.Instance.right = false;
            }
            if (Input.GetKey(KeyCode.W))
            {
                VirtualInputManager.Instance.up = true;
            }
            else
            {
                VirtualInputManager.Instance.up = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                VirtualInputManager.Instance.down = true;
            }
            else
            {
                VirtualInputManager.Instance.down = false;
            }
        }
    }
}

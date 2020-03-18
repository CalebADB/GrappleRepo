using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class KeyboardInput : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.moveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.moveLeft = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.moveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.moveRight = false;
            }
//          if (!Input.GetKey(KeyCode.LeftShift))
//          {
//              VirtualInputManager.Instance.run = true;
//          }
//          else
//          {
//              VirtualInputManager.Instance.run = false;
//          }
        }
    }
}

using System;
using UnityEngine;

namespace BaseStackController.StackController
{
    public class TestController: StackControllerBase_AFRF
    {
        [SerializeField] private int id;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AddStack();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                RemoveStack();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RemoveStackWithId(id);
            }
        }
    }
}
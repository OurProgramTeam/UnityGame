using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Menu : MonoBehaviour
    {

        public void StartGame()
        {
            Application.LoadLevel(1);
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}

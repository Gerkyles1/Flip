using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProces
{
    public class Pause : MonoBehaviour
    {
        public static bool pause = false;

        public void ChangePauseMod()
        {
            pause = !pause;
        }
    }
}
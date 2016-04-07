﻿using UnityEngine;
using System.Collections;

namespace Chui
{
    public class TransitionScene : MonoBehaviour
    {
        public void IntroButton()
        {
            LevelLoader.LoadLevel("Intro");
        }

        public void CombatButton()
        {
            LevelLoader.LoadLevel("Combat");
        }

        public void ExitButton()
        {
            LevelLoader.LoadLevel("Exit");
        }
    }
}
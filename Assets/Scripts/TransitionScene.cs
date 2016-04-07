using UnityEngine;
using System.Collections;

namespace chui
{
    public class TransitionScene : MonoBehaviour
    {
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
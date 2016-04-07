using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

namespace Chui
{
    /// <summary>
    /// Pass in string to load new level.
    /// </summary>
    public class LevelLoader : MonoBehaviour
    {
        public static void LoadLevel(string scene)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public void GameOver()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

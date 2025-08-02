using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.GameOver += GameOver;
    }

    private void OnDisable()
    {
        _health.GameOver -= GameOver;
    }

    public void GameOver()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

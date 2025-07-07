using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.ResetButtonClicked += OnResetButtonClick;
        _bird.GameOver += OnGameOver;
    }
    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.ResetButtonClicked -= OnResetButtonClick;
        _bird.GameOver -= OnGameOver;
    }


    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        
        StartGame();
    }

    private void OnResetButtonClick()
    {
        _endScreen.Close();

        StartGame();
    }

    private void StartGame()
    {
        _pipeGenerator.Reset();

        Time.timeScale = 1.0f;

        _bird.Reset();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;

        _endScreen.Open();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Target;
    public Text ScoreText;
    public Text LivesText;
    public int Score { get; set; }

    private void Awake()
    {
        Brick.OnBrickDestruction += OnBrickDestruction;
        BrickManager.OnLevelLoaded += OnLevelLoaded;
        GameManager.OnLiveLost += OnLiveLost;
    }

    private void Start()
    {
        OnLiveLost(GameManager.Instance.AvailibleLives);
    }

    private void OnLiveLost(int remainingLives)
    {
        LivesText.text = $"LIVES: {remainingLives}";
    }

    private void OnLevelLoaded()
    {
        UpdateRemainingBricksText();
        UpdateScoreText(0);
    }

    private void UpdateScoreText(int increment)
    {
        this.Score += increment;
        string scoreString = this.Score.ToString().PadLeft(1, '0');
        ScoreText.text = $@"SCORE: 
    {scoreString}";
    }

    public void OnBrickDestruction(Brick obj)
    {
        UpdateRemainingBricksText();
        UpdateScoreText(10);
    }

    private void UpdateRemainingBricksText()
    {
        Target.text = $@"TARGET:
{ BrickManager.Instance.RemainingBricks.Count} / { BrickManager.Instance.InitialBricksCount}";
    }

    private void OnDisable()
    {
        Brick.OnBrickDestruction -= OnBrickDestruction;
        BrickManager.OnLevelLoaded -= OnLevelLoaded;
    }
}

using System;
using UnityEngine;

public class GameOverScreen : Screen
{
    public event Action RestartGameButtonClick;

    private void Start()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

    protected override void OnButtonClick()
    {
        RestartGameButtonClick?.Invoke();
    }
}
using System;
using UnityEngine;

public class StartScreen : Screen
{
    public event Action PlayButtonClick;

    private void Start()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
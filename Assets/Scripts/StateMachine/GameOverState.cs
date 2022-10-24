using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : IState
{
    public string Name => "GameOverState";

    public void Start()
    {
        UiManager.instance.GameOverUi.rootVisualElement.visible = true;
        GameManager.instance.resetRounds();
    }

    public void Stop()
    {
        UiManager.instance.GameOverUi.rootVisualElement.visible = false;
    }

    public void Update()
    {
        
    }
}

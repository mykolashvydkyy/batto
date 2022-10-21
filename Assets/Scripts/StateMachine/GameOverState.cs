using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : IState
{
    public string Name => "GameOverState";

    public void Start()
    {
        UiManager.instance.GameOverUi.enabled = true;
    }

    public void Stop()
    {
        UiManager.instance.GameOverUi.enabled = false;
    }

    public void Update()
    {
        
    }
}

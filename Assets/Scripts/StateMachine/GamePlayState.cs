using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : IState
{
    public string Name => "GamePlayState";

    public void Start()
    {
        UiManager.instance.GamePlayUi.rootVisualElement.visible = true;
        GameManager.instance.StartRound();
    }

    public void Stop()
    {
        UiManager.instance.GamePlayUi.rootVisualElement.visible = false;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EventsManager.instance.events.InvokePlayerReaction();
        }
    }
}

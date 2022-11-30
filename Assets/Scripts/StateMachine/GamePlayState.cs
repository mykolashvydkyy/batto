using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : IState
{
    public string Name => "GamePlayState";
    private bool _clicked = false;

    public void Start()
    {
        UiManager.instance.GamePlayUi.rootVisualElement.visible = true;
    }

    public void Stop()
    {
        UiManager.instance.GamePlayUi.rootVisualElement.visible = false;
    }

    public void Update()
    {
        if (!_clicked && Input.GetMouseButtonDown(0))
        {
            EventsManager.instance.events.InvokePlayerReaction();
            _clicked = true;
            Debug.Log("Clicked");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameState : IState
{
    public string Name => "WinGameState";

    public void Start()
    {
        UiManager.instance.WinUi.rootVisualElement.visible = true;
    }

    public void Stop()
    {
        UiManager.instance.WinUi.rootVisualElement.visible = false;
    }

    public void Update()
    {

    }
}

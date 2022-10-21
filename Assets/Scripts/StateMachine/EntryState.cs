using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryState : IState
{
    public string Name => "EntryState";

    public void Start()
    {
        UiManager.instance.EntryUi.rootVisualElement.visible = true;
    }

    public void Stop()
    {
        UiManager.instance.EntryUi.rootVisualElement.visible = false;
    }

    public void Update()
    {
        
    }
}

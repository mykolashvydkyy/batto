public class WinRoundState : IState
{
    public string Name => "WinRoundState";

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


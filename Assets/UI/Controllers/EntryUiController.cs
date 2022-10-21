using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EntryUiController : MonoBehaviour
{
    public Button _startButton;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _startButton = root.Q<Button>("StartButton");
        _startButton.clicked += OnStart;
    }

    private void OnStart()
    {
        GameManager.instance.StartRound();
    }
}

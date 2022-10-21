using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WinUiController : MonoBehaviour
{
    private Label _myReactionLabel;
    private Label _enemyReactionLabel;
    private Button _nextBattleButton;
   
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _myReactionLabel = root.Q<Label>("MyReaction");
        _enemyReactionLabel = root.Q<Label>("EnemyReaction");
        _nextBattleButton = root.Q<Button>("NextBattle");
        _nextBattleButton.clicked += OnNextBattle;
    }

    private void OnNextBattle()
    {
        GameManager.instance.StartRound();
    }

    public void SetData()
    {
        var playerReaction = ReactionManager.instance.PlayerReaction == float.MaxValue
            ? 0
            : ReactionManager.instance.PlayerReaction;
        _myReactionLabel.text = $"Your Reaction: {playerReaction} s";
        _enemyReactionLabel.text = $"Enemy Reaction: {ReactionManager.instance.EnemyReaction.ToString("F2")} s";
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReactionManager : MonoBehaviour
{
    private float _enemyReaction;
    private float _playerReaction;
    private bool _waitForReaction;

    private bool _playerReacted;
    private bool _enemyReacted;
    private List<float> _playerReactions = new List<float>();

    public float EnemyReaction => _enemyReaction;
    public float PlayerReaction => _playerReaction;

    public float FastestReaction => _playerReactions.Min();
    public float SlowestReaction => _playerReactions.Max();
    public float AverageReaction => _playerReactions.Average();

    public static ReactionManager instance;

    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        EventsManager.instance.events.Signal.AddListener(OnSignal);
        EventsManager.instance.events.PlayerReaction.AddListener(OnPlayerReaction);
        EventsManager.instance.events.EnemyReaction.AddListener(OnEnemyReaction);
        EventsManager.instance.events.EnemyAttackFinish.AddListener(OnEnemyAttackFinish);
        
    }

    private void OnDisable()
    {
        EventsManager.instance.events.Signal.RemoveListener(OnSignal);
        EventsManager.instance.events.PlayerReaction.RemoveListener(OnPlayerReaction);
        EventsManager.instance.events.EnemyReaction.RemoveListener(OnEnemyReaction);
        EventsManager.instance.events.EnemyAttackFinish.RemoveListener(OnEnemyAttackFinish);
    }

    // Update is called once per frame
    void Update()
    {
        if (_waitForReaction)
        {
            if (!_playerReacted)
                _playerReaction += Time.deltaTime;

            if (!_enemyReacted)
                _enemyReaction += Time.deltaTime;

            if (_playerReacted && _enemyReacted)
            {
                _waitForReaction = false;
                _playerReactions.Add(_playerReaction);
                if (_enemyReaction >= _playerReaction)
                {
                    EventsManager.instance.events.InvokeEnemyDie();
                }
                else
                {
                    EventsManager.instance.events.InvokePlayerDie();
                }
            }
        }
    }

    public void ResetStatistic()
    {
        _playerReactions.Clear();
    }

    private void OnSignal()
    {
        _waitForReaction = true;
    }

    private void OnPlayerReaction()
    {
        if (_waitForReaction)
        {
            _playerReacted = true;
        }
        else
        {
            _waitForReaction = false;
            EventsManager.instance.events.InvokeEnemyCounter();
        }
    }

    private void OnEnemyReaction()
    {
        _enemyReacted = true;
    }

    private void OnEnemyAttackFinish()
    {
        if (_playerReacted) return;

        _playerReaction = float.MaxValue;
        _playerReacted = true;
    }

    public void ResetManager()
    {
        _enemyReaction = 0;
        _playerReaction = 0;
        _enemyReacted = false;
        _playerReacted = false;
        _waitForReaction= false;
    }
}

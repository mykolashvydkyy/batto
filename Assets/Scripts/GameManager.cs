using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInput _player;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private EnemySo[] _enemies;
    private GameObject _enemy;

    private Vector3 _enemyPosition = new Vector3(50, -30);

    public static GameManager instance;
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
        EventsManager.instance.events.PlayerDie.AddListener(OnPlayerDead);
        EventsManager.instance.events.EnemyDie.AddListener(OnPlayerWinRound);
    }

    private void OnDisable()
    {
        EventsManager.instance.events.PlayerDie.RemoveListener(OnPlayerDead);
        EventsManager.instance.events.EnemyDie.RemoveListener(OnPlayerWinRound);
    }

    // Start is called before the first frame update
    void Start()
    {
        StateMachine.instance.Init(new EntryState());
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.instance.State.Update();
    }

    public void StartRound()
    {
        StateMachine.instance.ChangeState(new GamePlayState());
        ReactionManager.instance.ResetManager();
        _player.Reset();
        SignalManager.instance.StartWaiting();
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (_enemy is not null)
        {
            Destroy(_enemy);
            _enemy = null;
        }
        _enemy = Instantiate(_enemyPrefab, _enemyPosition, Quaternion.identity);
        _enemy.GetComponentInChildren<Enemy>().Init(_enemies[0]);
    }

    private void OnPlayerDead()
    {
        UiManager.instance.SetWinData();
        StartCoroutine(DelayAction(() => StateMachine.instance.ChangeState(new GameOverState())));
    }

    private void OnPlayerWinRound()
    {
        UiManager.instance.SetWinData();
        StartCoroutine(DelayAction(() => StateMachine.instance.ChangeState(new WinRoundState())));
    }

    private IEnumerator DelayAction(Action action)
    {
        yield return new WaitForSeconds(2f);
        action();
    }
}

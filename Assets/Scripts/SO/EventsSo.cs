using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Events", menuName = "SO/Events")]
public class EventsSo : ScriptableObject
{
    private UnityEvent _signal;
    private UnityEvent _playerReaction;
    private UnityEvent _enemyReaction;
    private UnityEvent _playerDie;
    private UnityEvent _enemyDie;
    private UnityEvent _enemyAttackFinish;
    private UnityEvent _enemyCounter;

    public UnityEvent Signal => _signal;
    public UnityEvent PlayerReaction => _playerReaction;
    public UnityEvent EnemyReaction => _enemyReaction;
    public UnityEvent PlayerDie => _playerDie;
    public UnityEvent EnemyDie => _enemyDie;
    public UnityEvent EnemyAttackFinish => _enemyAttackFinish;
    public UnityEvent EnemyCounter => _enemyCounter;

    private void OnEnable()
    {
        _signal = new UnityEvent();
        _playerReaction = new UnityEvent();
        _enemyReaction = new UnityEvent();
        _playerDie = new UnityEvent();
        _enemyDie = new UnityEvent();
        _enemyAttackFinish = new UnityEvent();
        _enemyCounter = new UnityEvent();
    }

    public void InvokeSignal() => _signal.Invoke();
    public void InvokePlayerReaction() => _playerReaction.Invoke();
    public void InvokeEnemyReaction() => _enemyReaction.Invoke();
    public void InvokeEnemyDie() => _enemyDie.Invoke();
    public void InvokePlayerDie() => _playerDie.Invoke();
    public void InvokeEnemyAttackFinish() => _enemyAttackFinish.Invoke();
    public void InvokeEnemyCounter() => _enemyCounter.Invoke();
}

using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class Enemy : MonoBehaviour
{
    public EnemySo EnemySo;

    private float _reactionTime;
    private float _timer;
    private bool _react;
    private Animator _animator;
    private AudioSource _audio;

    [SerializeField] private TMP_Text enemyName;
    
    private void OnEnable()
    {
        EventsManager.instance.events.Signal.AddListener(OnSignal);
        EventsManager.instance.events.EnemyDie.AddListener(OnDie);
        EventsManager.instance.events.EnemyCounter.AddListener(OnCounter);
    }

    private void OnDisable()
    {
        EventsManager.instance.events.Signal.RemoveListener(OnSignal);
        EventsManager.instance.events.EnemyDie.RemoveListener(OnDie);
        EventsManager.instance.events.EnemyCounter.RemoveListener(OnCounter);
    }

    public void Init(EnemySo enemySo)
    {
        EnemySo = enemySo;
        _reactionTime = Random.Range(EnemySo.MinReaction, EnemySo.MaxReaction);
        enemyName.text = EnemySo.Name;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_react)
        {
            _timer += Time.deltaTime;
            if (_timer >= _reactionTime)
            {
                _react = false;
                EventsManager.instance.events.InvokeEnemyReaction();
                _animator.SetTrigger("Attack");
                _audio.Play();
            }
        }
    }

    private void OnSignal() 
    {
        _react = true;
    }

    private void OnDie()
    {
        _animator.SetTrigger("Death");
    }

    private void OnCounter()
    {
        _animator.SetTrigger("Counter");
        EventsManager.instance.events.InvokePlayerDie();
    }

    // Animation events
    private void EnemyAttackFinish()
    {
        EventsManager.instance.events.InvokeEnemyAttackFinish();
    }
}

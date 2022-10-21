using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audio;
    private Vector2 _initialPosition = new Vector2(-50, -30);

    public GameObject ImpactPrefab;

    private void OnEnable()
    {
        EventsManager.instance.events.PlayerDie.AddListener(OnDie);
        EventsManager.instance.events.PlayerReaction.AddListener(OnPlayerReaction);
    }

    private void OnDisable()
    {
        EventsManager.instance.events.PlayerDie.RemoveListener(OnDie);
        EventsManager.instance.events.PlayerReaction.RemoveListener(OnPlayerReaction);
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponentInParent<AudioSource>();
    }

    
    private void OnPlayerReaction()
    {
        _animator.SetTrigger("Attack");
        _audio.Play();
    }

    private void OnDie()
    {
        _animator.SetTrigger("Death");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(ImpactPrefab, transform.position, Quaternion.identity);
        }
    }

    public void Reset()
    {
        _animator.SetTrigger("Idle");
        transform.position = _initialPosition;
    }
}

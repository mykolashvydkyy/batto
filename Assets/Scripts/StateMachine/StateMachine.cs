using UnityEngine;

public class StateMachine: MonoBehaviour
{
    private IState _state;
    public IState State => _state;

    public static StateMachine instance;

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

    public void Init(IState initialState)
    {
        _state = initialState;
        _state.Start();
    }

    public void ChangeState(IState nextState)
    {
        if (_state.Name == nextState.Name) return;

        _state.Stop();
        _state = nextState;
        _state.Start();
    }

    private void Update()
    {
        _state.Update();
    }
}

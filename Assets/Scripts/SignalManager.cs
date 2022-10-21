using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalManager : MonoBehaviour
{
    private float _startTime = 5f;

    private float _endTime = 20f;

    private float _signalTime = 0;

    private float _timer;

    private bool _isWaiting;

    public GameObject SignalPrefab;

    public static SignalManager instance;

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

    // Update is called once per frame
    void Update()
    {
        if (_isWaiting)
        {
            _timer += Time.deltaTime;
            if (_timer >= _signalTime)
            {
                ShowSignal();
            }
        }
    }

    public void StartWaiting()
    {
        _signalTime = Random.Range(_startTime, _endTime);
        _isWaiting = true;
        _timer = 0;
    }

    public void ShowSignal()
    {
        Debug.Log("NOW!!!");
        Instantiate(SignalPrefab, Vector3.zero, Quaternion.identity);
        EventsManager.instance.events.InvokeSignal();
        _isWaiting = false;
    }
}

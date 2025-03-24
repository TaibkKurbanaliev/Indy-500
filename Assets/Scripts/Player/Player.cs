using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnPlayerFinished;
    public int CurrentLap { get; private set; } = 0;
    private bool _checkPointReached = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CheckPoint _))
        {
            _checkPointReached = true;
        }
        if (collision.TryGetComponent(out Finish _))
        {
            if (_checkPointReached)
            {
                CurrentLap++;
                _checkPointReached = false;
                OnPlayerFinished();
            }
        }
    }
}

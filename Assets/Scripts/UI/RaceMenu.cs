using System;
using TMPro;
using UnityEngine;

public class RaceMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _lap;
    [SerializeField] private float _countOfLaps;

    private void Awake()
    {
        _player.OnPlayerFinished += OnPlayerFinished;
    }

    private void OnPlayerFinished()
    {
        _lap.text = _player.CurrentLap.ToString();
    }
}

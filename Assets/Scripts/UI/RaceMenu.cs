using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class RaceMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _lap;
    [SerializeField] private TMP_Text _time;
    [SerializeField] private float _countOfLaps;

    private void Awake()
    {
        _player.OnPlayerFinished += OnPlayerFinished;
        StartCoroutine("ChangeTime");
    }

    private IEnumerator ChangeTime()
    {
        while (true)
        {
            _time.text = ((int)Time.timeSinceLevelLoad / 60).ToString() + ":" + ((int)Time.timeSinceLevelLoad % 60).ToString();
            yield return new WaitForSeconds(1);
        }

    }
    private void OnPlayerFinished()
    {
        _lap.text = _player.CurrentLap.ToString();
    }


}

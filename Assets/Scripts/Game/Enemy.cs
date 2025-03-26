using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _wayContainer;

    private List<GameObject> _wayPoints;

    private void Awake()
    {
        var points = _wayContainer.GetComponentsInChildren<GameObject>();
    }

    private void Move()
    {

    }
}

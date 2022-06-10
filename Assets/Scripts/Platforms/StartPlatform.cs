using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _BallSpawnPoint;

    private void Awake()
    {
        Instantiate(_ball, _BallSpawnPoint.position, Quaternion.identity);
    }
}

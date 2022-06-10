using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private float _additionalScale = 3f;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startAndFinishAditionalScale = 0.5f;
    public float BeamScaleY => _levelCount / 2f + _startAndFinishAditionalScale + _additionalScale / 2;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);
        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;
        
        SpawnPlatform(_startPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition,
                beam.transform);
        }
        
        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 position, Transform parent)
    {
        Instantiate(platform, position, Quaternion.Euler(platform.transform.rotation.x, Random.Range(0, 360), 0), parent);
        position.y -= 1;
    }
}
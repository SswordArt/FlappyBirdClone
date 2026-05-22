using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxtime = 1.5f;
    [SerializeField] private float _HeightRange = 0.50f;
    [SerializeField] private GameObject _Pipe;

    private float _Time;
    void Start()
    {
        SpawnPipe();
    }
    private void Update()
    {
        if (_Time > _maxtime)
        {
            SpawnPipe();
            _Time = 0f;
        }
        _Time += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        float spawnY = 1.8f + Random.Range(-_HeightRange, _HeightRange);
        Vector3 SpawnPos = transform.position + new Vector3(4, spawnY);
        GameObject Pipe = Instantiate(_Pipe, SpawnPos, Quaternion.identity);
        Destroy(Pipe, 10f);
    }

}

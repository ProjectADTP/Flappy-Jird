using System.Collections;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);

        StartCoroutine(GeneratePipes());
    }

    private IEnumerator GeneratePipes()
    {
        while (enabled)
        {
            Spawn();

            yield return _wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);

        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Pipe pipe = _pool.GetObject();

        pipe.gameObject.SetActive(true);
        pipe.transform.position = spawnPoint;
    }

    public void Reset()
    {
        _pool.Reset();
    }
}

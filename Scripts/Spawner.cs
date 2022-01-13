using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private Vector2 _spawnPosition;

    private float _minXPosition = -5f;
    private float _maxXPosition = 5f;
    private float _randomXPosition;
    private float _launchSpawn = 1f;
    private float _repeatSpawn = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(Respawn), _launchSpawn, _repeatSpawn);
    }

    private void Respawn()
    {
        _randomXPosition = Random.Range(_minXPosition - 3, _maxXPosition + 3);
        _spawnPosition = new Vector2(_randomXPosition, _coin.transform.position.y);
        Instantiate(_coin, _spawnPosition, transform.rotation);
    }
}

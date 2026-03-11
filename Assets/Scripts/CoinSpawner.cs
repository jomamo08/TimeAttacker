using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnDelay = 5f;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private bool coinExists = false;

    void Start()
    {
        SpawnCoin();
    }

    void SpawnCoin()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Vector2 spawnPos = new Vector2(x, y);

        GameObject coin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);

        coin.GetComponent<Coin>().spawner = this;

        coinExists = true;
    }

    public void CoinCollected()
    {
        coinExists = false;
        StartCoroutine(SpawnAfterDelay());
    }

    IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnCoin();
    }
}
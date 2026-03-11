using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinSpawner spawner;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Timer timer = FindObjectOfType<Timer>();
            timer.AddTime(4f);

            spawner.CoinCollected();

            Destroy(gameObject);
        }
    }
}
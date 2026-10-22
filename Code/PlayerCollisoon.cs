using UnityEngine;

public class PlayerCollisoon : MonoBehaviour
{
    private GameQL gameQL;
    private AudioManager audioManager;
    private void Awake()
    {
        gameQL = FindAnyObjectByType<GameQL>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            audioManager.PlayCoinSound();
            gameQL.Addscore(1);
            
        }
        else if (collision.CompareTag("Trap"))
        {
            gameQL.GameOver();
            
        }
        else if (collision.CompareTag("Enemy"))
        {
            gameQL.GameOver();

        }
        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            gameQL.GameWin();

        }
    }
}

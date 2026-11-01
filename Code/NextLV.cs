using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLV : MonoBehaviour
{
    public string TenManChs;
    public void LoadManChoi()
    {
        SceneManager.LoadScene(TenManChs);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadManChoi();
        }
    }
}

using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthManager.Instance.currentHealth = 0;
            AudioManager.Instance.PlayUIEffectSound("GameOver");
            UIManager.Instance.Invoke("OpenLoseMenu", 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}

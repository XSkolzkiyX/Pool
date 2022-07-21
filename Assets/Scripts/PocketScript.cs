using UnityEngine;
using UnityEngine.SceneManagement;

public class PocketScript : MonoBehaviour
{
    public Transform balls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") { Destroy(collision.gameObject); SceneManager.LoadScene(0); }
        else if (collision.tag == "Ball")
        {
            Destroy(collision.gameObject);
            if (balls.childCount <= 1) SceneManager.LoadScene(0);
        }
    }
}

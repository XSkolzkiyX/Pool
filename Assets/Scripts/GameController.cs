using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Rigidbody2D mainBall;
    public LineRenderer lineRenderer;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    lineRenderer.enabled = true;
                    Vector3[] arr = new Vector3[2];
                    arr[0] = new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
                    arr[1] = mainBall.transform.position;
                    lineRenderer.SetPositions(arr);
                    break;
                case TouchPhase.Ended:
                    lineRenderer.enabled = false;
                    mainBall.AddForce(new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x - mainBall.transform.position.x, Camera.main.ScreenToWorldPoint(touch.position).y - mainBall.transform.position.y), ForceMode2D.Impulse);
                    break;
            }
            //if (touch.phase == TouchPhase.Ended) mainBall.AddForce(Camera.main.ScreenToWorldPoint(touch.position) - mainBall.transform.position, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D curBall = collision.GetComponent<Rigidbody2D>();
        curBall.velocity = new Vector2(-curBall.velocity.x, -curBall.velocity.y);
    }
}

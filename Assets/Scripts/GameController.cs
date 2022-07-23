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
                    RaycastHit2D hit = Physics2D.CircleCast(mainBall.transform.position, mainBall.transform.localScale.x, new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x - mainBall.transform.position.x, Camera.main.ScreenToWorldPoint(touch.position).y - mainBall.transform.position.y));
                    //RaycastHit2D hit = Physics2D.Raycast(mainBall.transform.position, new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x - mainBall.transform.position.x, Camera.main.ScreenToWorldPoint(touch.position).y - mainBall.transform.position.y));
                    if (hit.collider)
                    {
                        //Debug.Log(hit.transform.name);
                        if (hit.transform.tag == "Ball")
                        {
                            lineRenderer.positionCount = 3;
                            lineRenderer.SetPositions(new Vector3[] { mainBall.transform.position, hit.point, hit.transform.position * 1.5f});
                        }
                        else
                        {
                            lineRenderer.positionCount = 2;
                            lineRenderer.SetPositions(new Vector3[] { hit.point, mainBall.transform.position });
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    lineRenderer.enabled = false;
                    mainBall.AddForce(new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x - mainBall.transform.position.x, Camera.main.ScreenToWorldPoint(touch.position).y - mainBall.transform.position.y), ForceMode2D.Impulse);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D curBall = collision.GetComponent<Rigidbody2D>();
        curBall.velocity = new Vector2(-curBall.velocity.x, -curBall.velocity.y);
    }
}
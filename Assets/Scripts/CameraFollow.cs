using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector2 followOffset;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 3f;
    private Vector2 treshold;
    private Rigidbody2D rb;

    void Start()
    {
        treshold = CalculateThreshold();
        rb = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 follow = player.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;

        if (Mathf.Abs(xDifference) >= treshold.x)
        {
            newPosition.x = follow.x;
        }

        if (Mathf.Abs(yDifference) >= treshold.y)
        {
            newPosition.y = follow.y+10;
        }

        // Suavizar a transição usando Lerp
        transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
    }

    private Vector2 CalculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = CalculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;

    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        if (transform.position.y <= -24f)
        {
            transform.position = new Vector3(transform.position.x, 24f, transform.position.z);
        }
    }
}

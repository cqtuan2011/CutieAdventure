using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;

	[SerializeField] private float frequency = 20f;

	[SerializeField] private float magnitude = 0.5f;

	[SerializeField] private GameObject[] wayPoints;

	private bool facingRight = true;

	private Vector3 pos, localScale;

	// Use this for initialization
	void Start()
	{
		pos = transform.position;

		localScale = transform.localScale;
	}

	// Update is called once per frame
	void Update()
	{
		CheckWhereToFace();

		if (facingRight)
			MoveRight();
		else
			MoveLeft();
	}

	void CheckWhereToFace()
	{
		if (Vector2.Distance(pos,wayPoints[0].transform.position) < 0.2f)
			facingRight = true;

		else if (Vector2.Distance(pos, wayPoints[1].transform.position) < 0.2f)
			facingRight = false;

        if (((facingRight) && (localScale.x > 0)) || ((!facingRight) && (localScale.x < 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

	void MoveRight()
	{
		pos += transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

	void MoveLeft()
	{
		pos -= transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

}

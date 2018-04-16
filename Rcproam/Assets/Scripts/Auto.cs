using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Auto : MonoBehaviour 
{
	Rigidbody2D rb;
	SpriteRenderer sr;
	public int rotation;
	public bool accel;

	public float steerSpeed;
	public float maxSpeed;
	public float acceleration;

	public Sprite[] sprites;

	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = 0;
		rb.freezeRotation = true;
	}
		
	[HideInInspector]public float currentSpeed;
	void Update () 
	{
		rotation = (int)DegreeNormalization (rotation);
		sr.flipX = rotation > 180;
		sr.sprite = sprites[rotation * sprites.Length / 360];

		if (accel)
			currentSpeed += maxSpeed * acceleration * Time.deltaTime;
		else
			currentSpeed -= maxSpeed * acceleration * Time.deltaTime;

		currentSpeed = Mathf.Clamp (currentSpeed, 0, maxSpeed);
	}

	void FixedUpdate()
	{
		Vector2 direction = CarDirection() * currentSpeed;
		rb.velocity = direction;
	}

	Vector2 CarDirection()
	{
		return new Vector2 (Mathf.Sin (rotation * Mathf.Deg2Rad), Mathf.Cos (rotation * Mathf.Deg2Rad)); 
	}
	float DegreeNormalization(float degree)
	{
		if (degree < 0)
			return DegreeNormalization (360 + degree);
		if (degree >= 360)
			return DegreeNormalization (degree - 360);
		return degree;
	}
}

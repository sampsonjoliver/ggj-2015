using UnityEngine;
using System.Collections;

public class Grabbable : MonoBehaviour
{
	private SpriteRenderer sprite;
	
	// Use this for initialization
	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
	}
	
	public void SetColor(Color color)
	{
		this.sprite.color = color;
	}
}

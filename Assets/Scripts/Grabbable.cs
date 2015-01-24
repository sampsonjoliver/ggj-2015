using UnityEngine;
using System.Collections;

public class Grabbable : MonoBehaviour
{
	private SpriteRenderer sprite;
	private bool isSelected = false;
	
	// Use this for initialization
	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		IsSelected (false);
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
	
	public void IsSelected(bool selected)
	{
		isSelected = selected;
		this.sprite.color = (selected ? Color.green : Color.white);
	}
}

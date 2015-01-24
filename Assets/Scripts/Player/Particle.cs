using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour
{
	private float lifetime;
	public float duration;
	public float angle;
	public float startScale = 1f;
	
	public bool modifyOpacity = true;
	public bool modifyRotate = true;
	public bool modifyVerticalScale = true;
	public bool modifyHorizontalScale = true;
	
	private SpriteRenderer renderer2D;
	
	// Use this for initialization
	void Start () {
		renderer2D = this.GetComponent<SpriteRenderer>();
		lifetime = duration;
	}
	
	// Update is called once per frame
	void Update ()
	{
		lifetime -= Time.deltaTime;
		if(lifetime <= 0)
		{
			GameObject.Destroy (this.transform.parent.gameObject);
		}
		else
		{
			float lerp = lifetime / duration;
			if(modifyRotate)
			{
				float angle = Mathf.Lerp (0, this.angle, lerp);
				this.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			}
			float scale = Mathf.Lerp (0, startScale, lerp);
			if(modifyVerticalScale)
				this.transform.localScale = new Vector3(this.transform.localScale.x, scale, 1);
			if(modifyHorizontalScale)
				this.transform.localScale = new Vector3(scale, this.transform.localScale.y, 1);
			if(modifyOpacity)
			{
				float opacity = Mathf.Lerp (0, 1, lerp);
				renderer2D.color = new Color(renderer2D.color.r, renderer2D.color.g, renderer2D.color.b, opacity);
			}		
		}
	}
}

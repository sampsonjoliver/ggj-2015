using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour
{
	private float lifetime;
	public float duration;
	public float angle;
	private float degreesPerSecond;
	
	private SpriteRenderer renderer2D;
	
	// Use this for initialization
	void Start () {
		renderer2D = this.GetComponent<SpriteRenderer>();
		lifetime = duration;
		degreesPerSecond = angle / duration;
	}
	
	// Update is called once per frame
	void Update ()
	{
		lifetime -= Time.deltaTime;
		if(lifetime <= 0)
		{
			GameObject.Destroy (this.gameObject);
		}
		else
		{
			float lerp = lifetime / duration;
			float angle = Mathf.Lerp (0, this.angle, lerp);
			float scale = Mathf.Lerp (0, 1, lerp);
			float opacity = Mathf.Lerp (0, 1, lerp);
			this.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			this.transform.localScale = Vector3.one * scale;
			renderer2D.color = new Color(1, 1, 1, opacity);
		}
	}
}

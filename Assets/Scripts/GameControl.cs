using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
	public Vector2 playerStart;
	public Player player;

	void Start ()
	{
		//player = Instantiate(player,new Vector3(playerStart.x,playerStart.y),new Quaternion()) as Player;
		//player.transform.position = playerStart;
	}
	
	void Update ()
	{
		if(Input.GetKeyDown (KeyCode.R))
		{
			player.rigidbody2D.velocity = new Vector2(0.0f,0.0f);
			player.transform.position = playerStart;
		}
	}
}

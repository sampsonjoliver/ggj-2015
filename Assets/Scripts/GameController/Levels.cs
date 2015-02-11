using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour
{
	public string nextLevel;
	public const string Level1 = "Basics";
	public const string Level2 = "JumpTutorial";
	public const string Level3 = "LeftRightTutorial";
	public const string Level4 = "ShootTutorial";
	public const string Level5 = "PickupTutorial";
    public const string Level6 = "EnemyJump";
	public const string Level7 = "SightTutorial";
	//public const string Level8 = "";
	
	public void Start()
	{
		nextLevel = Level1;
	}
}

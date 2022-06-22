using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text score;
	private  int playerScore =  0;
    public  delegate  void gameEvent();
    public  static  event  gameEvent OnPlayerDeath;

	// Singleton Pattern
	private  static  GameManager _instance;
	// Getter
	public  static  GameManager Instance
	{
		get { return  _instance; }
	}
	
	public  void  increaseScore(){
		playerScore  +=  1;
		score.text  =  "SCORE: "  +  playerScore.ToString();
	}
    public  void  damagePlayer(){
        OnPlayerDeath();
    }

	private  void  Awake()
	{
		// check if the _instance is not this, means it's been set before, return
		if (_instance  !=  null  &&  _instance  !=  this)
		{
			Destroy(this.gameObject);
			return;
		}
		
		// otherwise, this is the first time this instance is created
		_instance  =  this;
		// add to preserve this object open scene loading
		DontDestroyOnLoad(this.gameObject); // only works on root gameObjects
	}
}

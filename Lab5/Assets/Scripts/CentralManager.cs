using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CentralManager : MonoBehaviour
{
	public  GameObject gameManagerObject;
	private  GameManager gameManager;

	public GameObject spawnManagerObject;
	private SpawnManager spawnManager;

	public GameObject powerUpManagerObject;
	private PowerUpManager powerUpManager;

	public  static  CentralManager centralManagerInstance;
	
	void  Awake(){
		centralManagerInstance  =  this;
	}
	// Start is called before the first frame update
	void  Start()
	{
		gameManager  =  gameManagerObject.GetComponent<GameManager>();
		spawnManager = spawnManagerObject.GetComponent<SpawnManager>();
		powerUpManager = powerUpManagerObject.GetComponent<PowerUpManager>();
	}

	public  void  increaseScore(){
		gameManager.increaseScore();
	}

    public  void  damagePlayer(){
        gameManager.damagePlayer();
    }

	public void spawnEnemy() {
		spawnManager.spawnFromPooler(ObjectType.gombaEnemy);
	}

	public  void  consumePowerup(KeyCode k, GameObject g){
		powerUpManager.consumePowerup(k,g);
	}

	public  void  addPowerup(Texture t, int i, ConsumableInterface c){
		powerUpManager.addPowerup(t, i, c);
	}

    public void changeScene()
    {
        StartCoroutine(LoadYourAsyncScene("MarioLevel2"));
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

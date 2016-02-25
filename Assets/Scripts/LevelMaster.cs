using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelMaster : MonoBehaviour {

	public EdgeCollider2D leftWall;
	public EdgeCollider2D rightWall;
	public EdgeCollider2D topWall;
	public EdgeCollider2D bottomWall;

	public PlayerShip player;

	//HUD Objects
	public WeaponDisplay[] weaponsDisplay;
	public WeaponDisplay primaryDisplay;
	public SpriteRenderer healthBar;

	public static float timeScinceLevelStart;
	public EnemyWave startFrom;
	public EnemyWave finish;
    public Transform foreground;
	public Canvas canvas;

	public float width;
	public float height;
	public Transform pauseMenu;
	Transform pause;

	public GameObject HUD;
	public float trueTime;
	public bool paused;
	public Font font;
	public float timescale;
	public AudioSource audioRoot;
	public AudioSource music;
	public AudioClip[] musicChoices;



	public Transform gameOverScreen;
	float gameOverCooldown;
	bool gameOver;


	public void Awake() {
		GameMaster.level = this;
		Time.timeScale = 1F;
		if (GetComponentInChildren<PlayerShip> () != null) {
			player = GetComponentInChildren<PlayerShip> ();
			if (GameMaster.player != null  && GameMaster.player != player) {
				Destroy (player.gameObject);
				player = GameMaster.player;
				player.transform.parent = foreground;
				player.Begin ();
			} else {
				GameMaster.player = player;
				DontDestroyOnLoad (player);
				player.Begin ();
			}
		}
	}
	

	void Start () {
		Time.timeScale = 1;
		timeScinceLevelStart = 0f;
		Drop.adjustment = 1f;
		GameMaster.currentScore = 0;

		if (startFrom != null) {
			foreach (EnemyWave e in GetComponentsInChildren<EnemyWave>() ) {
				e.done = true;
			}
			foreach (EnemyWave e in startFrom.transform.parent.GetComponentsInChildren<EnemyWave>() ) {
				if (e.transform != startFrom.transform.parent) {
				e.done = false;
				}
			}
		}
		canvas.gameObject.SetActive (false);


		// Get the width and height of the camera (in pixels)
		float screenW = Camera.main.pixelWidth;
		float screenH = Camera.main.pixelHeight;
		
		// Create an array consisting of two Vector2 object
		Vector2[] edgePoints = new Vector2[2];
		
		// Convert screen coordinates point (0,0) to world coordinates
		Vector3 leftBottom  = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));      
		// Convert screen coordinates point (0,H) to world coordinates
		Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, screenH, 0f));      
		
		// Set the two points in the array to screen left bottom
		// and screen left top points            
		edgePoints[0] = leftBottom;
		edgePoints[1] = leftTop;
		
		// Position the left wall edge collider
		// at the left edge of the camera
		leftWall.points = edgePoints;
		
		// Convert screen coordinates point (W,0) to world coordinates
		Vector3 rightBottom = Camera.main.ScreenToWorldPoint(new Vector3(screenW, 0f, 0f));      
		// Convert screen coordinates point (W,H) to world coordinates
		Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(screenW, screenH, 0f));      
		
		// Set the two points in the array to screen right bottom
		// and screen right top points            
		edgePoints[0] = rightBottom;
		edgePoints[1] = rightTop;
		
		// Position the left wall edge collider
		// at the left edge of the camera
		rightWall.points = edgePoints;
		
		edgePoints[0] = leftBottom;
		edgePoints[1] = rightBottom;
		bottomWall.points = edgePoints;

		edgePoints [0] = leftTop;
		edgePoints [1] = rightTop;
		topWall.points = edgePoints;

		width = rightTop.x;
		height = rightTop.y;

	
	}

	public void playerKilled() {

		gameOverCooldown = 1.2f;
		gameOver = true;
	}

	public void PlaySound(AudioClip c, float v = 1f) {
		audioRoot.PlayOneShot (c,v);
	}

	void Update () {
		if (music != null && audioRoot != null) {
			if (!gameOver) {
				music.pitch = timescale;
				audioRoot.pitch = timescale;
			} else {
				music.pitch = 1;
				audioRoot.pitch = 1;
			}
		}

		if (music != null && musicChoices.Length > 0 && !music.isPlaying) {
			music.PlayOneShot(musicChoices[Random.Range(0, musicChoices.Length -1)]);
		}

		timescale = Time.timeScale;
		if (player != null) {
			healthBar.transform.localScale = new Vector3 (Mathf.Clamp (player.HP / player.MaxHP, 0, 1), 1, 1);
		}
		timeScinceLevelStart += Time.deltaTime;
		if (finish != null && finish.done && !gameOver){
			canvas.gameObject.SetActive(true);
			
			if (GameMaster.scores [GameMaster.currentLevel] < GameMaster.currentScore) {
				GameMaster.scores [GameMaster.currentLevel] = GameMaster.currentScore;
			}
			GameMaster.currentScore = 0;
		
			if (Input.GetKeyDown(KeyCode.Space)) {

			if (GameMaster.currentLevel > GameMaster.unlockedLevel) {
					GameMaster.unlockedLevel = GameMaster.currentLevel;
				}
			player.gameObject.SetActive(false);
			player.transform.parent = null;
			Application.LoadLevel("ShipMenu");
			}
		}
		if (gameOverCooldown > 0) {
			gameOverCooldown -= Time.unscaledDeltaTime;
			if (gameOverCooldown <= 0) {
				Instantiate (gameOverScreen);
			}
		}
		if (gameOver  ) {
			if ( Time.timeScale - 1F * Time.deltaTime  > 0 && Time.timeScale > 0.1f) {
			Time.timeScale = Time.timeScale - 1F * Time.deltaTime ;
			} else {
				Time.timeScale = 0;
			}
		} else if (Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape)){
			Pause();
			
		}
	}

	public void Pause() {
		if (paused == false) {
			trueTime = Time.timeScale;
			Time.timeScale =0;
			pause = Instantiate(pauseMenu);
			paused = true;
		} else {
			Time.timeScale = trueTime;
			if (pause != null) {
				Destroy(pause.gameObject);
			}
			paused = false;
			
		}
	}

	void OnGUI () {
		if (GameMaster.currentLevel > 0) {
			GUI.color = Color.black;   
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.skin.label.fontSize = 40;
			GUI.skin.label.fontStyle = FontStyle.Normal;
			GUI.skin.label.font = font;
			GUI.Label (new Rect (20, 20, 500, 100), "Score: " + GameMaster.currentScore);
		} 
	}
}

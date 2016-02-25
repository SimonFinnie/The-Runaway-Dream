using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static int currentLevel = 0;
	public static int unlockedLevel = 0;

    public static LevelMaster level;

    public static PlayerShip player;
	public static AudioSource music;

	public static int currentScore = 0;
	public static int[] scores = new int[6];
	public static int[] scoresToBeat = {
		0,
		1000,
		1700,
		3000,
		4000,
		5000
	};
    public static string[] levels = {
		"Tutorial",
        "IntroLevel",
        "ParticleTest",
		"Test3",
		"SimonsLevel",
		"ReubenBoss"
    };


	public static void Save() {
		PlayerPrefs.SetInt("RunawayDreamUnlock", unlockedLevel);
		for (int i = 0; i < scores.Length; i++) {
			PlayerPrefs.SetInt("RunawayDreamScore" + i.ToString(), scores[i]);
		}
		PlayerPrefs.Save ();
	}

	public static void Load() {
		if (CanLoad()) {
			unlockedLevel = PlayerPrefs.GetInt("RunawayDreamUnlock");
			for (int i = 0; i < scores.Length; i++) {
				scores[i] = PlayerPrefs.GetInt("RunawayDreamScore" + i.ToString());
			}
		}
	}

	public static bool CanLoad() {
		return (PlayerPrefs.HasKey("RunawayDreamUnlock") );
	}
	


	
}

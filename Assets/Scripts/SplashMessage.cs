using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashMessage : EnemyWave {

	public float fadeTime;
	public float liveTime;
	public float time;
	float alpha;
	bool advanced = false;
	public bool nonSkip;

	public Text text;
	public SpriteRenderer image;


	public override void Update ()
	{
		base.Update ();
		if (started) {
			time -= Time.deltaTime;
			if (time <= 0) {
				if (!spawnDone) {
					spawnDone = true;
					time = liveTime;
				} else if (!done) {
					done = true;
					doneTime = LevelMaster.timeScinceLevelStart;
					time = fadeTime;
				}
			}
			if (Input.GetKeyDown(KeyCode.Return) && !nonSkip) {
				if (!spawnDone && !advanced){
					advance();
				} else if (!advanced) {
					done = true;
					doneTime = LevelMaster.timeScinceLevelStart;
					time = 0;
					if (GetComponentInChildren<SplashMessage>() != null && GetComponentInChildren<SplashMessage>().transform.parent == transform) {
						doneTime -= GetComponentInChildren<SplashMessage>().delay;
						GetComponentInChildren<SplashMessage>().advanced = true;
					}
				}
			}
		}
		
		advanced = false;

		if (!started) {
			alpha = 0;
		} else if (!spawnDone) {
			alpha = Mathf.Clamp((fadeTime - time) / fadeTime, 0, 1);
		} else if (!done) {
			alpha = 1f;
		} else {
			alpha = Mathf.Clamp(time / fadeTime, 0, 1);
		}
		if (text != null) {
			text.color = new Color(text.color.r, text.color.g, text.color.b, alpha); //alpha;
		}
		if (image != null) {
			image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
		}
		

	}

	public void advance (){
		if (!advanced) {
			started = true;
			spawnDone = true;
			done = false;
			time = liveTime;
			advanced = true;
			if (partner != null && partner.GetComponent<SplashMessage> () != null) {
				partner.GetComponent<SplashMessage> ().advance ();
			}
		}
	}

	public override void begin ()
	{
		base.begin ();
		time = fadeTime;
	}


}

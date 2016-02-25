using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipMenu : MonoBehaviour {

	public string selectionName;
	public string selectionDescription;
	public PlayerShip ship;
	public Sprite emptyWeapon;
	public SpriteRenderer[] weaponDisplay;
	public SpriteRenderer primaryDisplay;
	public Sprite locked;
	public Text nameBox;
	public Text descriptionBox;
	public Text tipBox;
	Button[][] buttons;
	int i = 0;
	int j = 0;
	SpriteRenderer shipSprite;
	public SpriteRenderer highlight;

	// Use this for initialization
	void Start () {
		GameMaster.Save ();
		int count = 0;
		buttons = new Button[3][];


		ShipButton[] ships = GetComponentsInChildren<ShipButton> ();
		foreach (ShipButton b in ships) {
			if (b.IsUnlocked())
				count++;
		}
		buttons [0] = new Button[count];
		for (int i = 0,j = 0; i < ships.Length; i++) {
			if (ships [i].IsUnlocked()) {
				buttons [0] [j] = ships [i];
				ships[i].transform.position = ships[j].transform.position;
				j++;
			} else {
				ships [i].gameObject.SetActive (false);
			}
		}

		count = 0;





		WeaponButton[] w = GetComponentsInChildren<WeaponButton> ();
		foreach (WeaponButton b in w) {
			if (b.IsUnlocked())
				count++;
		}
		buttons [1] = new Button[count];
		for (int i = 0,j = 0; i < w.Length; i++) {
			if (w [i].IsUnlocked()) {
				buttons [1] [j] = w [i];
				w[i].transform.position = w[j].transform.position;
				j++;
			} else {
				w [i].gameObject.SetActive (false);
			}
		}

		count = 0;

		LevelButtons[] levels = GetComponentsInChildren<LevelButtons> ();
		foreach (LevelButtons l in levels) {
			if (l.levelNumber - 1 <= GameMaster.unlockedLevel)
				count++;
		}

		buttons [2] = new Button[count];
		for (int i = 0,j = 0; i < levels.Length; i++) {
			if (levels [i].levelNumber - 1 <= GameMaster.unlockedLevel) {
				buttons [2] [j] = levels [i];
				j++;
			} /*else {
				levels [i].gameObject.SetActive (false);
			} */
		}


		/*buttons [3] = GetComponentsInChildren<Level1Button> ();
		buttons [4] = GetComponentsInChildren<Level2Button> ();
		buttons [5] = GetComponentsInChildren<Level3Button> ();
		buttons [6] = GetComponentsInChildren<Level4Button> ();
		buttons [7] = GetComponentsInChildren<Level5Button> ();*/

		//buttons[3] = GetComponentInChildren<


		//buttons [4] = GetComponentsInChildren<StartButton> ();
		foreach (Button[] b in buttons) {
			foreach(Button bs in b) {
				bs.menuRoot = transform;
			}
		}
		foreach (SpriteRenderer r in GetComponentsInChildren<SpriteRenderer>()) {
			if (r.tag == "Player" && r.transform.GetComponent<PlayerShip> () == null) {
				shipSprite = r;
				break;
			}
		}
		buttons [0] [0].Entered ();
        if (GameMaster.player == null) {
            GameMaster.player = ship;
            Transform pa = ship.transform.parent;
            ship.transform.parent = null;
            DontDestroyOnLoad(ship.gameObject);
            ship.transform.parent = pa;
        } else {
            Destroy(ship);
            ship = GameMaster.player;
        }
		if (ship.primary == null) {
			buttons [1] [0].Clicked ();
		}
        shipSprite.sprite = ship.GetComponent<SpriteRenderer>().sprite;
        for (int i = 0; i < weaponDisplay.Length; i++) {
            if (i < ship.weapons.Length) {
                if (ship.weapons[i] != null) {
                    weaponDisplay[i].sprite = ship.weapons[i].icon;
                } else {
                    weaponDisplay[i].sprite = emptyWeapon;
                }
            } else {
                weaponDisplay[i].sprite = null;
            }
        }

		primaryDisplay.sprite = ship.primary.icon;

    }

	public void setPrimary(WeaponType weapon) {
		ship.primary = weapon;
		primaryDisplay.sprite = ship.primary.icon;
	}

	public void AddRemoveWeapon(WeaponType weapon, int pos) {
		for (int i = 0; i < ship.weapons.Length; i++) {
			if (ship.weapons[i] == weapon) {
				RemoveWeapon(i);
			} else if (i == pos) {
				ship.weapons[i] = weapon;
			}
		}
		for (int i = 0; i < weaponDisplay.Length; i ++) {
			if (i < ship.weapons.Length) {
				if (ship.weapons[i] != null) {
					weaponDisplay[i].sprite = ship.weapons[i].icon;
				} else {
					weaponDisplay[i].sprite = emptyWeapon;
				}
			} else {
				weaponDisplay[i].sprite = null;
			}
		}
	}

	public void RemoveWeapon(int i) {
		if (i < ship.weapons.Length && ship.weapons [i] != null) {
			ship.weapons[i] = null;
		}
	}

	public void SetShip(PlayerShip newShip) {
		if (ship.shipName != newShip.shipName) {
			PlayerShip ship1 = Instantiate(newShip);
			ship1.transform.position = ship.transform.position;
			ship1.transform.localScale = ship.transform.localScale;
			Destroy (ship.gameObject);
			ship = ship1;
			ship.gameObject.SetActive(false);
			shipSprite.sprite = ship.GetComponent<SpriteRenderer> ().sprite;
			primaryDisplay.sprite = ship.primary.icon;
		}
		for (int i = 0; i < weaponDisplay.Length; i ++) {
			if (i < ship.weapons.Length) {
				if (ship.weapons[i] != null) {
					weaponDisplay[i].sprite = ship.weapons[i].icon;
				} else {
					weaponDisplay[i].sprite = emptyWeapon;
				}
			} else {
				weaponDisplay[i].sprite = null;
			}
		}
        GameMaster.player = ship;
        DontDestroyOnLoad(ship.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		nameBox.text = selectionName;
		descriptionBox.text = selectionDescription;
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {			
			buttons [i] [j].Exited ();
			i = (i - 1 + buttons.Length) % buttons.Length;
			j = 0;
			buttons [i] [j].Entered ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {			
			buttons [i] [j].Exited ();
			i = (i + 1) % buttons.Length;
			j = 0;
			buttons [i] [j].Entered ();
		} else if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {			
			buttons [i] [j].Exited ();
			j = (j + 1) % buttons [i].Length;
			buttons [i] [j].Entered ();
		} else if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {			
			buttons [i] [j].Exited ();
			j = (j - 1 + buttons [i].Length) % buttons [i].Length;
			buttons [i] [j].Entered ();
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			buttons [i] [j].Clicked ();
		} else if (Input.GetKeyDown (KeyCode.BackQuote) && GameMaster.unlockedLevel < GameMaster.levels.Length - 1) {
			GameMaster.unlockedLevel++;
			Application.LoadLevel ("ShipMenu");
		} else if (Input.GetKeyDown (KeyCode.Slash) && i == 1) {
			buttons[1][j].GetComponent<WeaponButton>().Clicked(0);
		}else if (Input.GetKeyDown (KeyCode.Period) && i == 1) {
			buttons[1][j].GetComponent<WeaponButton>().Clicked(1);
		}else if (Input.GetKeyDown (KeyCode.Comma) && i == 1) {
			buttons[1][j].GetComponent<WeaponButton>().Clicked(2);
		}
		highlight.transform.position = buttons [i] [j].transform.position;
		highlight.transform.Translate (Vector3.forward);

	
	}


	
}

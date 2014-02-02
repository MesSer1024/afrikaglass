using UnityEngine;
using System.Collections;
using Afrika;

public class GameMainView : MonoBehaviour {
    private AfrikaGlass _game;

    public int SellPrice = 1900;
    public float SellChance = 0.05f;
    public int WarehouseCost = 25000;
    public int ShipmentTime = 10;

	// Use this for initialization
	void Start () {
	}

    void Awake() {
        _game = new AfrikaGlass(this);
    }
	
	// Update is called once per frame
	void Update () {
        GameData.SellPrice = SellPrice;
        GameData.SellChance = SellChance;
        GameData.WarehouseCost = WarehouseCost;
        GameData.ShipmentTime = ShipmentTime;
        _game.init();
        _game.update(Time.time);
	}
}

using UnityEngine;
using System.Collections;
using Afrika;
using System;

public class CountryComp : MonoBehaviour {
    public CountryID countryId { get; set; }
    internal Country Model {
        get { return _model; }
        set {
            _model = value;
        }
    }

    private Country _model;
    private static Texture2D _icecreamIcon;
    private static Texture2D _warehouseIcon;
	
    // Use this for initialization
	void Start () {
        countryId = getCountryID(this.name);
        if (_icecreamIcon == null) {
            _icecreamIcon = Resources.Load<Texture2D>("IceCreamIcon");
            _warehouseIcon = Resources.Load<Texture2D>("warehouse");
            Debug.Log("Loaded texture: [IceCreamIcon] success?" + (_icecreamIcon != null).ToString());
            Debug.Log("Loaded texture: [WarehouseIcon] success?" + (_warehouseIcon != null).ToString());
        }
    }
	
	// Update is called once per frame
	void Update () {
        var renderCtx = this.GetComponent<SpriteRenderer>();
        if (!Model.isPurchased) {
            float darkness = 0.25f;
            renderCtx.color = new Color(darkness, darkness, darkness, 1f);
        } else {
            if (Model.isSelected) {
                float darkness = 1f;
                renderCtx.color = new Color(darkness, darkness, darkness, 1f);
            } else {
                float darkness = 0.65f;
                renderCtx.color = new Color(darkness, darkness, darkness, 1f);
            }
        }
	}

    void OnMouseDown() {
        MessageManager.QueueMessage(new CountryClickedMessage(countryId));
        //Debug.Log("mouseDown on: " + this.name);
    }

    private CountryID getCountryID(string name) {
        switch(name) {
            case "country1":
                return CountryID.Country0_Ivorygal;
            case "country2":
                return CountryID.Country1_Libgyptia;
            case "country3":
                return CountryID.Country2_Congola;
            case "country4":
                return CountryID.Country3_Kenyopia;
            case "country5":
                return CountryID.Country4_Nambafrica;
            case "country6":
                return CountryID.Country5_Madagascar;
            case "world":
                return CountryID.World;
            default:
                throw new Exception("Unknown country clicked : " + this.name);
        }
    }

    void OnGUI() {
        if (Model.isPurchased) {
            var v = Camera.main.WorldToScreenPoint(transform.position);
            float size = 64;
            var r = new Rect(v.x - size, Screen.height - v.y - size, size, size);
            GUI.DrawTexture(r, _icecreamIcon);

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.black;
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 20;
            GUI.Label(r, Model.icecreams.ToString(), style);
        }

        if (Model.isSelected) {
            var v = Camera.main.WorldToScreenPoint(transform.position);
            float size = 64;
            var r = new Rect(v.x - size, Screen.height - v.y, size, size);
            if (GUI.Button(r, _warehouseIcon)) {
                MessageManager.QueueMessage(new WarehousePurchaseMessage(countryId));
            }

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.black;
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 20;
            GUI.Label(r, Model.warehouseSize.ToString(), style);
        }
    }
}

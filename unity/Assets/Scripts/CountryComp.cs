using UnityEngine;
using System.Collections;
using Afrika;
using System;

public class CountryComp : MonoBehaviour {
    private CountryClickedMessage.CountryID _countryId;
	
    // Use this for initialization
	void Start () {
        _countryId = getCountryID(this.name);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown() {
        MessageManager.QueueMessage(new CountryClickedMessage(_countryId));
        Debug.Log("mouseDown on: " + this.name);
    }

    private CountryClickedMessage.CountryID getCountryID(string name) {
        switch(name) {
            case "country1":
                return CountryClickedMessage.CountryID.Country0_Ivorygal;
            case "country2":
                return CountryClickedMessage.CountryID.Country1_Libgyptia;
            case "country3":
                return CountryClickedMessage.CountryID.Country2_Congola;
            case "country4":
                return CountryClickedMessage.CountryID.Country3_Kenyopia;
            case "country5":
                return CountryClickedMessage.CountryID.Country4_Nambafrica;
            case "country6":
                return CountryClickedMessage.CountryID.Country5_Madagascar;
            case "world":
                return CountryClickedMessage.CountryID.World;
            default:
                throw new Exception("Unknown country clicked : " + this.name);
        }
    }

}

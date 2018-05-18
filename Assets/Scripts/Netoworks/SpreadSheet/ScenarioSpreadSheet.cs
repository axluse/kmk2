using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSpreadSheet : MonoBehaviour {

    public Scenarios scenarios;

	void Awake () {
        StartCoroutine(SpreadSheetInit());
	}

    private IEnumerator SpreadSheetInit() {
        WWW www = new WWW("https://axluse.net/kmk2/get_scenario.php");
        yield return www;
        //Debug.Log(www.text);
        scenarios = JsonUtility.FromJson<Scenarios>(www.text);
    }
}

[Serializable] public class Scenarios {
    public List<Scenario> contents = new List<Scenario>();
}

[Serializable] public class Scenario {
    public string key;
    public string left;
    public string right;
    public string name;
    public string text;
}
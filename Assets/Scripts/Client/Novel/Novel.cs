using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Novel : MonoBehaviour {

    public ScenarioSpreadSheet scenarioSpreadSheet;
    public GameObject windowObj;
    public Text novelText;
    public GameObject nameObj;
    public Text nameText;
    public SpriteRenderer leftObj;
    public SpriteRenderer rightObj;

    [SerializeField] private int startScenarioKey = 1000101;
    [SerializeField] private int endScenarioKey  = 1000105;
    private int viewScenarioKey;
    private Queue<Scenario> scenarios = new Queue<Scenario>();

    [SerializeField] private UnityEvent callBack;

    private bool endFlag = false;

	void Start () {
        StartCoroutine(Starter());
    }

    IEnumerator Starter() {
        float waitTime = 0.0f;
        bool errorFlg = false;
        while(scenarioSpreadSheet.scenarios.contents.Count == 0) {
            yield return new WaitForSeconds(0.1f);
            waitTime += 0.1f;
            if(waitTime > 3.0f) {
                errorFlg = true;
                break;
            }
        }
        if(errorFlg) {
            Debug.LogWarning("シナリオの受信ができませんでした。");
        } else {
            // 対象scenario取得
            foreach (Scenario s in scenarioSpreadSheet.scenarios.contents) {
                Debug.Log(s.key);
                if (Int32.Parse(s.key) >= startScenarioKey && Int32.Parse(s.key) <= endScenarioKey) {
                    scenarios.Enqueue(s);
                } else if (Int32.Parse(s.key) > endScenarioKey) {
                    break;
                }
            }

            NextNovel();
        }
    }

    void NextNovel() {
        if(scenarios.Count > 0) {
            Scenario startScenario = scenarios.Dequeue();
            novelText.text = startScenario.text;
            nameText.text = startScenario.name;
            return;
        }
        callBack.Invoke();
    }

	void Update () {
        if(!endFlag) {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) {
                NextNovel();
            }
        }
	}
}

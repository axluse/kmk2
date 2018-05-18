using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugControl : MonoBehaviour {

    [SerializeField] private Transform content;
    [SerializeField] private GameObject debugText;

	void Start () {
        PushDebugLog("Debug Start");
	}

    public void PushDebugLog(string logMessage, bool system = false) {
        GameObject instance = Instantiate(debugText, Vector3.zero, Quaternion.identity);
        if(system) {
            instance.GetComponent<Text>().text = logMessage;
        } else {
            instance.GetComponent<Text>().text = "[" + System.DateTime.Now + "]  " + logMessage;
        }
        instance.transform.parent = content;
        instance.transform.localScale = new Vector3(1,1,1);
    }

	public void CommandEnter(InputField inputField) {
        string commandMessage = inputField.text;
        inputField.text = "";
        PushDebugLog(commandMessage);
        CommandLine(commandMessage);
    }

    public void SystemCommandPush(string command) {
        PushDebugLog(command);
        CommandLine(command);
    }

    public void CommandLine (string command) {
        switch (command) {
            case "exec Save":
                PushDebugLog("saving...", true);
                PushDebugLog("save completed!", true);
                break;
            case "exec Load":
                PushDebugLog("loading...", true);
                PushDebugLog("load completed!", true);
                break;
            default:
                PushDebugLog("実行されたコマンドは登録されていません", true);
                break;
        }
    }
}
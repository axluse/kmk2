using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Updater : MonoBehaviour {

    private List<GameObject> allGameObjects = new List<GameObject>();
    private bool asyncUpdateFlg = false;

    private void Start() {
        StartCoroutine(IOWhiler());
    }

    private IEnumerator IOWhiler() {
        int iteration = 0;
        while (true) {
            iteration++;
            StartCoroutine(AsyncWhilerControl());
            yield return new WaitForSeconds(0.1f);
            if (iteration >= 10) {
                StartCoroutine(AsyncInfos());
                iteration = 0;
            }
            // refresh
            while(asyncUpdateFlg) {
                yield return null;
            }
        }
    }

    private IEnumerator AsyncInfos() {
        asyncUpdateFlg = true;
        allGameObjects.Clear();
        int iteration = 0;
        foreach (GameObject g in FindObjectsOfType(typeof(GameObject))) {
            iteration++;
            allGameObjects.Add(g);
            if (iteration >= 20) {
                yield return null;
                iteration = 0;
            }
        }
        asyncUpdateFlg = false;
    }

    private IEnumerator AsyncWhilerControl() {
        int iteration = 0;
        foreach(GameObject g in allGameObjects) {
            iteration++;
            Control(g);
            if(iteration >= 10) {
                yield return null;
                iteration = 0;
            }
        }
    }

    private void Control (GameObject g) {
        ExecuteEvents.Execute<IOUpdater>(
            target: g, 
            eventData: null,  
            functor: (recieveTarget, y) => recieveTarget.OnUpdate()); 
    }
}

public interface IOUpdater : IEventSystemHandler {
    void OnUpdate();
}
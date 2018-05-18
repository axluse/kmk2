using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class info : MonoBehaviour {

    public GameObject window;
    public GameObject text;

	void Start () {
        StartCoroutine(InfoSyncer());
	}

    private IEnumerator InfoSyncer() {
        yield return new WaitForSeconds(0.2f);
        window.transform.DOMoveX(5.3f, 1.0f).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(0.2f);
        text.transform.DOMoveX(5.3f, 1.0f).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(3.4f);
        text.transform.DOMoveX(10.3f, 1.0f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(0.1f);
        window.transform.DOMoveX(10.3f, 1.0f).SetEase(Ease.InCubic);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("000_TestView");
        }
    }

}

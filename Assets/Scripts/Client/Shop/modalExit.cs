using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modalExit : MonoBehaviour {
	public void OnClick (GameObject modal) {
        modal.SetActive(false);
    }
}

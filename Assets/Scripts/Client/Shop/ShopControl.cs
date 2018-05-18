using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour {

    [SerializeField] private Transform shopContents;
    [SerializeField] private GameObject modal;
    [SerializeField] private Text playerCoinText;
    [SerializeField] private Text itemDetailText;
    [SerializeField] private GameObject shopItemObj;
    [SerializeField] private List<int> buyItemIDs = new List<int>();

    public List<Item> items = new List<Item>();

    void Start () {
		foreach(int id in buyItemIDs) {
            Item item = items[id];
            GameObject instance = Instantiate(shopItemObj, Vector3.zero, Quaternion.identity);
            instance.GetComponent<ShopItemContent>().icon = item.itemImage;
            instance.GetComponent<ShopItemContent>().itemName = item.itemName;
            instance.GetComponent<ShopItemContent>().itemDetail = item.itemDetail;
            instance.GetComponent<ShopItemContent>().itemPrice = item.itemPrice;
            instance.GetComponent<ShopItemContent>().itemDetailText = itemDetailText;
            instance.GetComponent<ShopItemContent>().modal = modal;
            instance.transform.parent = shopContents;
            instance.transform.localScale = new Vector3(1,1,1);
        }
	}

    private void Update() {
        playerCoinText.text = String.Format("{0:#,0}", PlayerData.coin);
    }
}

[Serializable] public class Item {
    public string itemName;
    public Sprite itemImage;
    [TextArea(3,3)]
    public string itemDetail;
    public int itemPrice = 100;
}

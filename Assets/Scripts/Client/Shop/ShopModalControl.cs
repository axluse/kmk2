using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopModalControl : MonoBehaviour {

    [SerializeField] private Text itemNameText;
    [SerializeField] private Text itemPriceText;
    [SerializeField] private InputField qtyField;
    [SerializeField] private Image itemIconImage;

    private int qty = 1;
    private int amount;

    [HideInInspector]
    public string itemName;
    [HideInInspector]
    public int itemPrice;
    [HideInInspector]
    public Sprite icon;

    public void OnUpdate () {
        itemIconImage.sprite = icon;
        itemNameText.text = itemName;
        itemPriceText.text = System.String.Format("{0:#,0}", itemPrice);
        amount = itemPrice;
    }

    public void OnClickAccept() {
        PlayerData.coin -= amount;
    }
	
    public void OnClickPlus() {
        ++qty;
        int lastPrice = qty * itemPrice;
        if(lastPrice <= PlayerData.coin) {
            qtyField.text = qty.ToString();
            itemPriceText.text = System.String.Format("{0:#,0}", lastPrice);
            amount = lastPrice;
        }
    }

    public void OnClickMinus() {
        --qty;
        int lastPrice = qty * itemPrice;
        if (lastPrice <= PlayerData.coin) {
            qtyField.text = qty.ToString();
            itemPriceText.text = System.String.Format("{0:#,0}", lastPrice);
            amount = lastPrice;
        }
    }

    public void OnClickOne() {
        qty = 1;
        int lastPrice = qty * itemPrice;
        if (lastPrice <= PlayerData.coin) {
            qtyField.text = qty.ToString();
            itemPriceText.text = System.String.Format("{0:#,0}", lastPrice);
            amount = lastPrice;
        }
    }

    public void OnClickMax() {
        qty = Mathf.CeilToInt( PlayerData.coin / itemPrice );
        Debug.Log(qty);
        int lastPrice = qty * itemPrice;
        if (lastPrice <= PlayerData.coin) {
            qtyField.text = qty.ToString();
            itemPriceText.text = System.String.Format("{0:#,0}", lastPrice);
            amount = lastPrice;
        }
    }

    public void OnChangeQty() {
        int cashQty = Int32.Parse(qtyField.text);
        int lastPrice = cashQty * itemPrice;
        if (lastPrice <= PlayerData.coin) {
            qty = cashQty;
            qtyField.text = qty.ToString();
            itemPriceText.text = System.String.Format("{0:#,0}", lastPrice);
            amount = lastPrice;
        }
    }
}

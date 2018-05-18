using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

[RequireComponent(typeof(Button))]
public class ShopItemContent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    // UI
    private Button identityBtn;
    [SerializeField] private Image itemImage;
    [SerializeField] private Text itemSubjectText;
    [SerializeField] private Text itemCoinText;
    [HideInInspector] public Text itemDetailText;
    [HideInInspector] public GameObject itemBuyer;
    [HideInInspector] public GameObject modal;

    // Item
    public string itemName;
    public int itemPrice;
    public Sprite icon;
    [TextArea(3,3)]
    public string itemDetail;

	void Start () {
        identityBtn = this.GetComponent<Button>();
        itemImage.sprite = icon;
        itemSubjectText.text = itemName;
        itemCoinText.text = String.Format("{0:#,0}", itemPrice);   
    }

    private void Update() {
        if (PlayerData.coin <= itemPrice) {
            identityBtn.interactable = false;
        }
    }

    // オブジェクトの範囲内にマウスポインタが入った際に呼び出されます。
    // this method called by mouse-pointer enter the object.
    public void OnPointerEnter(PointerEventData eventData) {
        itemDetailText.text = itemDetail;
    }

    // オブジェクトの範囲内からマウスポインタが出た際に呼び出されます。
    // 
    public void OnPointerExit(PointerEventData eventData) {
        itemDetailText.text = "";
    }

    // クリック時
    public void OnClick() {
        modal.GetComponent<ShopModalControl>().itemName = itemName;
        modal.GetComponent<ShopModalControl>().itemPrice = itemPrice;
        modal.GetComponent<ShopModalControl>().icon = icon;
        modal.GetComponent<ShopModalControl>().OnUpdate();
        modal.SetActive(true);
    }

}

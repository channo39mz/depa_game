using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image Image;
    public float Quantity = 0f;
    private TMP_Text quantityText;
    private Item _item;
    public Item Item{
        get {return _item;}
        set {
            _item = value;
            if(_item == null){
                Image.enabled = false;
            }
            else{
                Image.sprite = _item.image;
                Image.enabled = true;
                quantityText.gameObject.SetActive(true);
            }
        }
    }
    void Awake(){
        
    }
    void Update(){
        quantityText.text = Quantity.ToString();
    }
    private void OnValidate(){
        if(Image == null){
            Image = GetComponent<Image>();
        }
        quantityText = this.transform.GetChild(0).GetComponent<TMP_Text>();
    }
}
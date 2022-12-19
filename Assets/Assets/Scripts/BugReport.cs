using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Proyecto26;
using CustomEvents;
using RSG;

public class BugReport : MonoBehaviour
{
    [SerializeField] GameObject Dropdown;
    [SerializeField] TMP_InputField title;
    [SerializeField] TMP_InputField description;
    Michsky.UI.ModernUIPack.CustomDropdown dropdown_category;
    Michsky.UI.ModernUIPack.CustomDropdown items;
    BugReport_Data bug_obj = new BugReport_Data();
    WebNuruk webNuruk;
    DetailError responseErr = new DetailError();
    [SerializeField] Text ErrorMessage;
    [SerializeField] Text SuccessMessage;
    [SerializeField] private GameObject report;

    int index;
    string category;
    void Start()
    {
        dropdown_category = Dropdown.GetComponent<Michsky.UI.ModernUIPack.CustomDropdown>();
        items = Dropdown.GetComponent<Michsky.UI.ModernUIPack.CustomDropdown>();
        webNuruk = FindObjectOfType<WebNuruk>();
        ErrorMessage.enabled = false;
        SuccessMessage.enabled = false;
    }

    public void CreateReport()
    {
        ErrorMessage.enabled = false;
        SuccessMessage.enabled = false;
        index = dropdown_category.selectedItemIndex;
        category = items.dropdownItems[index].itemName;
      
        if ((category != "") && (title.text != "") && (description.text != "")){
            bug_obj.category = category;
            bug_obj.title = title.text;
            bug_obj.description = description.text;
            bug_obj.status = 0;
            bug_obj.image = "Imagen";
            webNuruk.BugReport_Post(bug_obj).Then((res) => {
                WebNuruk.bug_response = res;
                SuccessMessage.enabled = true;
                ErrorMessage.text = "Successfully sent";
                Debug.Log(JsonUtility.ToJson(res));
                report.SetActive(false);
            }).Catch((err) => {
                var error = err as RequestException;
                responseErr = JsonUtility.FromJson<DetailError>(error.Response);
                ErrorMessage.enabled = true;
                ErrorMessage.text = responseErr.detail;
            });
        }else{
            ErrorMessage.enabled = true;
            ErrorMessage.text = "Fields can't be empty";
        }
    }

    public void CloseBugReport()
    {
           Player.PlayerData.InMenus = false;
           Player.PlayerData.InChat = false;
    }
}

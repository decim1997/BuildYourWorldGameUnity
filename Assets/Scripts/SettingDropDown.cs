using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingDropDown : MonoBehaviour
{
    List<string> resolutions = new List<string>()
        {
            "HIGHT","MEDUIM","LOW"
        };
    public Dropdown dropdown;
    public TextMeshPro selectedresolution;
    public Text txt;

    private void Start()
    {
        PopulateList();
        
    }

    public void Dropdown_Index_Change(int index)
    {
        selectedresolution.text = resolutions[index];
    }


    void PopulateList()
    {
        dropdown.AddOptions(resolutions);
    }



}

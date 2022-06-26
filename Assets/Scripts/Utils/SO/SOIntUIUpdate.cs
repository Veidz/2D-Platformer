using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOIntUIUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextvalue;

    private void Start()
    {
        uiTextvalue.text = soInt.value.ToString();
    }

    private void Update()
    {
        uiTextvalue.text = soInt.value.ToString();
    }
}

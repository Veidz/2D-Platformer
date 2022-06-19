using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMenu : MonoBehaviour
{
    public GameObject menu;

    public void HandleDestroyMenu()
    {
        Destroy(menu);
    }
}

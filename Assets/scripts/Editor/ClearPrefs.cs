using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClearPrefs : MonoBehaviour {

[MenuItem("PlayerPrefs/Remove all")]
    static void ClearPreferences()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Removed all playerprefs");
    }
}

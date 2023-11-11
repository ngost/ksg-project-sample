using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var last_stage = PlayerPrefs.GetInt("last_stage", 1);
        GameObject.Find("last_stage").GetComponent<TextMeshProUGUI>().text = last_stage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

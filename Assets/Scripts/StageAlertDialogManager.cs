using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageAlertDialogManager : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    TextMeshProUGUI Stage_Number;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();   
        Stage_Number = transform.Find("Stage_Number").GetComponent<TextMeshProUGUI>();
    }

    public IEnumerator Showdialog(int stage){        
        Stage_Number.text = stage.ToString();
        canvasGroup.alpha = 1;
        yield return new WaitForSeconds(3f);        
        canvasGroup.alpha = 0;

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private TextMeshProUGUI timer_text;
    public int start_time = 60;
    private int remain_time = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer_text = transform.Find("background/TimerText").GetComponent<TextMeshProUGUI>();
        StartCoroutine(TimerStart());
    }

    public IEnumerator TimerStart(){
        remain_time = start_time;
        while(remain_time > 0){
            timer_text.text = remain_time.ToString();
            yield return new WaitForSeconds(1f);
            remain_time -= 1;
        }
        timer_text.text = "0";
        GameObject.Find("StageController").GetComponent<StageController>().GameOver();
    }

    public void TimerIncrease(int time){
        remain_time += time;
    }

}

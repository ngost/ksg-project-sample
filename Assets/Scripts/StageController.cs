using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public int current_stage = 1;
    public int last_stage = 10;
    public StageAlertDialogManager stageAlertDialogManager;
    // Start is called before the first frame update
    void Start()
    {
        stageAlertDialogManager = GameObject.Find("StageAlertDialog").GetComponent<StageAlertDialogManager>();
        StartCoroutine(InitStage(1));
    }

    public IEnumerator InitStage(int stage){
        yield return new WaitForEndOfFrame();
        print("NextLevel");
        GameObject.Find("BGMController").GetComponent<BGMController>().SetBGM((int)(stage/5) + 1);
        GameObject.Find("Parallax Controler").GetComponent<BackgroundControl_0>().SetBG((int)(stage/5));
        stageAlertDialogManager.StartCoroutine(stageAlertDialogManager.Showdialog(stage));
        GameObject.Find("MonsterCreator").GetComponent<MonsterCreator>().CreateMonster(stage);
    }

    public void NextStage(){
        current_stage += 1;
        if(current_stage > last_stage){
            current_stage = last_stage;
            GameOver();
        }else{
            StartCoroutine(InitStage(current_stage));
        }
    }

    public void GameOver(){
        PlayerPrefs.SetInt("last_stage", current_stage);
        SceneManager.LoadScene("Result Scene");
    }
}

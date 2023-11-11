using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MonsterScript : MonoBehaviour
{
    public string monster_name = "Monster";
    public int monster_hp = 10;
    public int remain_hp;

    private Image hp_remain_bar;
    private TextMeshPro hp_text;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameObject.AddComponent<PolygonCollider2D>();
        this.remain_hp = this.monster_hp;
        hp_remain_bar = transform.Find("Canvas/HP_Background/remain").GetComponent<Image>();
        hp_text = transform.Find("Text(HP)").GetComponent<TextMeshPro>();
        hp_text.text = this.remain_hp.ToString() + " / " + this.monster_hp.ToString();
    }

    private void Hited(int damage)
    {
        UpdateHP(damage);
        Impact(damage);
    }

    private void Impact(int damage)
    {
        var random_num = UnityEngine.Random.Range(1,5);
        random_num = random_num * damage;

        rb.AddForce(Vector2.up * random_num, ForceMode2D.Impulse);
    }

    public void UpdateHP(int HP){
        this.remain_hp -= HP;
        GameObject.Find("Charactor").GetComponent<SimpleCharactorController>().last_attack_damage = 0;
        var hp_bar_percent = (float)this.remain_hp / (float)this.monster_hp;
        hp_remain_bar.fillAmount = hp_bar_percent;
        hp_text.text = this.remain_hp.ToString() + " / " + this.monster_hp.ToString();

        if(this.remain_hp <= 0){
            Destroy(this.gameObject);
        }
    }    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Charactor")
        {
            var damage = GameObject.Find("Charactor").GetComponent<SimpleCharactorController>().last_attack_damage;
            Hited(damage); 
        }
    }

    private void OnDestroy(){
        GameObject.Find("StageController").GetComponent<StageController>().NextStage();
        GameObject.Find("GameTimerManager").GetComponent<TimerManager>().TimerIncrease(5);
    }
}

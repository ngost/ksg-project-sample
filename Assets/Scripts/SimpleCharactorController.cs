using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharactorController : MonoBehaviour
{   
    public Rigidbody2D rb;
    public AudioSource audioSource;
    public AudioClip attack_sound1;
    public AudioClip attack_sound2;
    public AudioClip attack_sound3;
    public AudioClip attack_sound4;
    public float move_speed = 10f;
    public int arm_attack_damage = 1;
    public int leg_attack_damage = 2;

    public int last_attack_damage = 0; // 1: front arm, 2: back arm, 3: leg big, 4: leg small

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input keyboard
        float horizontal = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.LeftArrow ) || horizontal < 0){
            //왼쪽 방향으로 이동
                // print("왼쪽");
                transform.localScale = new Vector3(-1,1,1);

            var current_speed = Mathf.Abs(rb.velocity.x);
            if(current_speed < move_speed){
                rb.AddForce(Vector2.left * 1, ForceMode2D.Impulse);
            }
        }else if(Input.GetKey(KeyCode.RightArrow) || horizontal > 0){
            //오른쪽 방향으로 이동
                transform.localScale = new Vector3(1,1,1);

            // print("오른쪽");
            var current_speed = Mathf.Abs(rb.velocity.x);
            if(current_speed < move_speed){
                rb.AddForce(Vector2.right * 1, ForceMode2D.Impulse);
            }
        }

        if(Input.GetKeyUp(KeyCode.Q)){
            //front arm attack
            GetComponentInChildren<Animator>().SetTrigger("front_arm_attack");
            last_attack_damage = 1;
            audioSource.clip = attack_sound1;
            audioSource.Play();
            // print("Q");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //back arm attack
            GetComponentInChildren<Animator>().SetTrigger("back_arm_attack");
            last_attack_damage = 1;
            audioSource.clip = attack_sound2;
            audioSource.Play();
            // print("W");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            //leg attack
            GetComponentInChildren<Animator>().SetTrigger("leg_big_attack");
            last_attack_damage = 2;
            audioSource.clip = attack_sound3;
            audioSource.Play();
            // print("E");
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            //leg attack
            GetComponentInChildren<Animator>().SetTrigger("leg_small_attack");
            last_attack_damage = 2;
            audioSource.clip = attack_sound4;
            audioSource.Play();
            // print("R");
        }
    }
}

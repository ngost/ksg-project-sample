using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreator : MonoBehaviour
{
    public List<GameObject> monster_prefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void CreateMonster(int stage){
        Instantiate(monster_prefab[stage-1]);
    }
}

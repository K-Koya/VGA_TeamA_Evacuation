using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject SpawnPos;
    [SerializeField] GameObject Item;
    [SerializeField] float SpawnTime = 10.0f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Item && timer > SpawnTime)
        //�Ώۂ̃A�C�e�����Ƃ��Ă��āATimer��SpawnTime���傫���ꍇ�A�A�C�e���𐶐�
        //Timer�̃��Z�b�g�̓A�C�e�����ł���Ă��炤�\��
        {
            Instantiate(Item,SpawnPos.transform);
        }
        timer += Time.deltaTime;
    }
}

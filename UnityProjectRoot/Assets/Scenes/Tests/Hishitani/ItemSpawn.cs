using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject _spawnPos;
    [SerializeField] GameObject _item;
    [SerializeField] float _spawnTime = 10.0f;
    public float _timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_item.active == false && _timer > _spawnTime)
        //�Ώۂ̃A�C�e�����Ƃ��Ă��āATimer��SpawnTime���傫���ꍇ�A�A�C�e���𐶐�
        //Timer�̃��Z�b�g�̓A�C�e�����ł���Ă��炤�\��
        {
            _item.active = true;
        }
        _timer += Time.deltaTime;
    }

    public void TimerLiset()
    {
        _timer = 0.0f;
    }
}

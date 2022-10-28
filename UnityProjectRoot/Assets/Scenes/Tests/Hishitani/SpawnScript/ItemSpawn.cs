using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] Item _item;//�A�C�e���̃I�u�W�F�N�g
    [SerializeField] List<GameObject> _spawnPosition;//�A�C�e���̏o���ʒu
    private void Start()
    {
        for (int i = 0; i < _spawnPosition.Count; i++)
        {
            //�A�C�e���̐���
            Instantiate(_item, _spawnPosition[i].transform);
            Debug.Log("�A�C�e���o����");
        }
    }
}

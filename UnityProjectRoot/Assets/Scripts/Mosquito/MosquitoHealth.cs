using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��̗̑́A���ɓ����������̋���
/// </summary>
public class MosquitoHealth : MonoBehaviour
{
    [Header("��̗̑�")]
    [SerializeField, Tooltip("��̗̑�")] int _health = 3;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"�Ⴊ�_���[�W���󂯂�(�󂯂��_���[�W�F{damage})");
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.layer == 8)
        {
            TakeDamage(1);
            Debug.Log("�Ⴊ���ɓ�������");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// �����؂̑ϋv�́i�����Ƃ��납�痎�����HP������j
/// </summary>
public class Durability : MonoBehaviour
{
    [Header("�ϋv��")]
    [SerializeField, Tooltip("�ϋv��")] int _hp = 5;

    [Header("�ϋv�͂�\������Text")]
    [SerializeField, Tooltip("�\��������Text")] TMP_Text _hpText;

    [Header("���x�ɉ����ă_���[�W���󂯂鏈��")]
    [SerializeField, Tooltip("�_���[�W���󂯂鑬�x�̉���")] float _damageSpeed = 5f;
    [SerializeField, Tooltip("�_���[�W")] int _damage = 1;


    private void Start()
    {
        if (_hpText == null)
        {
            Debug.LogError("HP�e�L�X�g���ݒ肳��Ă��܂���");
        }

        _hpText.text = "����؂̑ϋv�́F" + _hp.ToString();
    }

    private void CheckVelocity(Collision collision)
    {
        // �Ռ���5�Ŋ���i�v�Z���y�ɂ��邽�߁j
        float impulse = collision.impulse.magnitude / 5f;

        Debug.Log(impulse);

        if(impulse > _damageSpeed)
        {
            TakeDamage(_damage);
        }
    }

    /// <summary>
    /// �_���[�W���󂯂鏈���i���������ɂ���āj
    /// </summary>
    /// <param name="damage">�󂯂�_���[�W</param>
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        _hpText.text = "����؂̑ϋv�́F" + _hp.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != 10)
        {
            CheckVelocity(collision);
        }
        else
        {
            Debug.Log("�N�b�V�����ɏՓ�");
        }
    }
}

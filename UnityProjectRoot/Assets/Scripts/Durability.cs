using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����؂̑ϋv�́i�����Ƃ��납�痎�����HP������j
/// </summary>
public class Durability : MonoBehaviour
{
    [Header("�ϋv��")]
    [SerializeField, Tooltip("�ϋv��")] int _hp = 5;

    [Header("�ϋv�͂�\������Text")]
    [SerializeField, Tooltip("�\��������Text")] Text _hpText;

    [Header("�����֌W")]
    [SerializeField, Tooltip("Ray���΂��ꏊ")] Transform _rayPos;
    [SerializeField, Tooltip("Ray�̋���")] float _rayRange = 0.5f;
    [SerializeField, Tooltip("�������̃_���[�W")] int _fallDamage = 1;
    [SerializeField, Tooltip("�_���[�W���󂯂�ۂ̋���")] float _damageDistance = 2f;

    [Tooltip("�����Ă��邩�ǂ����̃t���O")] bool _isFall = false;
    [Tooltip("���������̏ꏊ")] float _fallPos = 0f;
    [Tooltip("������������")] float _fallDistance = 0f;


    private void Start()
    {
        if (_hpText == null)
        {
            Debug.LogError("HP�e�L�X�g���ݒ肳��Ă��܂���");
        }
        if ( _rayPos == null)
        {
            Debug.LogError("Ray�|�W�V�������ݒ肳��Ă��܂���");
        }

        _fallPos = transform.position.y;
        _hpText.text = "����؂̑ϋv�́F" + _hp.ToString();
    }

    private void Update()
    {
        Debug.DrawLine(_rayPos.position, _rayPos.position + Vector3.down * _rayRange, Color.red);

        CheckFalling();
    }

    private void CheckFalling()
    {
        //�@�����Ă�����
        if (_isFall)
        {

            //�@�����n�_�ƌ��ݒn�̋������v�Z�i�W�����v���ŏ�ɔ��ŗ��������ꍇ���l������ׂ̏����j
            _fallPos = Mathf.Max(_fallPos, transform.position.y);

            //�@�n�ʂɃ��C���͂��Ă�����
            if (Physics.Linecast(_rayPos.position, _rayPos.position + Vector3.down * _rayRange, LayerMask.GetMask("Ground")))
            {
                //�@�����������v�Z
                _fallDistance = _fallPos - transform.position.y;
                //�@�����ɂ��_���[�W���������鋗���𒴂���ꍇ�_���[�W��^����
                if (_fallDistance >= _damageDistance)
                {
                    TakeDamage((int)(_fallDamage));
                    Debug.Log("�_���[�W���󂯂�");
                }
                _isFall = false;
            }
        }
        else
        {
            //�@�n�ʂɃ��C���͂��Ă��Ȃ���Η����n�_��ݒ�
            if (!Physics.Linecast(_rayPos.position, _rayPos.position + Vector3.down * _rayRange, LayerMask.GetMask("Field", "Block")))
            {
                //�@�ŏ��̗����n�_��ݒ�
                _fallPos = transform.position.y;
                _fallDistance = 0;
                _isFall = true;
            }
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

/// <summary>
/// ��������i�̗́j�̋����𐧌䂷��R���|�[�l���g
/// </summary>
public class SenkouHealth : MonoBehaviour
{
    [Header("��������̎c�莞��")]
    [SerializeField, Tooltip("��������̎c�莞��")] FloatReactiveProperty _senkouTime = new FloatReactiveProperty(60f);

    [Header("���G�t���O")]
    [SerializeField] bool _godMode;

    public IReactiveProperty<float> Health => _senkouTime;

    private void Update()
    {
        ReduceHealth();
    }

    /// <summary>
    /// ���X�ɑ̗͂������Ă�������
    /// </summary>
    private void ReduceHealth()
    {
        if (_godMode) return;

        _senkouTime.Value -= Time.deltaTime;

        _senkouTime.Value = Mathf.Max(0, _senkouTime.Value);

        if(_senkouTime.Value <= 0)
        {
            GameManager.Instance.OnGameOver();
        }
    }

    /// <summary>
    /// �A�C�e�����擾�������ɌĂ΂��֐�
    /// </summary>
    /// <param name="value">�񕜃A�C�e���̉񕜒l</param>
    public void GetHeal(float value)
    {
        _senkouTime.Value += value;
        Debug.Log(value + "�񕜂���");
    }
}

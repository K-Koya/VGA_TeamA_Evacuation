using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��������i�̗́j�̋����𐧌䂷��R���|�[�l���g
/// </summary>
public class SenkouHealth : MonoBehaviour
{
    [Header("��������̗̑�")]
    [SerializeField, Tooltip("�̗͂̍ő�l")] float _health = 60f;

    [Header("UI")]
    [SerializeField, Tooltip("�̗͂�\��������e�L�X�g")] Text _healthText;

    private void Update()
    {
        ReduceHealth();
    }

    /// <summary>
    /// ���X�ɑ̗͂������Ă�������
    /// </summary>
    private void ReduceHealth()
    {
        _health -= Time.deltaTime;
        _healthText.text = _health.ToString("F2");
    }

    /// <summary>
    /// �A�C�e�����擾�������ɌĂ΂��֐�
    /// </summary>
    /// <param name="value">�񕜃A�C�e���̉񕜒l</param>
    public void GetHeal(float value)
    {
        _health += value;
    }
}

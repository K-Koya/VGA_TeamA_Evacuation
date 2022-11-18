using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// ��������i�̗́j�̋����𐧌䂷��R���|�[�l���g
/// </summary>
public class SenkouHealth : MonoBehaviour
{
    [Header("��������̗̑�")]
    [SerializeField, Tooltip("�̗͂̍ő�l")] float _health = 60f;

    [Header("UI")]
    [SerializeField, Tooltip("�̗͂�\��������e�L�X�g")] TMP_Text _healthText;

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

        _health = Mathf.Max(0, _health);

        if(_health <= 0)
        {
            GameManager.Instance.OnGameOver();
        }

        _healthText.text = "�����̎c�莞�ԁF" + _health.ToString("F2");
    }

    /// <summary>
    /// �A�C�e�����擾�������ɌĂ΂��֐�
    /// </summary>
    /// <param name="value">�񕜃A�C�e���̉񕜒l</param>
    public void GetHeal(float value)
    {
        _health += value;
        Debug.Log(value + "�񕜂���");
    }
}

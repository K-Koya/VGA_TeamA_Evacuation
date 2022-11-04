using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAttachment : MonoBehaviour
{
    #region �ϐ�
    [SerializeField, Tooltip("�|���Ȃ��Ƃ����Ȃ��G�̃m���}(��)")] int _quota = 10;
    #endregion

    #region �v���p�e�B
    /// <summary>
    /// �G�̃m���}
    /// </summary>
    public int Quota => _quota;
    #endregion

    #region �f���Q�[�g
    public delegate void MonoEvent();
    MonoEvent _updateEvent;
    #endregion

    private void Awake()
    {
        GameManager.Instance.SetupUpdateCallback(this);
        GameManager.Instance.OnSetup(this);
    }
    private void Update()
    {
        _updateEvent?.Invoke();
    }

    /// <summary>
    /// Update�ŌĂт���������o�^���Ă���
    /// </summary>
    public void SetupCallBack(MonoEvent e)
    {
        _updateEvent = e;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAttachment : MonoBehaviour
{
    #region �ϐ�
    [Header("�Q�[���̐ݒ�")]
    [SerializeField, Tooltip("��������")] float _gameTime = 300f;
    #endregion

    #region �v���p�e�B
    public float GameTime => _gameTime;
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

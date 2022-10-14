using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���̊Ǘ��N���X
/// </summary>
public class GameManager
{
    #region �v���p�e�B
    /// <summary>
    /// GameManager�̃C���X�^���X
    /// </summary>
    public static GameManager Instance = new GameManager();

    /// <summary>
    /// ����؂̃��[�h
    /// </summary>
    public PlayerMode PlayerMode => _playerMode;
    #endregion

    #region �ϐ�
    float _gameTime;
    int _score;
    PlayerMode _playerMode = PlayerMode.Normal;
    #endregion

    /*ToDo
    �X�R�A�̊Ǘ�
    ���Ԃ̊Ǘ�
    �|�[�Y��������
    */

    //�R���X�g���N�^
    public GameManager() 
    {
        Debug.Log("New GameManager");
    }

    /// <summary>
    /// ����؂̃��[�h��؂�ւ���֐�
    /// </summary>
    /// <param name="mode"></param>
    public void PlayerModeChange(PlayerMode mode)
    {
        _playerMode = mode;
        Debug.Log($"���[�h��؂�ւ��� {mode}");
    }
}

/// <summary>
/// ����؂̃��[�h�p��Enum
/// </summary>
public enum PlayerMode
{
    //�ʏ탂�[�h
    Normal = 0,
    //�����������[�h
    PowerUp = 1,
}

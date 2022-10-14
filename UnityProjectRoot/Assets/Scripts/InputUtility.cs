using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputUtility : MonoBehaviour
{
    #region �萔
    /// <summary>InputActionAsset��̓��͖� : �J��������</summary>
    const string _INPUT_ACTION_NAME_CAMERA_MOVE = "Look";

    /// <summary>InputActionAsset��̓��͖� : �ړ�����</summary>
    const string _INPUT_ACTION_NAME_MOVE = "Move";

    /// <summary>InputActionAsset��̓��͖� : ���𔭎�</summary>
    const string _INPUT_ACTION_NAME_FIRE = "Fire";

    /// <summary>InputActionAsset��̓��͖� : �W�����v</summary>
    const string _INPUT_ACTION_NAME_JUMP = "Jump";

    /// <summary>InputActionAsset��̓��͖� : �X�^�C���؂�ւ�</summary>
    const string _INPUT_ACTION_NAME_SWITCH_STYLE = "SwitchStyle";

    /// <summary>InputActionAsset��̓��͖� : �|�[�Y�؂�ւ�</summary>
    const string _INPUT_ACTION_NAME_SWITCH_PAUSE = "Pause";
    #endregion

    #region �����o
    /// <summary>�J����������</summary>
    static InputAction _actionCameraMove = null;
    /// <summary>�ړ�������</summary>
    static InputAction _actionMove = null;
    /// <summary>���𔭎ˑ�����</summary>
    static InputAction _actionFire = null;
    /// <summary>�W�����v������</summary>
    static InputAction _actionJump = null;
    /// <summary>�X�^�C���؂�ւ�������</summary>
    static InputAction _actionSwitchStyle = null;
    /// <summary>�|�[�Y�؂�ւ�������</summary>
    static InputAction _actionPause = null;
    #endregion

    #region �v���p�e�B
    /// <summary> �|�[�Y�{�^���������� </summary>
    static public bool GetDownPause { get => _actionPause.triggered; }
    /// <summary> �ړ����쒼�� </summary>
    static public bool GetDownMove { get => _actionMove.triggered; }
    /// <summary> �ړ�����̕����擾 </summary>
    static public Vector2 GetDirectionMove { get => _actionMove.ReadValue<Vector2>(); }
    /// <summary> �J��������̕����擾 </summary>
    static public Vector2 GetDirectionCameraMove { get => _actionCameraMove.ReadValue<Vector2>(); }
    /// <summary> �W�����v�{�^���������� </summary>
    static public bool GetDownJump { get => _actionJump.triggered; }
    /// <summary> �W�����v�{�^�������� </summary>
    static public bool GetJump { get => _actionJump.IsPressed(); }
    /// <summary> ���𔭎˃{�^���������� </summary>
    static public bool GetDownFire { get => _actionFire.triggered; }
    /// <summary> ���𔭎˃{�^�������� </summary>
    static public bool GetFire { get => _actionFire.IsPressed(); }
    /// <summary> �X�^�C���؂�ւ��{�^���������� </summary>
    static public bool GetDownActionSwitch { get => _actionSwitchStyle.triggered; }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //���͂��֘A�t��
        PlayerInput input = GetComponent<PlayerInput>();
        InputActionMap actionMap = input.currentActionMap;
        _actionCameraMove = actionMap[_INPUT_ACTION_NAME_CAMERA_MOVE];
        _actionMove = actionMap[_INPUT_ACTION_NAME_MOVE];
        _actionFire = actionMap[_INPUT_ACTION_NAME_FIRE];
        _actionJump = actionMap[_INPUT_ACTION_NAME_JUMP];
        _actionSwitchStyle = actionMap[_INPUT_ACTION_NAME_SWITCH_STYLE];
        _actionPause = actionMap[_INPUT_ACTION_NAME_SWITCH_PAUSE];
    }
}

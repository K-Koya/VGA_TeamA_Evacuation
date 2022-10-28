using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

/// <summary>
/// ����炷�N���X
/// </summary>
[RequireComponent(typeof(CriAtomSource))]
public class SoundPlayer : MonoBehaviour
{
    [Header("�ݒ�")]
    [SerializeField, Tooltip("���̉����ɂ��鎞�̓`�F�b�N")] bool _3DPositioning;
    [SerializeField, Tooltip("�g�p����CueSheet")] CueSheet _cueSheet;
    [Space(10)]
    [SerializeField, Tooltip("Log��\������")] bool _debugLog = true; 

    CriAtomSource _source;
    CriAtomEx.CueInfo[] _cueInfoList;
    CriAtomExAcb _atomExAcb;

    private void Awake()
    {
        //Source���擾
        _source = GetComponent<CriAtomSource>();

        ///���̉����ɂ��邩�̐ݒ�
        _source.use3dPositioning = _3DPositioning;

        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        //�L���[�V�[�g�̃��[�h��҂�
        while (CriAtom.CueSheetsAreLoading)
        {
            yield return null;
        }

        //Cue�����擾
        _atomExAcb = CriAtom.GetAcb(_cueSheet.ToString());
        _cueInfoList = _atomExAcb.GetCueInfoList();
    }

    /// <summary>
    /// Name�ɂ��Đ�
    /// </summary>
    /// <param name="name"></param>
    public void PlaySound(string name)
    {
        var atomExPlayer = _source.player;

        //�Đ����Ŗ������
        if(atomExPlayer.GetStatus() != CriAtomExPlayer.Status.Playing)
        {
            //��O���`�F�b�N
            for(int i = 0; i < _cueInfoList.Length; i++)
            {
                //CueInfoList�Ɏw�肳�ꂽ���O��Cue����������ʂ�
                if(_cueInfoList[i].name == name)
                {
                    break;
                }

                //�Ō�܂Ō�����Ȃ�������߂�
                if(i == _cueInfoList.Length - 1)
                {
                    if(_debugLog)
                        Debug.LogError($"[{_cueSheet}]��[{name}]������܂���");

                    return;
                }
            }

            //�ݒ�
            atomExPlayer.SetCue(_atomExAcb, name);
            atomExPlayer.Start();
        }
    }
    /// <summary>
    /// ID�ɂ��Đ�
    /// </summary>
    /// <param name="id"></param>
    public void PlaySound(int id)
    {
        var atomExPlayer = _source.player;

        //���̃I�u�W�F�N�g�ɂ��Ă���Source���Đ����Ŗ������
        if (atomExPlayer.GetStatus() != CriAtomExPlayer.Status.Playing)
        {
            //��O���`�F�b�N
            for (int i = 0; i < _cueInfoList.Length; i++)
            {
                //CueInfoList�Ɏw�肳�ꂽID����������ʂ�
                if (_cueInfoList[i].id == id)
                {
                    break;
                }

                //�Ō�܂Ō�����Ȃ�������߂�
                if (i == _cueInfoList.Length - 1)
                {
                    if(_debugLog)
                        Debug.LogError($"[{_cueSheet}]�Ɏw�肳�ꂽID[{id}]������܂���");

                    return;
                }
            }

            //�ݒ�
            atomExPlayer.SetCue(_atomExAcb, id);
            atomExPlayer.Start();
        }
    }

    /*MEMO
    �T�E���h���񂩂瑗���Ă���f�[�^�ɂ���ẮA�ύX����\������
    (�o���邾���ς����������̂ŁA�v�b������)
    */
    enum CueSheet
    {
        BGM,
        SE,
        ME,
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataController : MonoBehaviour
{
    public  SaveDataController I { get; private set; }

    [SerializeField] string _testSaveDataPath = "test-save-data";

    private void Awake()
    {
        I = this;
    }

    public void TestLoad()
    {
        TestSaveData saveData = JsonSaveManager<TestSaveData>.Load(_testSaveDataPath);

        if (saveData == null)//�Z�[�u�f�[�^�����݂��Ȃ��ꍇ�͔C�ӂ̒l�ŏ�����
        {
            //�V���ȃZ�[�u�f�[�^���쐬
            saveData = new TestSaveData()
            {
                _num = 3,
                _str = "�e�X�g",
                _vec = Vector3.one
            };
            Debug.Log("�Z�[�u�f�[�^�����݂��Ȃ��������ߔC�ӂ̒l�ŏ��������܂���");
        }

        TestClass.I.SetValue(saveData);

    }

    public void TestSave()
    {
        TestSaveData testSaveData = new TestSaveData()
        {
            _num = TestClass.I._num,
            _str = TestClass.I._str,
            _vec = TestClass.I._vec,
        };
        JsonSaveManager<TestSaveData>.Save(testSaveData, _testSaveDataPath);
    }

    //private void OnApplicationPause(bool isPaused)
    //{
    //    if (isPaused)
    //    {
    //        OverWriteSaveData();
    //    }
    //}

    //private void OnApplicationQuit()//�A�v���P�[�V�����I�����ɌĂяo��
    //{
    //    OverWriteSaveData();
    //}

    ////�Z�[�u�f�[�^�̏㏑��
    //void OverWriteSaveData()
    //{
    //    TestSaveData testSaveData = new TestSaveData()
    //    {
    //        _num = TestClass.I._num,
    //        _str = TestClass.I._str,
    //        _vec = TestClass.I._vec,
    //    };
    //    JsonSaveManager<TestSaveData>.Save(testSaveData, _testSaveDataPath);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAttachment : MonoBehaviour
{
    public delegate void MonoEvent();
    MonoEvent _updateEvent;

    private void Awake()
    {
        GameManager.Instance.SetupUpdateCallback(this);
    }
    private void Update()
    {
        _updateEvent?.Invoke();
    }

    /// <summary>
    /// Updateで呼びたい処理を登録しておく
    /// </summary>
    public void SetupCallBack(MonoEvent e)
    {
        _updateEvent = e;
    }
}

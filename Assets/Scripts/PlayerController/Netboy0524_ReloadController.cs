using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Netboy0524_ReloadController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    private List<Vector2> _savePoint = new List<Vector2>();
    private PlayableDirector _reloadScene;
    // Start is called before the first frame update
    void Start()
    {
        _reloadScene = GetComponent<PlayableDirector>();
        Init();
        for (int i = 0; i < 6; i++)
        {
            _savePoint.Add(new Vector2(-23 + (50 * i), 0));
        }
    }
    // Update is called once per frame
    void Update()
    {
        Reload();
    }
    /// <summary>
    /// 세이브포인트에서 재시작
    /// </summary>
    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) || Netboy0524_PlayerController._isDead)
        {
            StartCoroutine("Replace", Netboy0524_CameraController._currentStage);
            Netboy0524_PlayerController._isDead = false;
        }
    }
    //플레이어 저장된 세이브위치로 이동
    IEnumerator Replace(int stage)
    {
        _reloadScene.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _player.transform.position = _savePoint[stage - 1];
        Init();
        yield return new WaitForSeconds(0.5f);
        _reloadScene.enabled = false;
    }
    //장애물들 초기화
    private void Init()
    {

    }
}

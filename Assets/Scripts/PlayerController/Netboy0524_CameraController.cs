using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Netboy0524_CameraController : MonoBehaviour
{
    [SerializeField] List<CinemachineVirtualCamera> _stageCameras;
    [SerializeField] CinemachineVirtualCamera _goalCamera;
    public static bool _whileCutScene { get; private set; }
    public static int _currentStage { get; private set; }
    private PlayableDirector _endScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartCutScene");
        _endScene = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 초반 6초동안 조작불가
    /// </summary>
    /// <returns></returns>
    IEnumerator StartCutScene()
    {
        _whileCutScene = true;
        yield return new WaitForSeconds(6);
        _whileCutScene = false;
    }
    IEnumerator EndCutScene()
    {
        _endScene.enabled = true;
        _whileCutScene = true;
        yield return new WaitForSeconds(5);
        _whileCutScene = false;
        SceneManager.LoadScene("Start");
    }
    /// <summary>
    /// 스테이지 넘어갈때마다 카메라 전환
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stage"))
        {
            if (other.transform.name == "Stage1")
            {
                _currentStage = 1;
            }
            else if (other.transform.name == "Stage2")
            {
                _currentStage = 2;
            }
            else if (other.transform.name == "Stage3")
            {
                _currentStage = 3;
            }
            else if (other.transform.name == "SecretStage")
            {
                
            }
            else if (other.transform.name == "Stage4")
            {
                _currentStage = 4;
            }
            else if (other.transform.name == "Stage5")
            {
                _currentStage = 5;
            }
            CinemachineVirtualCamera targetCam = other.GetComponentInChildren<CinemachineVirtualCamera>();
            SwitchCamera(targetCam);
        }
        if (other.CompareTag("Goal"))
        {
            StartCoroutine("EndCutScene");
        }
    }
    /// <summary>
    /// 이전카메라 끄고 새 카메라 활성화
    /// </summary>
    /// <param name="targetCamera">키고싶은 가상카메라</param>
    private void SwitchCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera camera in _stageCameras)
        {
            camera.enabled = camera == targetCamera;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netboy0524_ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private float _bulletSpeed = 40f;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Netboy0524_CameraController._whileCutScene && Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }
    /// <summary>
    /// 화면에 클릭한 지점을 향해서 총알을 생성하여 발사
    /// </summary>
    private void Shot()
    {
        Vector3 aimPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        aimPos.z = 0;

        Vector3 shotDir = (aimPos - transform.position).normalized;
        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.FromToRotation(Vector3.up, shotDir));
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = shotDir * _bulletSpeed;
    }
}

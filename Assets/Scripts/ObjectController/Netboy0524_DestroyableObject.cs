using System;
using UnityEngine;

public class Netboy0524_DestroyableObject : MonoBehaviour
{
    public int _hp = 5;
    private int _maxHp;
    private Renderer _objectRenderer;
    void Start()
    {
        _maxHp = _hp;
        _objectRenderer = GetComponent<Renderer>();
    }
    /// <summary>
    /// 총알과 충돌시 체력을 감소시키는 함수
    /// </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 bullet 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 체력 감소
            _hp--;
            UpdateOpacity();
            // 체력이 0 이하이면 오브젝트 파괴
            if (_hp <= 0)
            {
                Destroy();
            }
        }
    }
    /// <summary>
    /// 투명도 업데이트하는 함수
    /// </summary>
    void UpdateOpacity()
    {
        if (_objectRenderer != null)
        {
            float opacity = (float)_hp / _maxHp;
            _objectRenderer.material.color = new Color(1, 1, 1, opacity);
        }
    }
    /// <summary>
    /// 자기자신을 파괴하는 함수
    /// </summary>
    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }
}

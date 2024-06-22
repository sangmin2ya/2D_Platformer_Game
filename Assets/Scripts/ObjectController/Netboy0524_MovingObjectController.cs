using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netboy0524_MovingObjectController : MonoBehaviour
{
    private float _x = 0;
    private float _barSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        MoveFloor();
    }
    private void MoveFloor()
    {
        _x = 0;
        _x += 14.0f * Mathf.Sin(Time.time * _barSpeed);
        gameObject.transform.localPosition = new Vector2(_x, -4);
    }
}

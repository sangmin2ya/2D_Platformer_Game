using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netboy0524_SpawnController : MonoBehaviour
{
    [SerializeField] GameObject _trianglePrefab;
    private GameObject _triangle;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (_triangle == null)
        {
            _triangle = Instantiate(_trianglePrefab, new Vector3(Random.Range(-20, 20), 25, 0), Quaternion.identity);
        }
    }
}

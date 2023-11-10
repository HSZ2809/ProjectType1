using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private void OnEnable() 
    {
        // 오브젝트 풀링 후 데미지 받아오기
    }

    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
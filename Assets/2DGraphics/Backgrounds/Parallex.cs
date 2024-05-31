using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallex : MonoBehaviour
{

    RawImage mat;
    float distance;
    [Range(0f, 0.5f)] [SerializeField] float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * speed;
        float offset = mat.uvRect.x + distance;
        mat.uvRect = new Rect(distance, mat.uvRect.y, mat.uvRect.width, mat.uvRect.height);
        Debug.Log(mat.uvRect.x + distance);
    }
}

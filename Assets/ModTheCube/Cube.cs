using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    Slider positionSlider, rotationSlider, scaleSlider;
    float moveSpeed = 10f;
    private Vector3 targetPosition, targetRotation, targetScale;

    void Start()
    {
        transform.position = new Vector3(0,0,0);
        transform.localScale = Vector3.one;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        positionSlider =  GameObject.Find("Position").GetComponentInChildren<Slider>();
        rotationSlider = GameObject.Find("RotationSpeed").GetComponentInChildren<Slider>();
        scaleSlider = GameObject.Find("Scale").GetComponentInChildren<Slider>();
    }
    
    void Update()
    {
        targetRotation = Vector3.right;

        transform.Rotate(targetRotation * rotationSlider.value * Time.deltaTime);

        targetPosition  = Vector3.right * positionSlider.value;
        targetScale = Vector3.one * scaleSlider.value;

        Debug.Log(rotationSlider.value);
    }

    private void FixedUpdate()
    {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, moveSpeed * Time.fixedDeltaTime);

    }
}

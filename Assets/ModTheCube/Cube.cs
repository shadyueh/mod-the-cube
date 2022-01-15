using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    Slider positionSlider, rotationSlider, scaleSlider, redSlider, greenSlider, blueSlider, alphaSlider, XSlider, YSlider, ZSlider;
    float moveSpeed = 10f;
    private Vector3 targetPosition, targetRotation, targetScale;
    Material material;

    void Start()
    {
        transform.position = new Vector3(0,0,0);
        transform.localScale = Vector3.one;
        
        material = Renderer.material;
        material.color = new Color(0.09049479f, 0.5849056f, 0.4634714f, 0.7f); // new Color(0.5f, 1.0f, 0.3f, 0.4f);

        positionSlider =  GameObject.Find("Position").GetComponentInChildren<Slider>();
        rotationSlider = GameObject.Find("RotationSpeed").GetComponentInChildren<Slider>();
        scaleSlider = GameObject.Find("Scale").GetComponentInChildren<Slider>();

        XSlider = GameObject.Find("X Axis").GetComponentInChildren<Slider>();
        YSlider = GameObject.Find("Y Axis").GetComponentInChildren<Slider>();
        ZSlider = GameObject.Find("Z Axis").GetComponentInChildren<Slider>();

        redSlider = GameObject.Find("Red").GetComponentInChildren<Slider>();
        greenSlider = GameObject.Find("Green").GetComponentInChildren<Slider>();
        blueSlider = GameObject.Find("Blue").GetComponentInChildren<Slider>();
        alphaSlider = GameObject.Find("Opacity").GetComponentInChildren<Slider>();

        redSlider.value = material.color.r;
        greenSlider.value = material.color.g;
        blueSlider.value = material.color.b;
        alphaSlider.value = material.color.a;

        XSlider.value = 1f;

    }

    void Update()
    {
        targetRotation = new Vector3(XSlider.value, YSlider.value, ZSlider.value);

        // rotation speed
        transform.Rotate(targetRotation * rotationSlider.value * Time.deltaTime);
        // move position
        targetPosition  = Vector3.right * positionSlider.value;
        // change scale
        targetScale = Vector3.one * scaleSlider.value;
        // change color and opacity
        material.color = new Color(redSlider.value, greenSlider.value, blueSlider.value, alphaSlider.value);

    }

    private void FixedUpdate()
    {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, moveSpeed * Time.fixedDeltaTime);

    }

}

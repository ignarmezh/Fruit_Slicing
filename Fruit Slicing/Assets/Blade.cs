using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public GameObject bladeTrailPrefab;
    public float minCurrentVelocity = .001f;

    public static Vector2 direction;

    bool isCutting = false;

    GameObject currentBlateTrail;

    Vector2 previousPos;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D cc2d;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        cc2d = GetComponent<CircleCollider2D>();
    }

    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isCutting)
            UpdateCut();
    }

    void UpdateCut()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;

        direction = (newPos - previousPos).normalized;

        float velocity = (newPos - previousPos).magnitude / Time.deltaTime;
        if (velocity > minCurrentVelocity)
        {
            cc2d.enabled = true;
        }
        else
        {
            cc2d.enabled = false;
        }
        previousPos = newPos;
    }

    void StartCutting()
    {
        isCutting = true;
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = rb.position;
        //previousPos = cam.ScreenToWorldPoint(Input.mousePosition);
        currentBlateTrail = Instantiate(bladeTrailPrefab,transform);
        //cc2d.enabled = !cc2d.isActiveAndEnabled;
        cc2d.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBlateTrail.transform.SetParent(null);
        Destroy(currentBlateTrail,2f);
        //cc2d.enabled = !cc2d.isActiveAndEnabled;
        cc2d.enabled = false;
    }
}

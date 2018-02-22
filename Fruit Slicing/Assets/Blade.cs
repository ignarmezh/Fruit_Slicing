using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public GameObject bladeTrailPrefab;

    bool isCutting = false;

    GameObject currentBlateTrail;

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
        rb.position = cam.ScreenToWorldPoint( Input.mousePosition);
    }

    void StartCutting()
    {
        isCutting = true;
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = rb.position;
        currentBlateTrail = Instantiate(bladeTrailPrefab,transform);
        cc2d.enabled = !cc2d.isActiveAndEnabled;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBlateTrail.transform.SetParent(null);
        Destroy(currentBlateTrail,2f);
        cc2d.enabled = !cc2d.isActiveAndEnabled;
    }
}

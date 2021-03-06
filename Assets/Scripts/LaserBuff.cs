﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBuff : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private LineRenderer laserLine;

    // Use this for initialization
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.SetWidth(.4f, .4f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward, Color.green);
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            endPoint = hit.point;
            if (hit.transform.gameObject.tag == "BigAsteroid")
            {
                hit.transform.GetComponent<Asteroid>().GetMediumAsteroid();
                RemoveAsteroid(1);
            }
            else if (hit.transform.gameObject.tag == "MediumAsteroid")
            {
                hit.transform.GetComponent<Asteroid>().GetSmallAsteroid();
                RemoveAsteroid(2);
            }
            else if (hit.transform.gameObject.tag == "SmallAsteroid")
            {
                RemoveAsteroid(3);
            }
            else if (hit.transform.gameObject.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
                ScoreManager.Instance.Score += 10;
                hit.transform.GetComponent<EnemyShip>().RemoveShip();
            }
        }
        startPoint = transform.parent.position;
        laserLine.SetPosition(0, startPoint);
        laserLine.SetPosition(1, endPoint);
    }

    private void RemoveAsteroid(int points)
    {
        Destroy(hit.transform.gameObject);
        ScoreManager.Instance.Score += points;
        hit.transform.GetComponent<Asteroid>().InstantiateExplosionParticle();
    }
}

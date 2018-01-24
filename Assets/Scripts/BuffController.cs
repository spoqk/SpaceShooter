﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour {

    [SerializeField]
    private GameObject laserBuff;
    [SerializeField]
    private GameObject curledBuff;
    [SerializeField]
    private GameObject atomBuff;
    [SerializeField]
    private GameObject shieldBuff;
    [SerializeField]
    private float buffTime = 3;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LaserBuff"))
        {
            laserBuff.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(DisableBuff(laserBuff));
            GetComponent<Shooting>().isBuffTurnOn = true;
        }
        if (other.CompareTag("CurledBuff"))
        {
            Instantiate(curledBuff, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("AtomBuff"))
        {
            Instantiate(atomBuff, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("ShieldBuff"))
        {
            gameObject.tag = "Untagged";
            shieldBuff.SetActive(true);
            Destroy(other.gameObject);
            print("sasa");
            StartCoroutine(DisableBuff(shieldBuff));
        }
    }

    private IEnumerator DisableBuff(GameObject buff)
    {
        yield return new WaitForSeconds(buffTime);
        buff.SetActive(false);
        print(buff.name);
        gameObject.tag = "Player";
        GetComponent<Shooting>().isBuffTurnOn = false;
    }
}
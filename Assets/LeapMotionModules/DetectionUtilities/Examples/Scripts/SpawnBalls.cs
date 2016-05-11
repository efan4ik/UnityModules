﻿using UnityEngine;
using System.Collections;

public class SpawnBalls : MonoBehaviour {
  public GameObject RedBallPrefab;
  public GameObject GreenBallPrefab;
  public GameObject BlueBallPrefab;
  public float delayInterval = .15f; // seconds
  public int BallLimit = 200;

  private IEnumerator _redballCoroutine;
  private IEnumerator _greenballCoroutine;
  private IEnumerator _blueballCoroutine;

  void Awake () {
    _redballCoroutine = AddBallWithDelay(RedBallPrefab);
    _greenballCoroutine = AddBallWithDelay(GreenBallPrefab);
    _blueballCoroutine = AddBallWithDelay(BlueBallPrefab);
  }

  public void StartRedBalls(){
    StopCoroutine(_redballCoroutine);
    StartCoroutine(_redballCoroutine);
  }

  public void StopRedBalls(){
    StopCoroutine(_redballCoroutine);
  }

  public void StartGreenBalls(){
    StopCoroutine(_greenballCoroutine);
    StartCoroutine(_greenballCoroutine);
  }

  public void StopGreenBalls(){
    StopCoroutine(_greenballCoroutine);
  }

  public void StartBlueBalls () {
    StopCoroutine(_blueballCoroutine);
    StartCoroutine(_blueballCoroutine);
  }

  public void StopBlueBalls () {
    StopCoroutine(_blueballCoroutine);
  }

  private IEnumerator AddBallWithDelay (GameObject prefab) {
    while (true) {
      addBall(prefab);
      yield return new WaitForSeconds(delayInterval);
    }
  }

  private void addBall (GameObject prefab) {
    if (transform.childCount > BallLimit) removeBalls(BallLimit / 10);
    GameObject go = GameObject.Instantiate(prefab);
    go.transform.parent = transform;
    Rigidbody rb = go.GetComponent<Rigidbody>();
    rb.AddForce(Random.value * 3, Random.value * 3, Random.value * 3, ForceMode.Impulse);
  }

  private void removeBalls (int count) {
    if (count > transform.childCount) count = transform.childCount;
    for (int b = 0; b < count; b++) {
      Destroy(transform.GetChild(b).gameObject);
    }
  }
}
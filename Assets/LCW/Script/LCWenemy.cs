using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

//상태를 만들고 제어하고 싶다.
//탐색, 이동, 공격

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Find, Walk, Attack
    }
    State state;
    GameObject target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Find: Find(); break;
            case State.Walk: break;
            case State.Attack: Attack(); break;
        }
    }

    private void Find()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        Transform[] towerPos = new Transform[towers.Length];
        //1. 측정한 거리를 담을 변수
        float dist = float.MaxValue;
        //2. 가장 가까운 인덱스(타워의 인덱스)
        int chooseIndex = -1;
        //가장가까운 타워를 찾고싶다.
        for (int i = 0; i < towers.Length; i++)
        {
            //각 목적지마다 거리(temp)를 재고싶다.
            float temp = Vector3.Distance(transform.position, towers[i].transform.position);
            //dist 와 temp의 크기를  비교해서해서 dist > temp 라면
            if (dist > temp)
            {
                dist = temp;
                chooseIndex = i;
            }
        }
        //그곳을 목적지로 하고싶다.
        target = towers[chooseIndex];
        //이동상태로 전환하고 싶다.
        state = State.Walk;
    }

    private void Walk()
    {
        agent.SetDestination(target.transform.position);
    }

    private void Attack()
    {
        throw new NotImplementedException();
    }
}
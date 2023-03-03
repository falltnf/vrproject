using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

//���¸� ����� �����ϰ� �ʹ�.
//Ž��, �̵�, ����

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
        //1. ������ �Ÿ��� ���� ����
        float dist = float.MaxValue;
        //2. ���� ����� �ε���(Ÿ���� �ε���)
        int chooseIndex = -1;
        //���尡��� Ÿ���� ã��ʹ�.
        for (int i = 0; i < towers.Length; i++)
        {
            //�� ���������� �Ÿ�(temp)�� ���ʹ�.
            float temp = Vector3.Distance(transform.position, towers[i].transform.position);
            //dist �� temp�� ũ�⸦  ���ؼ��ؼ� dist > temp ���
            if (dist > temp)
            {
                dist = temp;
                chooseIndex = i;
            }
        }
        //�װ��� �������� �ϰ�ʹ�.
        target = towers[chooseIndex];
        //�̵����·� ��ȯ�ϰ� �ʹ�.
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
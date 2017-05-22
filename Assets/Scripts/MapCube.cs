using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour {

    public GameObject cube;//存储所需要的物品
    [HideInInspector]
    private GameObject cubeChild;//存储生成的物品
    private ChildPos[] child;
    private Transform[] childTransform;
    private int length = 0;//存储需要物品的子物体个数

    //实例化物品
    public void BuildOneCube()
    {
        cubeChild = GameObject.Instantiate(cube, transform.position + Vector3.up * .5f, Quaternion.identity);
        length = cubeChild.transform.childCount;
        if (length <= 0) return;
        else
        {
            childTransform = new Transform[length];
            child = new ChildPos[length];
       //     renders = new Renderer[length];
            for (int i = 0; i < length; i++)
            {
                childTransform[i] = cubeChild.transform.GetChild(i);
                child[i] = new ChildPos(childTransform[i].position.x, childTransform[i].position.y, childTransform[i].position.z, childTransform[i].gameObject);
                child[i].Go.SetActive(false);
            }
            CommonSort<ChildPos>(child, ChildPos.CamparedChild);
            StartCoroutine(ActiveChild(child));
        }
    }

    //冒泡排序
    static void CommonSort<T>(T[] sortArray, Func<T, T, bool> comparedMethod)
    {
        bool swapped = true;
        do
        {
            swapped = false;
            for (int i = 0; i < sortArray.Length - 1; i++)
            {
                if (comparedMethod(sortArray[i], sortArray[i + 1]))
                {
                    T temp = sortArray[i];
                    sortArray[i] = sortArray[i + 1];
                    sortArray[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }
    

    //按时间间隔生成部件
    IEnumerator ActiveChild(ChildPos[] child) {
         int j = 0;
        while (j < length)
        {
            child[j].Go.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            j++;
        }
    }

}

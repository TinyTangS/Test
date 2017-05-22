using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeBehaviour : MonoBehaviour {

    public static CubeBehaviour instance;
    public Material selectedMaterial;//选中后需要改变成的material
    private Material normalMaterial;//单体的material
    
    [HideInInspector]
    public bool isSelected= false;//判定是否被选中
    private int length;//子物体个数
    private Material[] normalMaterials;//子物体的material
   

    private void Start()
    {
        
        length = this.transform.childCount;
        normalMaterials = new Material[length];
        instance = this;
      
        //判定   若为单一物体  直接获取该物体上的material
        if (length == 0)
        {
            normalMaterial = transform.GetComponent<Renderer>().material;
        }
        //判定    若为多个子物体构成   从父物体获取子物体的render组件
        else
        {
            for (int i = 0; i < length; i++)
            {
                normalMaterials[i] = transform.GetChild(i).GetComponent<Renderer>().material;
            }
        }
    }

    //改变物体的颜色   若鼠标按下后  该物体被选中  则改变物体的颜色    若鼠标按下后  该物体未被选中  则将物体的颜色还原
    private void ChangeMaterial(bool isSelected)
    {

       //若为单一物体  直接获取该物体上的render组件
        if (length == 0)
        {
            if (isSelected)
            {
               transform. GetComponent<Renderer>().material = selectedMaterial;
            }
            else
            {
                transform.GetComponent<Renderer>().material = normalMaterial;
            }
        }

        //若为多个物体的组合   获取子物体上的render组件
        else if (length >0){
            if (isSelected)
            {
                for (int i = 0; i < length; i++)
                {
                    transform.GetChild(i).GetComponent<Renderer>().material = selectedMaterial;
                }
            }
            else {
                for (int i = 0; i < length; i++)
                {
                    transform.GetChild(i).GetComponent<Renderer>().material = normalMaterials[i];
                }
               
            }
         }
    }


    private void OnDestroy()
    {
        Destroy(this.gameObject);
    } 

}

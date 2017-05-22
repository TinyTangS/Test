using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour
{

    // Use this for initialization  
    void Start()
    {

    }

    // Update is called once per frame  
    //刚启动应用时，空间映射还没准备好，将创建的Cube释放掉  
    void Update()
    {
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
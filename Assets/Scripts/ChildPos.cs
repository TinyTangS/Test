using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPos  {
    
	public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public GameObject Go { get; set; }

    public ChildPos(float x, float y, float z, GameObject go) {
        this.X = x;
        this.Y = y;
        this.Z = z;
        this.Go = go;
    }
    //cube子物体比较方法
    public static bool CamparedChild(ChildPos c1, ChildPos c2) {
        if (c1.Y > c2.Y)
        {
            return true;
        }
        else
        { 
            if (c1.Y == c2.Y)
            {
                if (c1.X > c2.X)
                {
                    return true;
                }else {
                    if (c1.X  == c2.X )
                    {
                        if (c1.Z > c2.Z)
                        {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}

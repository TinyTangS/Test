using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity;

public class UIController : MonoBehaviour {

    public static UIController instance;


    //物体移动的InputField
    private InputField[] pos;
    //物体旋转的InputField
    private InputField[] rot;
    private Text stateText;
    //选择的cube
    private GameObject selectedCube;
    //选中物体的x坐标值
    private float tx;
    //选中物体的y坐标值
    private float ty;
    //选中物体的z坐标值
    private float tz;
    //选中物体的旋转角度x坐标值
    private float rx;
    //选中物体的旋转角度y坐标值
    private float ry;
    //选中物体的旋转角度z坐标值
    private float rz;
    // Use this for initialization
    private bool needF = false;
    private float speed = 3f;
    private void Awake()
    {
        instance = this;
       
        Init();
    }
    
    

	void Update () {
        selectedCube = Controller.instance.selectedCube;

      
        UpdateUI();
    }


    //坐标移动x增加
    public void OnTransformXPlusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.position += new Vector3(0.2f, 0, 0);
        UpdateUI();
        
    }
    //坐标移动X减少
    public void OnTransformXMinusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.position -= new Vector3(0.2f, 0, 0);
        UpdateUI();

    }
    //坐标移动Y增加
    public void OnTransformYPlusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.position += new Vector3(0, 0.2f, 0);
        UpdateUI();
    }
    //坐标移动Y减少
    public void OnTransformYMinusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.position -= new Vector3(0, 0.2f, 0);
        UpdateUI();

    }
    //坐标移动Z增加
    public void OnTransformZPlusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.position += new Vector3(0, 0, 0.2f);
        UpdateUI();
    }
    //坐标移动Z减少
    public void OnTransformZMinusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.position -= new Vector3(0, 0, 0.2f); ;
        UpdateUI();
    }
    //旋转角度X增加
    public void OnRotationXPlusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.eulerAngles += new Vector3 (30,0,0);
        UpdateUI();
    }
    //旋转角度X减少
    public void OnRotationXMinusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.eulerAngles -= new Vector3 (30,0,0);
        UpdateUI();

    }
    //旋转角度Y增加
    public void OnRotationYPlusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.eulerAngles += new Vector3(0, 30, 0);
        UpdateUI();
    }
    //旋转角度Y减少
    public void OnRotationYMinusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.eulerAngles -= new Vector3 (0,30,0);
        UpdateUI();
    }
    //旋转角度Z增加
    public void OnRotationZPlusClick()
    {
        if (selectedCube == null) return;
        selectedCube.transform.eulerAngles += new Vector3 (0,0,30);
        UpdateUI();

    }
    //旋转角度Z减少
    public void OnRotationZMinusClick()
    {
       if (selectedCube == null) return;
        selectedCube.transform.eulerAngles -= new Vector3(0,0,30);
        UpdateUI();
    }
    //初始化物体移动的InputField和//物体旋转的InputField
    private void Init()
    {
        pos = new InputField[3];
        pos[0] = transform.FindChild("Transform/X").GetComponentInChildren<InputField>();
        pos[1] = transform.FindChild("Transform/Y").GetComponentInChildren<InputField>();
        pos[2] = transform.FindChild("Transform/Z").GetComponentInChildren<InputField>();
        rot = new InputField[3];
        rot[0] = transform.FindChild("Rotation/X").GetComponentInChildren<InputField>();
        rot[1] = transform.FindChild("Rotation/Y").GetComponentInChildren<InputField>();
        rot[2] = transform.FindChild("Rotation/Z").GetComponentInChildren<InputField>();
        stateText = transform.FindChild("State").GetComponentInChildren<Text>();
        stateText.text = "空间移动";
    }
    //更新UI界面显示
    public void UpdateUI() {

        if (selectedCube == null) return;
        tx = selectedCube.transform.position.x;
       // tx = (float)Math.Round(tx, 2);
        pos[0].text = tx.ToString();
        ty = selectedCube.transform.position.y;
        ty = (float)Math.Round(ty, 2);
        pos[1].text = ty.ToString();
        tz = selectedCube.transform.position.z;
        tz = (float)Math.Round(tz, 2);
        pos[2].text = tz.ToString();
        rx = selectedCube.transform.eulerAngles.x;
        
        rx = (float)Math.Round(rx, 2);
        rot[0].text = rx.ToString();
        ry = selectedCube.transform.eulerAngles.y;
        
        ry = (float)Math.Round(ry, 2);
        rot[1].text = ry.ToString();
        rz = selectedCube.transform.eulerAngles.z;
       
        rz = (float)Math.Round(rz, 2);
        rot[2].text = rz.ToString();
    }


    //在InputField的量值修改后的物体位置的移动
    public void OnUIValueChange() {
        if (selectedCube == null) return;
        tx = float.Parse(pos[0].text);
        ty = float.Parse(pos[1].text);
        tz = float.Parse(pos[2].text);
        selectedCube.transform.position = new Vector3(tx, ty, tz);
        rx = float.Parse(rot[0].text);
        ry = float.Parse(rot[1].text);
        rz = float.Parse(rot[2].text);
        selectedCube.transform.eulerAngles = new Vector3(rx, ry, rz);
    }


    public void ChangeState()
    {
        if (selectedCube == null) return;
        needF = !needF;
        if (needF)
        {
            selectedCube.transform.localScale = Vector3.MoveTowards(selectedCube.transform.localScale, new Vector3(0.01f, 1f, 0.01f), speed * Time.deltaTime);
            selectedCube.transform.localPosition = Vector3.MoveTowards(selectedCube.transform.localPosition, Vector3.up * 2, speed * Time.deltaTime);
        }
        else 
        {
           selectedCube.transform.localScale = Vector3.MoveTowards(selectedCube.transform.localScale, new Vector3(1f, 100f, 1f), speed * Time.deltaTime);
            selectedCube.transform.localPosition = Vector3.MoveTowards(selectedCube.transform.localScale, new Vector3 (2,148,22), speed * Time.deltaTime);
        }
    }



}

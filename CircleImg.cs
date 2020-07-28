using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class CircleImg : Image
{
    public int segment = 0;
    public float showPercent = 0;
    protected override void OnPopulateMesh(VertexHelper vh)
    {

        vh.Clear();
        float rectWidth = rectTransform.rect.width;
        float rectHeight = rectTransform.rect.height;

        float radius = rectWidth / 2; //半径
        float radian = 2*Mathf.PI / segment; //单位弧长

        float x = radius * Mathf.Cos(radian);
        float y = radius * Mathf.Sin(radian);

        Vector4 v4 = overrideSprite!=null ? DataUtility.GetOuterUV(overrideSprite):Vector4.zero;
        
        Vector2 allUV = new Vector2((v4.z - v4.x), (v4.w - v4.y));
        Vector2 centerUV = new Vector2(allUV.x/2, allUV.y/2);

        Vector2 rate = new Vector2(allUV.x / rectWidth, allUV.y / rectHeight); //uv与pos的换算

        UIVertex origi = new UIVertex();
        origi.color = color;
        origi.position = Vector2.zero;
        origi.uv0 = new Vector2(centerUV.x + origi.position.x * rate.x, centerUV.y + origi.position.y * rate.y);
        vh.AddVert(origi);

        float cur_pai = 0;
        for(int i = 0; i < segment+1; i++)//按顺序依次添加顶点
        {
            UIVertex vt = new UIVertex();
            vt.color = color;
            float px1 = Mathf.Cos(cur_pai) * radius;
            float py1 = Mathf.Sin(cur_pai) * radius;
            vt.position = new Vector2(px1, py1);
            
            vt.uv0 = new Vector2(centerUV.x + px1 * rate.x, centerUV.y + py1 * rate.y);
            vh.AddVert(vt);
            cur_pai += radian;
            Debug.Log(vt.position);
        }

        int id = 1;
        for(int i = 1; i < segment* showPercent+1; i++)//顺时针画三角形
        {
            
            vh.AddTriangle(id, 0, id + 1);
            id++;
        }
    }


}


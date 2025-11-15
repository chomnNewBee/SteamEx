using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.ChomnFramework.Extend
{
    public class ScrollEx : ScrollRect
    {

        public int PageCount = 1;
        public int ScreenWidth = 1080;
        public int PageIndex = 0;
        protected override void Start()
        {
            base.Start();
            //调整锚点
            this.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
            this.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
            this.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
            vertical = false;
            Debug.Log(PageCount);
            Debug.Log(ScreenWidth);
            Debug.Log(PageIndex);
            Refresh();
        }

        private void Refresh()
        {
            //0-> -1080*0
            //1->-1080*1
            //2->-1080*2
            var x = -ScreenWidth * PageIndex;
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
        }

        public override void OnBeginDrag(PointerEventData eventData) 
        {
            //右边负数 左边正数
            Debug.Log(eventData.delta.x);
            //向右边拖动
            if (eventData.delta.x < 0 && PageIndex == PageCount - 1)
            {
                return;
            }
            //向左边拖动
            if (eventData.delta.x > 0 && PageIndex == 0)
            {
                return;
            }
            // 其他情况正常处理拖动
            base.OnBeginDrag(eventData);
        }

        public override void OnDrag(PointerEventData eventData) 
        {
            Debug.Log(horizontalNormalizedPosition);
           
            //向右边拖动
            if (eventData.delta.x < 0 && PageIndex == PageCount - 1)
            {
                return;
            }
            //向左边拖动
            if (eventData.delta.x > 0 && PageIndex == 0)
            {
                return;
            }
        
            base.OnDrag(eventData);
        }
    }
}
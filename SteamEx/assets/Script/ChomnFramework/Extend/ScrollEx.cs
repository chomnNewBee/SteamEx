using System;
using System.Collections.Generic;
using DG.Tweening;
using QFramework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.ChomnFramework.Extend
{
    public class ScrollEx : MonoBehaviourEx<ScrollEx>,IDragHandler,IBeginDragHandler,IEndDragHandler
    {

        public float DragSpeed = 0.2f;
        public RectTransform canvas;
        public int PageIndex = 0;
        public RectTransform content;
        private List<RectTransform> items = new List<RectTransform>();
        
        private int _PageCount = 0;
        private float _ScreenWidth = 1080;
        private float _ScreenHeight = 1920;
        //private float _StartPos = 0;
        //private float _EndPos = 0;
        private bool isLeft = false;
        //private bool isRunnig = false;
        private bool isOnBorder = false;
      

        public override void StartEx()
        {
            base.StartEx();
            SetItems();
            _ScreenWidth = canvas.rect.width;
            _ScreenHeight = canvas.rect.height;
            _PageCount = items.Count;
            SetPivotAndAnchors();
            SetSelfSize();
            SetItemsSize();
            Refresh(true);
            
            Debug.Log(canvas.rect.width);
            Debug.Log(canvas.rect.height);
        }

        private void SetItems()
        {
            items.Clear();
            for (int i = 0; i < content.childCount; i++)
            {
                RectTransform rectTransform = content.GetChild(i).GetComponent<RectTransform>();
                items.Add(rectTransform);
            }
        }

        private void SetSelfSize()
        {
            this.GetComponent<RectTransform>()
                .SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _ScreenWidth * _PageCount);
            this.GetComponent<RectTransform>()
                .SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _ScreenHeight);
        }

        private void SetPivotAndAnchors()
        {
            //调整锚点
            this.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
            this.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
            this.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
            content.anchorMin = new Vector2(0, 1);
            content.anchorMax = new Vector2(0, 1);
            content.pivot = new Vector2(0, 1);

        }

        private void SetItemsSize()
        {
            foreach (RectTransform item in items)
            {
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _ScreenWidth);
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _ScreenHeight);
            }
        }

        private void Refresh(bool isImmediate = false)
        {
            //0 0
            //1 -1080
            //2 -1080*2
            var targetX = (0 - _ScreenWidth) * PageIndex;
            if(isImmediate)
                content.anchoredPosition = new Vector2(targetX, 0);
            else
            {
                content.DOAnchorPos(new Vector2(targetX, 0), 0.3f);
            }
            
        }
        

        public void OnBeginDrag(PointerEventData eventData)
        {
            isOnBorder = IsOnBorder(eventData);
        }

        bool IsOnBorder(PointerEventData eventData)
        {
            isLeft = eventData.delta.x < 0;
            if (isLeft && PageIndex == _PageCount - 1)
                return true;
            if(!isLeft && PageIndex == 0)
                return true;
            return false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            isOnBorder = IsOnBorder(eventData);
            if(isOnBorder)
                return;
            float deltaX = eventData.delta.x * DragSpeed;
            var targetX = content.anchoredPosition.x + deltaX;
            Debug.Log(targetX);
            Debug.Log(-(_ScreenWidth * (_PageCount - 1)));
            if(targetX > 0 || targetX < -(_ScreenWidth * (_PageCount - 1)))
                return;
            content.anchoredPosition = new Vector2(content.anchoredPosition.x + deltaX, 0);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            PageIndex = CalcIndex(content.anchoredPosition.x);
            Refresh();

        }

        private int CalcIndex(float curX)
        {
            return Mathf.RoundToInt((0 - curX) / _ScreenWidth);
        }
    }
}
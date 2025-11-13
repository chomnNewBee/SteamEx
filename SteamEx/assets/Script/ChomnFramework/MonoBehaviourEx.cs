using System;
using System.Reflection;
using QFramework;
using Script.SteamExLogic;
using UnityEngine;

namespace Script.ChomnFramework
{
    public class MonoBehaviourEx<T> : MonoBehaviour,IController
    {
        public IArchitecture GetArchitecture()
        {
            //换项目在这里更换Architecture即可
            return SteamEx.Interface;
        }

        public virtual void StartEx()
        {
            
        }
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
        
        
        
        

        private void Start()
        {
            AutoSetGoProperty(GetComponent<T>(), gameObject);
            StartEx();
        }
        /// <summary>
        /// auto set every view public property 
        /// </summary>
        /// <param name="go"></param> 
        protected void AutoSetGoProperty<T1>(T1 comp, GameObject go)
        {
            
            Type tempt = comp.GetType();
            foreach (FieldInfo fi in tempt.GetFields(BindingFlags.Instance| BindingFlags.Public| BindingFlags.NonPublic))
            {
                if (!fi.Name.Contains("ui_")) continue;
                Component tempcom = FindScriptInChild(go, fi.FieldType, fi.Name.Replace("ui_", ""));
                if (tempcom == null)
                {
                    Debug.LogError(fi.Name + ". is not find in " + tempt.Name);
                    continue;
                }
                //GenerateLSCODE(tempcom, tempt.Name);   //
                fi.SetValue(comp, tempcom);
            }
        }
        
        /// <summary>
        /// 用于反射不能手动输入类型的
        /// </summary>
        /// <param name="_go"></param>
        /// <param name="type"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        private static Component FindScriptInChild(GameObject _go, Type type, string elementName)
        {
            if (_go == null) return null;
     
            Component[] tempcom = _go.GetComponentsInChildren(type, true);
            if(tempcom == null) return null;
            foreach (Component element in tempcom)
            {
                if (element.gameObject.name == elementName)
                {
                    return element;
                }
            }
       
            return null;
        }
    }
}

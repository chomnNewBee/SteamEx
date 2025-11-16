using System;
using QFramework;
using UnityEngine;
using UnityEngine.Events;

namespace Script.ChomnFramework.Utility
{

    public interface IFPSEx : IUtility
    {
        void AddListener(UnityAction<int> listener);
    }

    public class FPSExWithoutMono : AbstractUtility, IFPSEx
    {
        private bool isFirstStart = true;
        private int m_fps = 0;
        private UnityEvent<int> OnFPSChanged = new UnityEvent<int>();
        public void AddListener(UnityAction<int> listener)
        {
            if (isFirstStart)
            {
                isFirstStart = false;
                ActionKit.OnUpdate.Register(OnUpdate).UnRegisterWhenCurrentSceneUnloaded();
                ActionKit.Repeat().Delay(1).Callback((() =>
                {
                    OnFPSChanged.Invoke(m_fps);
                    m_fps = 0;
                })).StartGlobal();
            }
            OnFPSChanged.AddListener(listener);
        }

        private void OnUpdate()
        {
            m_fps++;
        }
        
    }
    //弃用了
    public class FPSEx : AbstractUtility, IFPSEx
    {
        public void AddListener(UnityAction<int> listener)
        {
            FPSMgr.Instance.OnFPSChanged.AddListener(listener);
        }
    }
    //弃用了
    public class FPSMgr : PersistentMonoSingleton<FPSMgr>
    {
        private int m_FPS;
        public UnityEvent<int> OnFPSChanged = new UnityEvent<int>();

        private void Start()
        {
            m_FPS = 0;
            ActionKit.Repeat().Delay(1).Callback((() =>
            {
                OnFPSChanged.Invoke(m_FPS);
                m_FPS = 0;
            })).Start(this);
        }

        private void Update()
        {
            m_FPS++;
        }
    }
}
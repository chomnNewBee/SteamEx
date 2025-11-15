using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace Script.ChomnFramework.Utility
{
    public interface IAsyncTaskQueueNoWaitEx : IUtility
    {
        IAsyncTaskQueueNoWait SpawnTaskManager();
    }
    public class AsyncTaskQueueNoWaitEx : AbstractUtility,IAsyncTaskQueueNoWaitEx
    {
        public IAsyncTaskQueueNoWait SpawnTaskManager()
        {
            return new AsyncTaskQueueNoWait();
        }
    }
    /// <summary>
    /// 不阻塞，并行执行异步
    /// </summary>
    public interface IAsyncTaskQueueNoWait
    {
        void AddTask(Action<Action> task);
        void StartTask(Action onComplete = null);
    }
    public class AsyncTaskQueueNoWait : IAsyncTaskQueueNoWait
    {
        private Queue<Action<Action>> _taskQueue = new Queue<Action<Action>>();
        private bool _isRunning = false;
        

        public void AddTask(Action<Action> task)
        {
            
            _taskQueue.Enqueue(task);
        }

        public void StartTask(Action onComplete = null)
        {
             int cmpCnt = 0;
             if(_isRunning)
                 return;
             _isRunning = true;
            foreach (var task in _taskQueue)
            {
                task((() =>
                {
                    cmpCnt++;
                    if (cmpCnt == _taskQueue.Count)
                    {
                        _taskQueue.Clear();
                        _isRunning = false;
                        onComplete?.Invoke();
                    }
                }));
            }
        }
   
    }

    
}

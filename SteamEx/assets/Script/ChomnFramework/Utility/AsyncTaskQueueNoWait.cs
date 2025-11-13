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
        private Queue<Action<Action>>  taskQueue = new Queue<Action<Action>>();

        public void AddTask(Action<Action> task)
        {
            taskQueue.Enqueue(task);
        }

        public void StartTask(Action onComplete = null)
        {
            int cmpCnt = 0;
            foreach (Action<Action> action in taskQueue)
            {
                action((() =>
                {
                    cmpCnt++;
                    if(cmpCnt == taskQueue.Count)
                        onComplete?.Invoke();
                }));
            }
        }
   
    }
}

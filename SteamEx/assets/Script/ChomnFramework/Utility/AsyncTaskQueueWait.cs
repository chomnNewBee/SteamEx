using System;
using System.Collections.Generic;
using QFramework;

namespace Script.ChomnFramework.Utility
{
    public interface IAsyncTaskQueueWaitEX : IUtility
    {
        IAsyncTaskQueueWait SpawnTaskManager();
    }
    public class AsyncTaskQueueWaitEX : AbstractUtility,IAsyncTaskQueueWaitEX
    {
        public IAsyncTaskQueueWait SpawnTaskManager()
        {
            return new AsyncTaskQueueWait();
        }
    }
    /// <summary>
    /// 阻塞，按顺序一个一个执行
    /// </summary>
    public interface IAsyncTaskQueueWait
    {
        void AddTask(Action<Action> action);
        void StartTask(Action onComplete = null);
    }
    public class AsyncTaskQueueWait:IAsyncTaskQueueWait
    {
        private Queue<Action<Action>> _taskQueue = new Queue<Action<Action>>();

        public void AddTask(Action<Action> action)
        {
            _taskQueue.Enqueue(action);
        }

        public void StartTask(Action onComplete = null)
        {
            if (_taskQueue.Count == 0)
            {
                onComplete?.Invoke();
                return;
            }

            bool success = _taskQueue.TryDequeue(out var action);
            if (success)
            {
                if (action != null)
                {
                    action((() =>
                    {
                        StartTask(onComplete);
                    }));
                }
                
            }
            
            
        }
    }
}
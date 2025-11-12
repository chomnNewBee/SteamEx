using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using QFramework;
using UnityEngine;
using UnityEngine.Networking;

public class HttpRestful : PersistentMonoSingleton<HttpRestful>
{
   

    // 默认超时时间（秒）
    public float defaultTimeout = 10f;

    #region Get请求
    /// <summary>
    /// 发起Get请求（使用默认超时时间）
    /// </summary>
    public void Get(string url, Action<bool, string> actionResult)
    {
        Get(url, actionResult, defaultTimeout);
    }

    /// <summary>
    /// 发起Get请求（指定超时时间）
    /// </summary>
    public void Get(string url, Action<bool, string> actionResult, float timeout)
    {
        StartCoroutine(_Get(url, actionResult, timeout));
    }

    private IEnumerator _Get(string url, Action<bool, string> action, float timeout)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.timeout = (int)timeout;
            float startTime = Time.time;
            bool isTimeout = false;

            // 启动请求
            var operation = request.SendWebRequest();

            // 等待请求完成或超时
            while (!operation.isDone)
            {
                // 检查是否超时
                if (Time.time - startTime >= timeout)
                {
                    isTimeout = true;
                    request.Abort(); // 中止请求
                    break;
                }
                yield return null;
            }

            if (isTimeout)
            {
                action?.Invoke(false, $"Request timeout after {timeout} seconds");
            }
            else if (request.result == UnityWebRequest.Result.ConnectionError || 
                     request.result == UnityWebRequest.Result.ProtocolError)
            {
                action?.Invoke(false, $"Error: {request.error} (Code: {request.responseCode})");
            }
            else
            {
                action?.Invoke(true, request.downloadHandler.text);
            }
        }
    }
    #endregion

    #region Post请求
    /// <summary>
    /// 发起Post请求（使用默认超时时间）
    /// </summary>
    public void Post(string url, string jsonData, Action<bool, string> actionResult)
    {
        Post(url, jsonData, actionResult, defaultTimeout);
    }

    /// <summary>
    /// 发起Post请求（指定超时时间）
    /// </summary>
    public void Post(string url, string jsonData, Action<bool, string> actionResult, float timeout)
    {
        StartCoroutine(_Post(url, jsonData, actionResult, timeout));
    }

    private IEnumerator _Post(string url, string jsonData, Action<bool, string> action, float timeout)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json; charset=utf-8");
            request.timeout = (int)timeout;

            float startTime = Time.time;
            bool isTimeout = false;

            // 启动请求
            var operation = request.SendWebRequest();

            // 等待请求完成或超时
            while (!operation.isDone)
            {
                if (Time.time - startTime >= timeout)
                {
                    isTimeout = true;
                    request.Abort(); // 中止请求
                    break;
                }
                yield return null;
            }

            if (isTimeout)
            {
                action?.Invoke(false, $"Request timeout after {timeout} seconds");
            }
            else if (request.result == UnityWebRequest.Result.ConnectionError || 
                     request.result == UnityWebRequest.Result.ProtocolError)
            {
                action?.Invoke(false, $"Error: {request.error} (Code: {request.responseCode})");
            }
            else
            {
                action?.Invoke(true, request.downloadHandler.text);
            }
        }
    }
    #endregion

    #region 带请求头的Post请求
    /// <summary>
    /// 发起带自定义请求头的Post请求
    /// </summary>
    public void PostWithHeaders(string url, string jsonData, Dictionary<string, string> headers, Action<bool, string> actionResult, float timeout = 10f)
    {
        StartCoroutine(_PostWithHeaders(url, jsonData, headers, actionResult, timeout));
    }

    private IEnumerator _PostWithHeaders(string url, string jsonData, Dictionary<string, string> headers, Action<bool, string> action, float timeout)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json; charset=utf-8");
            request.timeout = (int)timeout;

            // 添加自定义请求头
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.SetRequestHeader(header.Key, header.Value);
                }
            }

            float startTime = Time.time;
            bool isTimeout = false;

            var operation = request.SendWebRequest();

            while (!operation.isDone)
            {
                if (Time.time - startTime >= timeout)
                {
                    isTimeout = true;
                    request.Abort();
                    break;
                }
                yield return null;
            }

            if (isTimeout)
            {
                action?.Invoke(false, $"Request timeout after {timeout} seconds");
            }
            else if (request.result == UnityWebRequest.Result.ConnectionError || 
                     request.result == UnityWebRequest.Result.ProtocolError)
            {
                action?.Invoke(false, $"Error: {request.error} (Code: {request.responseCode})");
            }
            else
            {
                action?.Invoke(true, request.downloadHandler.text);
            }
        }
    }
    #endregion
}
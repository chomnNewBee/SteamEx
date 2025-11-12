using QFramework;
using UnityEngine;

namespace Script.ChomnFramework.Utility
{

   public interface ILocalStorage : IUtility
   {
      void SetItem(string key, object value);
      T GetItem<T>(string key);
      void RemoveItem(string key);
      void SetInt(string key, int value);
      int GetInt(string key);
      void SetFloat(string key, float value);
      float GetFloat(string key);
      void SetString(string key, string value);
      string GetString(string key);
      bool ContainsKey(string key);
      void RemoveAllKeys();
      
      
   }
   public class LocalStorageEx : AbstractUtility,ILocalStorage
   {
      
      public void SetItem(string key, object value)
      {
         string str = this.GetUtility<IJsonHelper>().ToJson(value);
         SetString(key, str);
      }

      public T GetItem<T>(string key)
      {
         string str = GetString(key);
         return this.GetUtility<IJsonHelper>().FromJson<T>(str);
      }

      public void RemoveItem(string key)
      {
         PlayerPrefs.DeleteKey(key);
         
      }

      public void SetInt(string key, int value)
      {
         PlayerPrefs.SetInt(key, value);
      }

      public int GetInt(string key)
      {
         return PlayerPrefs.GetInt(key);
      }

      public void SetFloat(string key, float value)
      {
         PlayerPrefs.SetFloat(key, value);
      }

      public float GetFloat(string key)
      {
         return PlayerPrefs.GetFloat(key);
      }

      public void SetString(string key, string value)
      {
         PlayerPrefs.SetString(key, value);
      }

      public string GetString(string key)
      {
         return PlayerPrefs.GetString(key);
      }

      public bool ContainsKey(string key)
      {
         return PlayerPrefs.HasKey(key);
      }

      public void RemoveAllKeys()
      {
         PlayerPrefs.DeleteAll();
      }
   }
}
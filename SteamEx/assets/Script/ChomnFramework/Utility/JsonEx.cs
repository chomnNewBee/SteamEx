using QFramework;

namespace Script.ChomnFramework.Utility
{
     public interface IJsonHelper : IUtility
     {
          string ToJson(object obj);
          T FromJson<T>(string json);
     }
     public class JsonEx: AbstractUtility,IJsonHelper
     {
          public JsonEx()
          {
               LitJson.JsonMapper.RegisterImporter((double value) =>
               {
                    return System.Convert.ToSingle(value);
               });

               LitJson.JsonMapper.RegisterImporter((string value) =>
               {
                    int result = 0;
                    int.TryParse(value, out result);
                    return result;
               });

               LitJson.JsonMapper.RegisterImporter((string value) =>
               {
                    float result = 0;
                    float.TryParse(value, out result);
                    return result;
               });
          
          }

          public string ToJson(object obj)
          {
               return LitJson.JsonMapper.ToJson(obj);
          }

          public T FromJson<T>(string json)
          {
               return LitJson.JsonMapper.ToObject<T>(json);
          }

         
     }
}

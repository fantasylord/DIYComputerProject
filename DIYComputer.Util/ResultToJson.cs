using Newtonsoft.Json;
using System;

namespace DIYComputer.Util
{
    [Serializable]
    public class JsonResultModel
    {
        public object Data { get; set; }
        public bool Result { get; set; }
        public string Status { get; set; }
    }
    public class ResultToJson
    {
        /// <summary>
        /// 默认 失败结果
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_result"></param>
        /// <param name="_status"></param>
        /// <returns></returns>
        public static JsonResultModel GetJsonResult(object _data = null)
        {
            JsonResultModel jsonmodel = new JsonResultModel();
            if (_data != null)
            {
                jsonmodel.Result = true;
                jsonmodel.Status = "成功";
                jsonmodel.Data = _data;
            }
            else
            {
                jsonmodel.Result = false;
                jsonmodel.Status = "失败";
                jsonmodel.Data = null;
            }
            return jsonmodel;
        }
        public static string GetJsonResultToSerialize(object _data, bool _result, string _status)
        {
            return JsonConvert.SerializeObject(new JsonResultModel()
            {
                Data = _data,
                Result = _result,
                Status = _status
            });
            // string jsonData = JsonConvert.SerializeObject(one);


        }
    }
}

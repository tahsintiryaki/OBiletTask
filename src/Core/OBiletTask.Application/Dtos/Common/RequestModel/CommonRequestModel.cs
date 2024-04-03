using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.Common.RequestModel
{
    /// <summary>
    /// ObiletApi'ye gönderilen ortak request modeller vardı, bu işlemleri daha basit yönetmek için tüm reuqestlerde kullanabiliceğim bir nesne oluşturdum.
    /// </summary>
    public class CommonRequestModel<T> 
    {
        public T Data { get; set; }

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }


    }
}

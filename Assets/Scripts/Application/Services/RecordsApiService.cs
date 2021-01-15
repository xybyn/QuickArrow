using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


public class RecordsApiService
{
    private PlayerService _playerService;
    public RecordsApiService(PlayerService playerService)
    {
        _playerService = playerService;
    }
    public bool AddRecordAsync(Record newRecord)
    {
        
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create("http://194.67.105.169/api/records");
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/json";
                var score = newRecord.Score;
                var json =
                    @"{""Username"":""" + _playerService.Player.Username + @""", ""GameName"":""quickarrow"",""Score"":""" + score + @"""}";
                using (var requestStream = httpRequest.GetRequestStream())
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(json);
                }
                using (var httpResponse = httpRequest.GetResponse())
                using (var responseStream = httpResponse.GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    string response = reader.ReadToEnd();
                    return string.Equals(response, "True");
                }
            }
            catch
            {
                return false;
            }
        
       
    }
}


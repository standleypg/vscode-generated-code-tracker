using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Requests;

public class WeatherRequest: IHttpRequest
{
    public string city { get; set; }
    public int days { get; set; }
}

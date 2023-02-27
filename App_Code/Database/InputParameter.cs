using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class InputParameter
{
    public string param { get; set; }
    public object value { get; set; }

    public InputParameter(string param, object value)
    {
        this.param = param;
        this.value = value;
    }
}
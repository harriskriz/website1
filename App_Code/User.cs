using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public string username { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public bool isActive { get; set; }
    public string lastModifiedBy { get; set; }
    public string lastModifiedDate { get; set; }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Models
{
    public class ServiceMessageModel
    {
        public int? ErrorId { get; set; }
        public string ErrorTitle { get; set; }
        public dynamic Result { get; set; }
    }
}

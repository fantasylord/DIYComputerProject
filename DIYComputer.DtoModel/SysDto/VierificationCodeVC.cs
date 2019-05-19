using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DIYComputer.DtoModel.SysDto
{
    public class VCode
    {
        public int Id { get; set; } = 0;
        public string Code { get; set; } = "";
        public MemoryStream Data { get; set; } = null;
    }
    public class DataVCode
    {
        public string Imgstr { get; set; }
        public int Id { get; set; }
    }
}

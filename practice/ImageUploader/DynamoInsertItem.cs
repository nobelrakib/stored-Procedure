using System;
using System.Collections.Generic;
using System.Text;

namespace ImageUploader
{
    public class DynamoInsertItem
    {
        public string TableName { get; set; }
        public Dictionary<string, object> Values { get; set; }
    }
}

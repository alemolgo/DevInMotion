using Newtonsoft.Json.Linq;
using System;

namespace DevInMotionApi.Models
{
    public class Agreement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }

        public static explicit operator Agreement(JObject v)
        {
            throw new NotImplementedException();
        }
    }
}

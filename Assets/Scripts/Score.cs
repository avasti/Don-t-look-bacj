using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Assets.Scripts
{
    [JsonObject(MemberSerialization.Fields)]
    class Score
    { 
        public int points { get; set; }
        public bool firstMap { get; set; }
        public bool secondMap { get; set; }
        public bool thirdMap { get; set; }
        public bool forthMap { get; set; }
    }
}

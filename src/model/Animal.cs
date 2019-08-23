using System;

namespace model 
{
    public class Animal 
    {
        public Guid Id { get; set; }
        public string EID { get; set; }
        public string Visual { get; set; }
        public string Sex { get; set; }
        public string CurrentLocation { get; set; }
    }
}
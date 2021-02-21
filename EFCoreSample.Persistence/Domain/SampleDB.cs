using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSample.Persistence.Domain
{
    public class SampleDB
    {
        public int ID { get; set; }
        public String Name { get; set; }


        public SampleDB() { }

        public override string ToString()
        {
            return "User [id=" + this.ID + ", name=" + Name + "]";
        }

    }
}

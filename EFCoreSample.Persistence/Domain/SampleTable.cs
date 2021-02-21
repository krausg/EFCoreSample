using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSample.Persistence.Domain
{
    public class SampleTable
    {
        public int ID { get; set; }
        public String NAME { get; set; }


        public SampleTable() { }

        public override string ToString()
        {
            return "User [id=" + this.ID + ", name=" + NAME + "]";
        }

    }
}

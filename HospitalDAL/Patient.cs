using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL
{
    public class Patient
    {
        public Patient() { }
        public int PatientId
        { get; set; }
        public string Name
        { get; set; }

        public string Email
        { get; set; }
        public string Disease
        { get; set; }
    }
}

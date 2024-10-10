using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL
{
    public class PatientRecordWithMetaData
    {
        public PatientRecordWithMetaData() { }
        public Patient Patient { get; set; }
        public DateTime DeletionDate { get; set; }
        public DateTime RecordTimestamp { get; set; }
    }
}

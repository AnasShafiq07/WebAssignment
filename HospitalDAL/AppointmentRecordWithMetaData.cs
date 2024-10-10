using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL
{
    public class AppointmentRecordWithMetaData
    {
        public AppointmentRecordWithMetaData() { }
        public Appointment Appointment { get; set; }
        public DateTime DeletionDate { get; set; }
        public DateTime RecordTimestamp { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PreContractSOAP.Dominio
{
    public class LogContractModel
    {
		[DataMember]
		public int logContractId { get; set; }
		[DataMember]
		public int typeProcessId { get; set; }
		[DataMember]
		public int? fileStorageId { get; set; }
		[DataMember]
		public int state { get; set; }
		[DataMember]
		public string errorMessage { get; set; }
		[DataMember]
		public int registerUserId { get; set; }
		[DataMember]
		public string registerUserFullname { get; set; }
		[DataMember]
		public DateTime registerDatetime { get; set; }
		[DataMember]
		public int? updateUserId { get; set; }
		[DataMember]
		public string updateUserFullname { get; set; }
		[DataMember]
		public DateTime? updateDatetime { get; set; }
	}
}
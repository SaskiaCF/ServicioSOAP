using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PreContractSOAP.Dominio
{
    public class PreContractLogDetail
    {
		[DataMember]
		public int log_detail_id { get; set; }
		[DataMember]
		public string document_id { get; set; }
		[DataMember]
		public string business_name { get; set; }
		[DataMember]
		public string id_summa { get; set; }
		[DataMember]
		public string item { get; set; }
		[DataMember]
		public string segment { get; set; }
		[DataMember]
		public int? commission_variable { get; set; }
		[DataMember]
		public int? category_id { get; set; }
		[DataMember]
		public string category_name { get; set; }
		[DataMember]
		public string validity { get; set; }
		[DataMember]
		public string commisison_type { get; set; }
		[DataMember]
		public int? month_range_commission_variable { get; set; }
		[DataMember]
		public decimal? percentage_commission_variable { get; set; }
		[DataMember]
		public int? fixed_commission { get; set; }
		[DataMember]
		public int? month_range_fixed_commission { get; set; }
		[DataMember]
		public decimal? fixed_commisison_amount { get; set; }
		[DataMember]
		public string start_date_contract { get; set; }
		[DataMember]
		public string bank_name { get; set; }
		[DataMember]
		public string bank_account { get; set; }
		[DataMember]
		public string interbank_account { get; set; }
		[DataMember]
		public string currency_name { get; set; }
		[DataMember]
		public string bank_account_type_name { get; set; }
		[DataMember]
		public string observation { get; set; }
		[DataMember]
		public int? state { get; set; }
		[DataMember]
		public int? log_id { get; set; }
		[DataMember]
		public int? register_user_id { get; set; }
		[DataMember]
		public string register_user_fullname { get; set; }
		[DataMember]
		public DateTime? register_datetime { get; set; }
	}
}

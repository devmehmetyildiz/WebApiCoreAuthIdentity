using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.Models
{
    public class OrderModel
    {
        private CostumerOrderModel costumerorder;
        public CostumerOrderModel Costumerorder
        {
            get { return costumerorder; }
            set { costumerorder = value; }
        }

        private List<JobOrderModel> joborder;
        public List<JobOrderModel> Joborder
        {
            get { return joborder; }
            set { joborder = value; }
        }

    }
}
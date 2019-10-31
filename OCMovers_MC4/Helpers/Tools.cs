using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;

namespace OCMovers_MC4.Helpers
{
    public class Tools
    {
        private static readonly OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        public static void CreateCustomerEstimate(int estimateId)
        {
            var existing = db.CustomerEstimates.FirstOrDefault(x => x.EstimateId == estimateId);

            if (existing == null)
            {
                var model = new CustomerEstimates()
                {
                    EstimateId = estimateId
                };

                db.CustomerEstimates.Add(model);
                db.SaveChanges();
            }
        }
    }
}

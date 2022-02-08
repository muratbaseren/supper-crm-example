using SupperCRMExample.Entities;
using System.Collections.Generic;

namespace SupperCRMExample.Models
{
    public class DashboardModel
    {
        public int TodayIssueCount { get; set; }
        public int TodayCompletedIssueCount { get; set; }
        public int IssueRateByYesterday { get; set; }

        public int TodayClientCount { get; set; }
        public int ClientRateByYesterday { get; set; }

        public int TotalClientCount { get; set; }
        public int ThisYearClientCount { get; set; }
        public int ClientRateByLastYear { get; set; }

        public int TodayLeadPrice { get; set; }
        public int LeadPriceRateByYesterday { get; set; }

        public Dictionary<int, int> ClientCountForLastWeek { get; set; }
        public Dictionary<int, int> ClientCountForLastYear { get; set; }
        public Dictionary<int, int> MonthlyLeadPricesForLastYear { get; set; }

        public List<Lead> Last10Leads { get; set; }
        public int CompletedLeadCountForThisMonth { get; set; }
    }
}

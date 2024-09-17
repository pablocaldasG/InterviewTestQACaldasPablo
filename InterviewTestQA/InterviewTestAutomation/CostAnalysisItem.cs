using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestQA
{
    public class CostAnalysisItem
    {
        public string YearId { get; set; }
        public int GeoRegionId { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int SchemeId { get; set; }
        public int SchmTypeId { get; set; }
        public decimal Cost { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnas.wns.CnasHCSReport
{
    public class LineAreaSeriesData
    {
        private string month; 
        private double expense; 
        public LineAreaSeriesData(double expense,string month)
        {
            this.expense = expense;
            this.month = month; 
        }
        public string Month 
        { 
            get { return this.month; } 
        }        
        public double Expense
        { 
            get 
        { 
            return this.expense; 
        }
        } 
    }
}

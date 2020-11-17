using ManageYourFinance.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.HelperLibary
{
    public static class EvaluateTimeSelector
    {
        public static void Evaluate(TimeSelector timeSelector, out DateTime startDate, out DateTime endDate)
        {
            var now = DateTime.Today;
            switch (timeSelector)
            {
                case TimeSelector.ThisYear:
                    startDate = new DateTime(now.Year, 1, 1);
                    endDate = new DateTime(now.Year, 12, 31);
                    break;
                case TimeSelector.LastYear:
                    startDate = new DateTime(now.Year - 1, 1, 1);
                    endDate = new DateTime(now.Year - 1, 12, 31);
                    break;
                case TimeSelector.ThisMonth:
                    startDate = new DateTime(now.Year, now.Month, 1);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
                    break;
                case TimeSelector.LastMonth:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    break;
                case TimeSelector.Last3Month:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-3);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    break;
                case TimeSelector.Last6Month:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-6);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    break;
                case TimeSelector.Last9Month:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-9);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    break;
                case TimeSelector.Last12Month:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-12);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    break;
                case TimeSelector.Last30Days:
                    startDate = now.AddDays(-30);
                    endDate = now;
                    break;
                case TimeSelector.Last60Days:
                    startDate = now.AddDays(-60);
                    endDate = now;
                    break;
                case TimeSelector.Last90Days:
                    startDate = now.AddDays(-90);
                    endDate = now;
                    break;
                case TimeSelector.Last120Days:
                    startDate = now.AddDays(-120);
                    endDate = now;
                    break;
                default:
                    startDate = new DateTime(now.Year, 1, 1);
                    endDate = new DateTime(now.Year, 12, 31);
                    break;
            }
        }

        public static void Evaluate(TimeSelector timeSelector, out DateTime startDate, out DateTime endDate, out int averageDividend)
        {
            var now = DateTime.Today;
            switch (timeSelector)
            {
                case TimeSelector.ThisYear:
                    startDate = new DateTime(now.Year, 1, 1);
                    endDate = new DateTime(now.Year, 12, 31);
                    averageDividend = 12;
                    break;
                case TimeSelector.LastYear:
                    startDate = new DateTime(now.Year - 1, 1, 1);
                    endDate = new DateTime(now.Year - 1, 12, 31);
                    averageDividend = 12;
                    break;
                case TimeSelector.ThisMonth:
                    startDate = new DateTime(now.Year, now.Month, 1);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
                    averageDividend = 1;
                    break;
                case TimeSelector.LastMonth:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    averageDividend = 1;
                    break;
                case TimeSelector.Last3Month:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-3);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    averageDividend = 3;
                    break;
                case TimeSelector.Last6Month:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-6);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    averageDividend = 6;
                    break;
                case TimeSelector.Last9Month:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-9);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    averageDividend = 9;
                    break;
                case TimeSelector.Last12Month:
                    startDate = new DateTime(now.Year, now.Month, 1).AddMonths(-12);
                    endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    averageDividend = 12;
                    break;
                case TimeSelector.Last30Days:
                    startDate = now.AddDays(-30);
                    endDate = now;
                    averageDividend = 1;
                    break;
                case TimeSelector.Last60Days:
                    startDate = now.AddDays(-60);
                    endDate = now;
                    averageDividend = 2;
                    break;
                case TimeSelector.Last90Days:
                    startDate = now.AddDays(-90);
                    endDate = now;
                    averageDividend = 3;
                    break;
                case TimeSelector.Last120Days:
                    startDate = now.AddDays(-120);
                    endDate = now;
                    averageDividend = 4;
                    break;
                default:
                    startDate = new DateTime(now.Year, 1, 1);
                    endDate = new DateTime(now.Year, 12, 31);
                    averageDividend = 12;
                    break;
            }
        }
    }
}
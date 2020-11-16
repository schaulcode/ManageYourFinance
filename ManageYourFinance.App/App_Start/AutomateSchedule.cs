using ManageYourFinance.Data.Models;
using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.App_Start
{
    public static class AutomateSchedule
    {
        private static IDataServices<Data.Models.Schedule> db = new SqlDataServices<Data.Models.Schedule>();
        private static IDataServices<Data.Models.Transactions> transactionsDb = new SqlDataServices<Data.Models.Transactions>();

        public static void AddTransaction()
        {
            var todaysSchedule = db.GetAll("NextDueDay", DateTime.Today, "<=").Where(e => e.Frequency != Data.Enums.Frequency.PaidOff);
           
    
            foreach (var item in todaysSchedule)
            {
                var transaction = new Transactions
                {
                    AccountsID = item.AccountsID,
                    CategoryID = item.CategoryID,
                    PayeeID = item.PayeeID,
                    ScheduleID = item.ID,
                    Amount = item.Amount,
                    Date = item.NextDueDay,

                };

                transactionsDb.Add(transaction);

                switch (item.Frequency)
                {
                    case Data.Enums.Frequency.Monthly:
                        item.NextDueDay = item.NextDueDay.AddMonths(1);
                        break;
                    case Data.Enums.Frequency.Weekly:
                        item.NextDueDay = item.NextDueDay.AddDays(7);
                        break;
                    case Data.Enums.Frequency.Yearly:
                        item.NextDueDay = item.NextDueDay.AddYears(1);
                        break;
                    case Data.Enums.Frequency.Quarterly:
                        item.NextDueDay = item.NextDueDay.AddMonths(3);
                        break;
                    case Data.Enums.Frequency.OneTimePayment:
                        item.Frequency = Data.Enums.Frequency.PaidOff;
                        break;
                    case Data.Enums.Frequency.EveryTwoWeeks:
                        item.NextDueDay = item.NextDueDay.AddDays(14);
                        break;
                    case Data.Enums.Frequency.EveryFourWeeks:
                        item.NextDueDay = item.NextDueDay.AddDays(28);
                        break;
                    case Data.Enums.Frequency.TwiceMonth:
                        item.NextDueDay = item.NextDueDay.AddDays(14);
                        break;
                    case Data.Enums.Frequency.EveryTwoMonth:
                        item.NextDueDay = item.NextDueDay.AddMonths(2);
                        break;
                    case Data.Enums.Frequency.TwiceYear:
                        item.NextDueDay = item.NextDueDay.AddMonths(6);
                        break;
                    default:
                        break;
                }

                if (item.TotalAmount.HasValue) { item.AmountCount = item.AmountCount.GetValueOrDefault() + (item.Amount < 0 ? item.Amount * -1 : item.Amount) ; }
                if (item.TotalCount.HasValue) { item.CountCount = item.CountCount.GetValueOrDefault() + 1; }

                if ((item.EndsOnDate.HasValue && item.NextDueDay > item.EndsOnDate) || (item.TotalAmount.HasValue && item.AmountCount >= item.TotalAmount) || (item.TotalCount.HasValue && item.CountCount >= item.TotalCount))
                {
                    item.Frequency = Data.Enums.Frequency.PaidOff;
                }

                db.Edit(item.ID, item);

                
            }
        }
    }
}
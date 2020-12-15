using ManageYourFinance.Data.Enums;
using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class IncomeExpenseModel
    {
        public IncomeExpenseSelection Selection { get; set; } = IncomeExpenseSelection.Category;
        public TimeSelector LeftHandTimeSelector { get; set; } = TimeSelector.ThisYear;
        public TimeSelector RightHandTimeSelector { get; set; } = TimeSelector.ThisYear;
        public List<IIncomeExpense> LeftHandIncome { get; set; } = new List<IIncomeExpense>();
        public List<IIncomeExpense> LeftHandExpense { get; set; } = new List<IIncomeExpense>();
        public List<IIncomeExpense> RightHandIncome { get; set; } = new List<IIncomeExpense>();
        public List<IIncomeExpense> RightHandExpense { get; set; } = new List<IIncomeExpense>();
        public List<IncomeExpenseTable> Income { get; set; }
        public List<IncomeExpenseTable> Expense { get; set; }

        public IncomeExpenseModel()
        {

        }

        public IncomeExpenseModel(TimeSelector leftHandTimeSelector, TimeSelector rightHandTimeSelector)
        {
            this.LeftHandTimeSelector = leftHandTimeSelector;
            this.RightHandTimeSelector = rightHandTimeSelector;

            DateTime leftHandStartDate;
            DateTime leftHandEndDate;
            DateTime rightHandStartDate;
            DateTime rightHandEndDate;
            int leftHandAverageDividend;
            int rightHandAverageDividend;
            var now = DateTime.Today;

            switch (this.LeftHandTimeSelector)
            {
                case TimeSelector.ThisYear:
                    leftHandStartDate = new DateTime(now.Year, 1, 1);
                    leftHandEndDate = new DateTime(now.Year, 12, 31);
                    leftHandAverageDividend = 12;
                    break;
                case TimeSelector.LastYear:
                    leftHandStartDate = new DateTime(now.Year - 1, 1, 1);
                    leftHandEndDate = new DateTime(now.Year - 1, 12, 31);
                    leftHandAverageDividend = 12;
                    break;
                case TimeSelector.ThisMonth:
                    leftHandStartDate = new DateTime(now.Year,now.Month,1);
                    leftHandEndDate = new DateTime(now.Year,now.Month,DateTime.DaysInMonth(now.Year,now.Month));
                    leftHandAverageDividend = 1;
                    break;
                case TimeSelector.LastMonth:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 1;
                    break;
                case TimeSelector.Last3Month:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-3);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 3;
                    break;
                case TimeSelector.Last6Month:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-6);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 6;
                    break;
                case TimeSelector.Last9Month:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-9);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 9;
                    break;
                case TimeSelector.Last12Month:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-12);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 12;
                    break;
                case TimeSelector.Last30Days:
                    leftHandStartDate = now.AddDays(-30);
                    leftHandEndDate = now;
                    leftHandAverageDividend = 1;
                    break;
                case TimeSelector.Last60Days:
                    leftHandStartDate = now.AddDays(-60);
                    leftHandEndDate = now;
                    leftHandAverageDividend = 2;
                    break;
                case TimeSelector.Last90Days:
                    leftHandStartDate = now.AddDays(-90);
                    leftHandEndDate = now;
                    leftHandAverageDividend = 3;
                    break;
                case TimeSelector.Last120Days:
                    leftHandStartDate = now.AddDays(-120);
                    leftHandEndDate = now;
                    leftHandAverageDividend = 4;
                    break;
                default:
                    leftHandStartDate = new DateTime(now.Year, 1, 1);
                    leftHandEndDate = new DateTime(now.Year, 12, 31);
                    leftHandAverageDividend = 12;
                    break;
            }

            switch (this.RightHandTimeSelector)
            {
                case TimeSelector.ThisYear:
                    rightHandStartDate = new DateTime(now.Year, 1, 1);
                    rightHandEndDate = new DateTime(now.Year, 12, 31);
                    rightHandAverageDividend = 12;
                    break;
                case TimeSelector.LastYear:
                    rightHandStartDate = new DateTime(now.Year - 1, 1, 1);
                    rightHandEndDate = new DateTime(now.Year - 1, 12, 31);
                    rightHandAverageDividend = 12;
                    break;
                case TimeSelector.ThisMonth:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
                    rightHandAverageDividend = 1;
                    break;
                case TimeSelector.LastMonth:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 1;
                    break;
                case TimeSelector.Last3Month:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-3);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 3;
                    break;
                case TimeSelector.Last6Month:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-6);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 6;
                    break;
                case TimeSelector.Last9Month:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-9);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 9;
                    break;
                case TimeSelector.Last12Month:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-12);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 12;
                    break;
                case TimeSelector.Last30Days:
                    rightHandStartDate = now.AddDays(-30);
                    rightHandEndDate = now;
                    rightHandAverageDividend = 1;
                    break;
                case TimeSelector.Last60Days:
                    rightHandStartDate = now.AddDays(-60);
                    rightHandEndDate = now;
                    rightHandAverageDividend = 2;
                    break;
                case TimeSelector.Last90Days:
                    rightHandStartDate = now.AddDays(-90);
                    rightHandEndDate = now;
                    rightHandAverageDividend = 3;
                    break;
                case TimeSelector.Last120Days:
                    rightHandStartDate = now.AddDays(-120);
                    rightHandEndDate = now;
                    rightHandAverageDividend = 4;
                    break;
                default:
                    rightHandStartDate = new DateTime(now.Year - 1, 1, 1);
                    rightHandEndDate = new DateTime(now.Year - 1, 12, 31);
                    rightHandAverageDividend = 12;
                    break;
            }

            if (this.Selection == IncomeExpenseSelection.Category)
            {
                var data = new SqlDataServices<Data.Models.Category>().GetAll();
                this.LeftHandIncome = IncomeExpenseCategory.GetModel(data, leftHandStartDate, leftHandEndDate, leftHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Income).ToList();
                this.LeftHandExpense = IncomeExpenseCategory.GetModel(data, leftHandStartDate, leftHandEndDate, leftHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Expense).ToList();
                this.RightHandIncome = IncomeExpenseCategory.GetModel(data, rightHandStartDate, rightHandEndDate, rightHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Income).ToList();
                this.RightHandExpense = IncomeExpenseCategory.GetModel(data, rightHandStartDate, rightHandEndDate, rightHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Expense).ToList();

                this.Income = IncomeExpenseTable.GetModel(this.LeftHandIncome, this.RightHandIncome).ToList();
                this.Expense = IncomeExpenseTable.GetModel(this.LeftHandExpense, this.RightHandExpense).ToList();
            }

            if (this.Selection == IncomeExpenseSelection.Payee)
            {
                var data = new SqlDataServices<Data.Models.Payee>().GetAll();
                this.LeftHandIncome = IncomeExpensePayee.GetModel(data, leftHandStartDate, leftHandEndDate, leftHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Income).ToList();
                this.LeftHandExpense = IncomeExpensePayee.GetModel(data, leftHandStartDate, leftHandEndDate, leftHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Expense).ToList();
                this.RightHandIncome = IncomeExpensePayee.GetModel(data, rightHandStartDate, rightHandEndDate, rightHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Income).ToList();
                this.RightHandExpense = IncomeExpensePayee.GetModel(data, rightHandStartDate, rightHandEndDate, rightHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Expense).ToList();

                this.Income = IncomeExpenseTable.GetModel(this.LeftHandIncome, this.RightHandIncome).ToList();
                this.Expense = IncomeExpenseTable.GetModel(this.LeftHandExpense, this.RightHandExpense).ToList();
            }
        }

        public void UpdateModel()
        {
            DateTime leftHandStartDate;
            DateTime leftHandEndDate;
            DateTime rightHandStartDate;
            DateTime rightHandEndDate;
            int leftHandAverageDividend;
            int rightHandAverageDividend;
            var now = DateTime.Today;

            switch (this.LeftHandTimeSelector)
            {
                case TimeSelector.ThisYear:
                    leftHandStartDate = new DateTime(now.Year, 1, 1);
                    leftHandEndDate = new DateTime(now.Year, 12, 31);
                    leftHandAverageDividend = 12;
                    break;
                case TimeSelector.LastYear:
                    leftHandStartDate = new DateTime(now.Year - 1, 1, 1);
                    leftHandEndDate = new DateTime(now.Year - 1, 12, 31);
                    leftHandAverageDividend = 12;
                    break;
                case TimeSelector.ThisMonth:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
                    leftHandAverageDividend = 1;
                    break;
                case TimeSelector.LastMonth:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 1;
                    break;
                case TimeSelector.Last3Month:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-3);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 3;
                    break;
                case TimeSelector.Last6Month:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-6);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 6;
                    break;
                case TimeSelector.Last9Month:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-9);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 9;
                    break;
                case TimeSelector.Last12Month:
                    leftHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-12);
                    leftHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    leftHandAverageDividend = 12;
                    break;
                case TimeSelector.Last30Days:
                    leftHandStartDate = now.AddDays(-30);
                    leftHandEndDate = now;
                    leftHandAverageDividend = 1;
                    break;
                case TimeSelector.Last60Days:
                    leftHandStartDate = now.AddDays(-60);
                    leftHandEndDate = now;
                    leftHandAverageDividend = 2;
                    break;
                case TimeSelector.Last90Days:
                    leftHandStartDate = now.AddDays(-90);
                    leftHandEndDate = now;
                    leftHandAverageDividend = 3;
                    break;
                case TimeSelector.Last120Days:
                    leftHandStartDate = now.AddDays(-120);
                    leftHandEndDate = now;
                    leftHandAverageDividend = 4;
                    break;
                default:
                    leftHandStartDate = new DateTime(now.Year, 1, 1);
                    leftHandEndDate = new DateTime(now.Year, 12, 31);
                    leftHandAverageDividend = 12;
                    break;
            }

            switch (this.RightHandTimeSelector)
            {
                case TimeSelector.ThisYear:
                    rightHandStartDate = new DateTime(now.Year, 1, 1);
                    rightHandEndDate = new DateTime(now.Year, 12, 31);
                    rightHandAverageDividend = 12;
                    break;
                case TimeSelector.LastYear:
                    rightHandStartDate = new DateTime(now.Year - 1, 1, 1);
                    rightHandEndDate = new DateTime(now.Year - 1, 12, 31);
                    rightHandAverageDividend = 12;
                    break;
                case TimeSelector.ThisMonth:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
                    rightHandAverageDividend = 1;
                    break;
                case TimeSelector.LastMonth:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 1;
                    break;
                case TimeSelector.Last3Month:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-3);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 3;
                    break;
                case TimeSelector.Last6Month:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-6);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 6;
                    break;
                case TimeSelector.Last9Month:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-9);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 9;
                    break;
                case TimeSelector.Last12Month:
                    rightHandStartDate = new DateTime(now.Year, now.Month, 1).AddMonths(-12);
                    rightHandEndDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).AddMonths(-1);
                    rightHandAverageDividend = 12;
                    break;
                case TimeSelector.Last30Days:
                    rightHandStartDate = now.AddDays(-30);
                    rightHandEndDate = now;
                    rightHandAverageDividend = 1;
                    break;
                case TimeSelector.Last60Days:
                    rightHandStartDate = now.AddDays(-60);
                    rightHandEndDate = now;
                    rightHandAverageDividend = 2;
                    break;
                case TimeSelector.Last90Days:
                    rightHandStartDate = now.AddDays(-90);
                    rightHandEndDate = now;
                    rightHandAverageDividend = 3;
                    break;
                case TimeSelector.Last120Days:
                    rightHandStartDate = now.AddDays(-120);
                    rightHandEndDate = now;
                    rightHandAverageDividend = 4;
                    break;
                default:
                    rightHandStartDate = new DateTime(now.Year - 1, 1, 1);
                    rightHandEndDate = new DateTime(now.Year - 1, 12, 31);
                    rightHandAverageDividend = 12;
                    break;
            }

            if (this.Selection == IncomeExpenseSelection.Category)
            {
                var data = new SqlDataServices<Data.Models.Category>().GetAll();
                this.LeftHandIncome = IncomeExpenseCategory.GetModel(data, leftHandStartDate, leftHandEndDate, leftHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Income).ToList();
                this.LeftHandExpense = IncomeExpenseCategory.GetModel(data, leftHandStartDate, leftHandEndDate, leftHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Expense).ToList();
                this.RightHandIncome = IncomeExpenseCategory.GetModel(data, rightHandStartDate, rightHandEndDate, rightHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Income).ToList();
                this.RightHandExpense = IncomeExpenseCategory.GetModel(data, rightHandStartDate, rightHandEndDate, rightHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Expense).ToList();

                this.Income = IncomeExpenseTable.GetModel(this.LeftHandIncome, this.RightHandIncome).ToList();
                this.Expense = IncomeExpenseTable.GetModel(this.LeftHandExpense, this.RightHandExpense).ToList();
            }

            if (this.Selection == IncomeExpenseSelection.Payee)
            {
                var data = new SqlDataServices<Data.Models.Payee>().GetAll();
                this.LeftHandIncome = IncomeExpensePayee.GetModel(data, leftHandStartDate, leftHandEndDate, leftHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Income).ToList();
                this.LeftHandExpense = IncomeExpensePayee.GetModel(data, leftHandStartDate, leftHandEndDate, leftHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Expense).ToList();
                this.RightHandIncome = IncomeExpensePayee.GetModel(data, rightHandStartDate, rightHandEndDate, rightHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Income).ToList();
                this.RightHandExpense = IncomeExpensePayee.GetModel(data, rightHandStartDate, rightHandEndDate, rightHandAverageDividend).Where(e => e.IncomeOrExpense == CategoryType.Expense).ToList();

                this.Income = IncomeExpenseTable.GetModel(this.LeftHandIncome, this.RightHandIncome).ToList();
                this.Expense = IncomeExpenseTable.GetModel(this.LeftHandExpense, this.RightHandExpense).ToList();
            }
        }
    }
}
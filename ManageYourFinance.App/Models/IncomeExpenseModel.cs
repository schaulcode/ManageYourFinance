using ManageYourFinance.App.HelperLibary;
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

            EvaluateTimeSelector.Evaluate(this.LeftHandTimeSelector, out leftHandStartDate, out leftHandEndDate, out leftHandAverageDividend);
            EvaluateTimeSelector.Evaluate(this.RightHandTimeSelector, out rightHandStartDate, out rightHandEndDate, out rightHandAverageDividend);
           
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

            EvaluateTimeSelector.Evaluate(this.LeftHandTimeSelector, out leftHandStartDate, out leftHandEndDate, out leftHandAverageDividend);
            EvaluateTimeSelector.Evaluate(this.RightHandTimeSelector, out rightHandStartDate, out rightHandEndDate, out rightHandAverageDividend);

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
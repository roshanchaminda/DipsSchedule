using System;
using DipsSchedule.ViewModels.Base;
using Xamarin.Forms;

namespace DipsSchedule.ViewModels
{
    public class DateCellViewModel : ViewModelBase
    {
        private Color SelectedDateBackGroundColor = Color.FromHex("#147e88");

        private Color DateBackGroundColor = Color.White;

        private Color SelectedDateTextColor = Color.White;

        private Color DateTextColor = Color.Black;

        private Color dateCellBackgroundColor;

        private Color dateCellTextColor;

        private bool isselectedCell;

        public DateCellViewModel()
        {

        }

        public DateTime DateValue { get; set; }

        public int DateCellIndex { get; set; }

        public Color DateCellBackgroundColor
        {
            get { return dateCellBackgroundColor; }
            set
            {
                dateCellBackgroundColor = value;
                OnPropertyChanged();
            }
        }

        public Color DateCellTextColor
        {
            get { return dateCellTextColor; }
            set
            {
                dateCellTextColor = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelectedCell
        {
            get { return isselectedCell; }
            set
            {
                isselectedCell = value;
                OnPropertyChanged();

                if (value)
                {
                    DateCellTextColor = SelectedDateTextColor;
                    DateCellBackgroundColor = SelectedDateBackGroundColor;
                }
                else
                {
                    DateCellTextColor = DateTextColor;
                    DateCellBackgroundColor = DateBackGroundColor;
                }
            }
        }
    }
}

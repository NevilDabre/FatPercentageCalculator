using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FatPercentageCalculator
{
    class CalorieCalcVM : INotifyPropertyChanged
    {
        private string totalCalorie;
        private string fatGrams;
        private string fatCalorie;
        private string percentage;
        private string totalCalorieError;//error msg for invalide input for total calories 
        private string fatGramError;//error msg for invalide input for fat grams 
        private string lowFatCheck;

        private const int FAT_CALORIE = 9;

        public string TotalCalorie {
            get { return totalCalorie; }
            set { totalCalorie = value; }
        }
        public string FatGrams {
            get { return fatGrams; }
            set { fatGrams = value; }
        }
        public string FatCalorie {
            get { return fatCalorie; }
            set { fatCalorie = value; OnPropertyChanged();}
        }
        public string Percentage
        {   get { return percentage; }
            set { percentage = value; OnPropertyChanged();}
        }
        public string TotalCalorieError {
            get { return totalCalorieError; }
            set { totalCalorieError = value; OnPropertyChanged();}
        }
        public string FatGramError
        {
            get { return fatGramError; }
            set { fatGramError = value; OnPropertyChanged();}
        }
        public string LowFatCheck
        {
            get { return lowFatCheck; }
            set { lowFatCheck = value; OnPropertyChanged();}
        }

        public void calculate() {
            double total_calories;
            double fat_grams;
            double fat_calories;
            double fat_percentage;

            reset();

            try {
                total_calories = double.Parse(TotalCalorie);
            } catch (Exception e)
            {
                TotalCalorieError = "Total Cal shoule be Number!";
                return;
            }

            if (total_calories == 0) {
                TotalCalorieError = "Total Cal Cannot be Zero!";
                return;
            }

            try
            {
                fat_grams = double.Parse(FatGrams);
            }
            catch (Exception e)
            {
                FatGramError = "Fat Gram should be Number!";
                return;
            }

            fat_calories = fat_grams * FAT_CALORIE;

            if(fat_calories > total_calories){
                FatGramError = "Fat Calories <= Total Calories !";
                return;
            }

            fat_percentage = fat_calories / total_calories;
            FatCalorie = fat_calories.ToString();
            Percentage = (fat_percentage * 100).ToString();

            if (fat_percentage < 0.3)
            {
                LowFatCheck = "The Food is Low Fat!";
            }
            else { 
                LowFatCheck = "The Food is not Low Fat!";
            }
        }

        private void reset() {
            FatCalorie = null;
            Percentage = null;
            TotalCalorieError = null;
            FatGramError = null;
            LowFatCheck = null;
        }

        #region Propertychanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
    }
}

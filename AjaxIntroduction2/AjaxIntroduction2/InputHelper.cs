using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxIntroduction2
{
    public class InputHelper
    {
        private int[] input = new int[12];

        public InputHelper(string inputted)
        {
            string[] temp = inputted.Split(',');
            for (int i = 0; i < temp.Length; i++)
            {
                if (String.IsNullOrEmpty(temp[i]))
                {
                    input[i] = -1;
                }
                else
                {
                    input[i] = int.Parse(temp[i]);
                }
            }
        }

        public string isMonthValid(int month)
        {
            if (isFirstInput()) { return ""; }

            int lastInput = input[month - 1];
            double avg = getExistAverage(month);
            double limitInput = avg * 1.2;

            if (lastInput > limitInput)
            {
                return limitInput.ToString();
            }
            else
            {
                return "";
            }
        }

        public double getExistAverage(int month)
        {
            int count = 0;
            int avg = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != -1 && i != (month - 1))
                {
                    avg += input[i];
                    count++;
                }
            }

            if (avg == 0)
            {
                count = 1;
            }

            return avg / count;
        }

        public bool isFirstInput()
        {
            int hasValue = 0;

            foreach (var i in input)
            {
                if (i != -1)
                {
                    hasValue++;
                }
            }

            return hasValue <= 1;
        }
    }
}
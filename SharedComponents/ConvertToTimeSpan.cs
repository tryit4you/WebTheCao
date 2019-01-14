using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.SharedComponents
{
    public class ConvertToTimeSpan
    {
        public static string Convert(DateTime createdDate)
        {
            var output = string.Empty;
            if (createdDate != null)
            {
                DateTime time = new DateTime();
                time = DateTime.Now;
                TimeSpan timeoutput = time.Subtract(createdDate);
                if (timeoutput.Days != 0)
                {
                    if (timeoutput.Days / 360 > 0)
                    {
                        output = $"{Math.Floor((double)timeoutput.Days / 360)} -Năm trước";
                    }
                    else if (timeoutput.Days / 30 > 0&&timeoutput.Days/360<=0)
                    {
                        output = $"{Math.Floor((double)timeoutput.Days / 30)} -Tháng trước";
                    }
                    else
                    {
                        output = $"{timeoutput.Days} -Ngày trước";

                    }
                }
                else if (timeoutput.Hours != 0)
                {
                    output = $"{timeoutput.Hours} -Giờ trước";
                }
                else if (timeoutput.Minutes != 0)
                {
                    output = $"{timeoutput.Minutes} -Phút trước";
                }
                else if (timeoutput.Seconds >= 0)
                {
                    output = " Vài giây trước";
                }
                return output;
            }
            else
            {
                output = DateTime.Now.ToString("c");
                return output;
            }
        }
    }
}

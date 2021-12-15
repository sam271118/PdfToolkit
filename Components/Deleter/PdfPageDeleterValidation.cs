using System;
using System.Text.RegularExpressions;
using static Components.Deleter.PdfPageDeleter;


namespace Components.Deleter
{
    class PdfPageDeleterValidation
    {
        public static bool ValidatePageNumber(string pageno)
        {
            if ((! Regex.IsMatch(pageno, @"^([1-9]+)$")) && (! Regex.IsMatch(pageno, @"^([1-9]{1})([0-9]*)\-([0-9]+)$")))
            {
                PageValidationErrorMessage = "Định dạng số trang không hợp lệ!  ❌";
                return false;
            }

            else if (! pageno.Contains('-'))
            {
                if (Convert.ToInt32(pageno) > TotalPages)
                {
                    PageValidationErrorMessage = $"Phạm vi số trang không hợp lệ! Chỉ có {TotalPages} trang.  ❌";
                    return false;
                }
                else
                {
                    return true;
                }
            }

            else if (pageno.Contains('-'))
            {
                if (Convert.ToInt32(pageno.Split('-')[0]) > TotalPages || Convert.ToInt32(pageno.Split('-')[1]) > TotalPages)
                {
                    PageValidationErrorMessage = $"Phạm vi số trang không hợp lệ! Chỉ có {TotalPages} trang.  ❌";
                    return false;
                }
                else if (Convert.ToInt32(pageno.Split('-')[1]) - Convert.ToInt32(pageno.Split('-')[0]) + 1 > TotalPages)
                {
                    PageValidationErrorMessage = $"Phạm vi số trang không hợp lệ! Chỉ có {TotalPages} trang.  ❌";
                    return false;
                }
                else if (Convert.ToInt32(pageno.Split('-')[1]) - Convert.ToInt32(pageno.Split('-')[0]) + 1 == TotalPages)
                {
                    PageValidationErrorMessage = $"Phạm vi số trang không hợp lệ! Phải còn lại ít nhất 1 trang trong tệp PDF sau quá trình xóa.  ❌";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
            else
            {
                return true;
            }
        }
    }
}
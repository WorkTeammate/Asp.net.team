using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application
{
    public class ValidationMessages
    {
        public const string IsRequired = "این فیلد نمیتواند خالی باشد";
        public const string MaxLength = "این فیلد بیشتر از حد مجاز کارکتر دارد";
        public const string MaxFileSize = "فایل حجیم تر از حد مجاز است";
        public const string InvalidFileFormat = "فرمت فایل مجاز نیست";
        public const string PasswordMin = "پسوورد حداقل باید 8 کارکتر باشد";
    }
}

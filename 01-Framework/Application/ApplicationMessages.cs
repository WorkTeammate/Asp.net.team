using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class ApplicationMessages
    {
        public const string DuplicatedRecord = "امکان ثبت رکورد تکراری وجود ندارد";
        public const string RecordNotFound = "رکورد با اطلاعات درخواست شده یافت نشد";

        public static string PasswordsNotMatch = "پسوورد و تکرار آن با هم مطابقت ندارند";
        public static string WrongUserPass = "نام کاربری یا رمز عبوراشتباه است";
    }
}

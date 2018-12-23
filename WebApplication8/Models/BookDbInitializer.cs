using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStore.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
          
            db.ROLES.Add(new ROLE { NAME = "Администратор", DISCRIPTION = "Контролирую всех" });//1
            db.ROLES.Add(new ROLE { NAME = "Пользователь", DISCRIPTION = "Несу вред всем" });//2
            db.ROLES.Add(new ROLE { NAME = "Менеджер", DISCRIPTION = "Чем то занимаюсь" });//3
            db.ROLES.Add(new ROLE { NAME = "Руководитель", DISCRIPTION = "Управляю всеми" });//4
            db.USER_PROFILES.Add(new USER_PROFILE { PROFILE = "Администратор Руководитель", IDPROFILEROLE=1});//1
            db.USER_PROFILES.Add(new USER_PROFILE { PROFILE = "Менеджер пользователь", IDPROFILEROLE = 3 });//2
            db.USER_PROFILES.Add(new USER_PROFILE { PROFILE = "Менеджер руководитель", IDPROFILEROLE = 4});//3
            db.USER_PROFILES.Add(new USER_PROFILE { PROFILE = "Менеджер пользователь", IDPROFILEROLE = 2 });//3
            db.Users.Add(new User { FIO = "Иванов иван Иванович", login = "ivanov", IdPROFILE=1, IdPROFILECODE= "Администратор Руководитель" });
            db.Users.Add(new User { FIO = "Петров Петр Петрович", login = "Petrov", IdPROFILE = 2, IdPROFILECODE = "Менеджер пользователь" });
            db.Users.Add(new User { FIO = "Александров Александр Александрович", login = "Alex", IdPROFILE = 2, IdPROFILECODE = "Менеджер пользователь" });
            db.Users.Add(new User { FIO = "Сидоров Сидр Сидорович", login = "Alex2", IdPROFILE = 3, IdPROFILECODE = "Менеджер руководитель" });
            base.Seed(db);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;


namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<User> users = db.Users;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.User  = users;
            IEnumerable<USER_PROFILE> USER_PROFILES = db.USER_PROFILES;
            IEnumerable<ROLE> ROLES = db.ROLES;
            // передаем все объекты в динамическое свойство Books в ViewBag
            var entryPoint = (from u in db.Users
                              join p in db.USER_PROFILES on u.IdPROFILECODE equals p.PROFILE
                              join r in db.ROLES on p.IDPROFILEROLE equals r.Id
                              select new
                              {
                                  log = u.login,
                                  fam = u.FIO,
                                  Prof = p.PROFILE,
                                  rol = r.NAME,
                                  des = r.DISCRIPTION
                              }).OrderBy(p => p.log);
            // ViewBag.USER_PROFILE = USER_PROFILES;
            // возвращаем представление

            ViewBag.Countries = entryPoint;
            return View();
        }
        [HttpGet]
        public ActionResult CREATE()
        {
            // получаем из бд все объекты Book
            IEnumerable<ROLE> ROLES = db.ROLES;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.ROLE = ROLES;
            IEnumerable<USER_PROFILE> USER_PROFILES = db.USER_PROFILES;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.USER_PROFILE = USER_PROFILES;


            // возвращаем представление
            return View();
            //ViewBag.BookId = id;
 
        }
        [HttpPost]
        public string CREATE(ROLE RoleAdd, USER_PROFILE USER_PROFILE_ADD, User userAdd)
        {
            if (RoleAdd.NAME != null)
                db.ROLES.Add(RoleAdd);
            // добавляем информацию о покупке в базу данных
            if (USER_PROFILE_ADD.PROFILE != null)
                db.USER_PROFILES.Add(USER_PROFILE_ADD);
            // сохраняем в бд все изменения
            if (userAdd.login != null)
            { 
                db.Users.Add(userAdd);
                db.SaveChanges();
                var userAddQweryGetLogin = db.Users.FirstOrDefault(_ => _.login == userAdd.login);
                var userAddQweryGetProfel = db.USER_PROFILES.FirstOrDefault(_ => _.Id == userAddQweryGetLogin.IdPROFILE);
                userAddQweryGetLogin.IdPROFILECODE = userAddQweryGetProfel.PROFILE;
                db.SaveChanges();
            }
            db.SaveChanges();
            return "Спасибо" ;
        }

        [HttpGet]
        public ActionResult UPDATE()
        {
            IEnumerable<ROLE> ROLES = db.ROLES;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.ROLE = ROLES;
            IEnumerable<USER_PROFILE> USER_PROFILES = db.USER_PROFILES;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.USER_PROFILE = USER_PROFILES;

            IEnumerable<User> Users = db.Users;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.User = Users;
            // возвращаем представление
            return View();

        }
        [HttpPost]
        public string UPDATE(ROLE RoleUpdate, 
            USER_PROFILE USER_PROFILE_UPDATE, 
            User userUpdate, 
            string NewNamePROFILES, 
            string NewNameUserLogin,
            string NewNameUserFIO
            )
        {
            if (RoleUpdate.NAME != null)
            {
                var USER_ROLE_UPDATE_QWERY = db.ROLES.FirstOrDefault(a => a.Id == RoleUpdate.Id);
                if (USER_ROLE_UPDATE_QWERY != null)
                    USER_ROLE_UPDATE_QWERY.NAME = RoleUpdate.NAME;
            }
        
            if (RoleUpdate.DISCRIPTION != null)
            {
                var USER_ROLE_UPDATE_QWERY = db.ROLES.FirstOrDefault(a => a.Id == RoleUpdate.Id);
                if (USER_ROLE_UPDATE_QWERY != null)
                    USER_ROLE_UPDATE_QWERY.DISCRIPTION = RoleUpdate.DISCRIPTION;
            }

            if (NewNamePROFILES != "" || NewNamePROFILES != null)
            {
                var USER_PROFILES_UPDATE_QWERY = db.USER_PROFILES.FirstOrDefault(a => a.PROFILE == USER_PROFILE_UPDATE.PROFILE);
                if(USER_PROFILES_UPDATE_QWERY != null)
                    USER_PROFILES_UPDATE_QWERY.PROFILE = NewNamePROFILES;
                var USER_UPDATE_QWERY = db.Users.FirstOrDefault(a => a.IdPROFILECODE == USER_PROFILE_UPDATE.PROFILE);
                if (USER_UPDATE_QWERY != null)
                    USER_UPDATE_QWERY.IdPROFILECODE = NewNamePROFILES;
            }

            // добавляем информацию о покупке в базу данных
            // сохраняем в бд все изменения

            if (NewNameUserLogin != "" || NewNameUserLogin != null)
            {
                var userUpdateQwery = db.Users.FirstOrDefault(_ => _.login == userUpdate.login);
                if (userUpdateQwery != null)
                    userUpdateQwery.login = NewNameUserLogin;
            }
            if (NewNameUserFIO != "" ||NewNameUserFIO != null)
            {
                var userUpdateQwery = db.Users.FirstOrDefault(_ => _.login == userUpdate.login);
                if (userUpdateQwery != null)
                    userUpdateQwery.FIO = NewNameUserFIO;
            }
            db.SaveChanges();
            return "Спасибо,";

        }
        [HttpGet]
        public ActionResult DELETE()
        {
            // получаем из бд все объекты Book
            IEnumerable<ROLE> ROLES = db.ROLES;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.ROLE = ROLES;
            IEnumerable<USER_PROFILE> USER_PROFILES = db.USER_PROFILES;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.USER_PROFILE = USER_PROFILES;

            IEnumerable<User> Users = db.Users;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.User = Users;
            // возвращаем представление
            return View();

        }
        [HttpPost]
        public string DELETE(ROLE RoleDelet, USER_PROFILE USER_PROFILE_DELETE, User userDelete)
        {
            var RoleDeletQwery = db.ROLES.Where(_ => _.Id == RoleDelet.Id).AsEnumerable().ToList();
            db.ROLES.RemoveRange(RoleDeletQwery);

            var USER_PROFILE_DELETEQwery = db.USER_PROFILES.Where(_ => _.PROFILE == USER_PROFILE_DELETE.PROFILE).AsEnumerable().ToList();
            // сохраняем в бд все изменения
            db.USER_PROFILES.RemoveRange(USER_PROFILE_DELETEQwery);
  
            var userDeleteQwery = db.Users.Where(_ => _.login == userDelete.login).AsEnumerable().ToList();
            db.Users.RemoveRange(userDeleteQwery);

            db.SaveChanges();
            return "Спасибо,";
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Wholesale_Marketplace.Models;
using System.Security.Cryptography;
using System.IO;

namespace Wholesale_Marketplace.Controllers
{
    public class AccountController : Controller
    {

        WMDB db = new WMDB();
        MD5 passHash = MD5.Create();

        [HttpGet]
        public ActionResult Register()
        {

            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(User newUser)
        {
            if (ModelState.IsValid && !db.Users.Where(e => e.Login == newUser.Login).Any())
            {
                if (newUser.RoleID == 0)
                {
                    //newUser.Password = passHash.ComputeHash(Helpers.GetBytes(newUser.Password));
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(newUser.Login, true);
                    ViewBag.RoleID = newUser.RoleID;
                    ViewBag.UserID = newUser.UserID;
                    ViewBag.Login = newUser.Login;

                    Buyer modelOut = new Buyer();
                    modelOut.Name = "";
                    modelOut.Address = "";
                    return View("AddInfoBuyer", modelOut);
                }
            } 
            
            return View("Register");

        }

        //[HttpPost]
        public ActionResult AddInfoBuyer([Bind(Exclude = "Avatar")] Buyer newBuyer, HttpPostedFileBase Avatar)
        {
            if (Helpers.UserCheck(db, ViewBag) && ModelState.IsValid)
            {
                if (ViewBag.RoleID == 0)
                {
                    int curUserID = ViewBag.UserID;
                    
                    if (db.Buyers.Any(e => e.UserID == curUserID))
                    {
                        Buyer curBuyer = db.Buyers.First(e => e.UserID == curUserID);
                        curBuyer.Name = newBuyer.Name;
                        curBuyer.Address = newBuyer.Address;
                        if (Avatar != null) curBuyer.Avatar = (new BinaryReader(Avatar.InputStream)).ReadBytes((int)Avatar.InputStream.Length);
                        db.Entry(curBuyer).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        newBuyer.UserID = curUserID;
                        newBuyer.Orders_count = 0;
                        newBuyer.Registration_date = DateTime.Now;
                        db.Buyers.Add(newBuyer);
                        db.SaveChanges();
                    }
                    return Redirect("/Home/Index");
                }
            }

            Buyer modelOut = new Buyer() ;
            modelOut.Name = "";
            modelOut.Address = "";
            if (ViewBag.UserID >= 0)
            {
                int curUser = ViewBag.UserID;
                try
                {
                    modelOut = db.Buyers.First(m => m.UserID == curUser);
                }
                catch { }
            }
            return View("AddInfoBuyer", modelOut);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            if (db.Users.Any(e => e.Login == u.Login))
            {
                User curUser = db.Users.First(e => e.Login == u.Login);
                //u.Password = passHash.ComputeHash(Helpers.GetBytes(u.Password));
                if (curUser.Password == u.Password)
                {
                    FormsAuthentication.SetAuthCookie(curUser.Login, true);
                    return Redirect("/Home/Index");
                }
            }

            return View("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }


        public ActionResult Avatar(string login)
        {
            User curUser = db.Users.First(m => m.Login == login);

            if (curUser.RoleID == 0)
            {
                try
                {
                    byte[] img = db.Buyers.First(m => m.UserID == curUser.UserID).Avatar;
                    if (img != null) return File(img, "image/jpeg");
                }
                catch { }
            }

            return File("~/Content/default-avatar.png", "image/png");
        }

    }
}
